using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PlagCheck_Server
{
    public partial class ServerMainForm : Form
    {
        private TcpListener serverSocket;
        private int port;
        private string fullLogs = "";
        private string jplagDir = "";
        private IPHostEntry ipHostInfo;
        private IPAddress ipAddress;
        private readonly XmlSerializer pListSerializer;
        private readonly XmlSerializer requestSerializer;
        private readonly XmlSerializer responseSerializer;
        private readonly XmlSerializer solutionSerializer;
        private ProblemDAO pdao;
        private SolutionDAO sdao;
        private List<Problem> pList;
        private List<Solution> sList;
        private BackgroundWorker communicator = null;

        internal ProblemDAO Pdao { get => pdao; set => pdao = value; }
        internal SolutionDAO Sdao { get => sdao; set => sdao = value; }
        internal List<Problem> PList { get => pList; set => pList = value; }
        internal List<Solution> SList { get => sList; set => sList = value; }
        public string FullLogs { get => fullLogs; }
        public string JplagDir { get => jplagDir; set => jplagDir = value; }

        public void WriteLogs(string s)
        {
            fullLogs += s;
            fullLogs += "\r\n";
            fullLogs += "\r\n";
        }

        public void AddStatus(string s)
        {
            statusBox.Text += s;
            statusBox.Text += "\r\n";
        }

        public ServerMainForm()
        {
            InitializeComponent();
            pListSerializer = new XmlSerializer(typeof(List<Problem>));
            requestSerializer = new XmlSerializer(typeof(PlagCheck_Client.Request));
            responseSerializer = new XmlSerializer(typeof(Response));
            solutionSerializer = new XmlSerializer(typeof(Solution));
            try {
                StreamReader sr = new StreamReader(jplagDir);
                jplagDir = sr.ReadToEnd(); sr.Close();
                if (JplagDir != null) AddStatus(string.Format("Set up JPlag directory as {0}", jplagDir));
            }
            catch (Exception jpExc) {
                AddStatus(jpExc.Message);
            }
        }

        public void UpdateTable()
        {
            problemTable.Rows.Clear();
            problemTable.Refresh();
            pList = pdao.ListAllProblems();
            for (int i = 0; i < pList.Count; i++)
            {
                problemTable.Rows.Add(pList[i].Id, pList[i].Name, pList[i].TimeLimit, pList[i].MemoryLimit, "Edit", "Delete");
            }
        }

        public void InitializeSolution_ProPicker()
        {
            problemPickBox.Items.Clear();
            for (int i = 0; i < pList.Count; i++)
            {
                problemPickBox.Items.Add(pList[i].ToString);
            }
        }

        public void UpdatePreview(string content)
        {
            content = content.Replace("\r\n", "\n");
            content = content.Replace("\n", "\r\n");
            solutionPreviewBox.Text = content;
        }

        public void ResetSolPicker()
        {
            problemPickBox.Text = "";
            solutionPickBox.Text = "";
        }

        public void SendAcknowledgement(Socket target)
        {
            string serializedValue = "";
            using (StringWriter sw = new StringWriter())
            {
                pListSerializer.Serialize(sw, pList);
                serializedValue = sw.ToString();
            }

            WriteLogs(string.Format("{0}\r\nserver -> client\r\n{1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt"), "<ACK>" + serializedValue));
            byte[] message = Encoding.UTF8.GetBytes("<ACK>" + serializedValue);
            target.Send(message);
        }

        public void SendResponse(Socket target, PlagCheck_Client.Request request)
        {
            string serializedValue = "";
            using (StringWriter sw = new StringWriter())
            {
                responseSerializer.Serialize(sw, PlagCheckUtils.GenerateResponse(this, request, sdao));
                serializedValue = sw.ToString();
            }

            WriteLogs(string.Format("{0}\r\nserver -> client\r\n{1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt"), "<ACK>" + serializedValue));
            byte[] message = Encoding.UTF8.GetBytes("<ACK>" + serializedValue);
            target.Send(message);
        }

        private void MaintainConnection(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!serverSocket.Pending()) continue;
                Thread subThread = new Thread(ReceiveAndResponse);
                subThread.Start();
            }
        }

        private void ReceiveAndResponse()
        {
            Socket clientSocket = serverSocket.AcceptSocket();

            int rem = clientSocket.Available;
            if (rem == 0) return;

            string data = "";
            byte[] bytes = new byte[16777216];

            while (true)
            {
                int numByte = clientSocket.Receive(bytes);
                if (numByte == 0) break;
                data += Encoding.UTF8.GetString(bytes, 0, numByte);
                if (data.Contains("<EOM>")) break;
            }

            WriteLogs(string.Format("{0}\r\nclient -> server\r\n{1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt"), data));

            AddStatus(String.Format("Text received at {0} -> {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt"), ((data.Length > 64 || data.Contains("\n")) ? (data.Substring(0, (data.IndexOf("\n") > 64) ? 64 : data.IndexOf("\n")) + "...") : data)));

            if (data.Length >= 5 && data.Substring(0, 5) == "<INI>")
            {
                SendAcknowledgement(clientSocket);
            }
            if (data.Length >= 5 && data.Substring(0, 5) == "<REQ>")
            {
                PlagCheck_Client.Request request;
                using (TextReader tr = new StringReader(data.Substring(5, data.Length - 10)))
                {
                    request = (PlagCheck_Client.Request)requestSerializer.Deserialize(tr);
                }
                SendResponse(clientSocket, request);
            }
            if (data.Length >= 5 && data.Substring(0, 5) == "<ADD>")
            {
                Solution sol;
                using (TextReader tr = new StringReader(data.Substring(5, data.Length - 10)))
                {
                    sol = (Solution)solutionSerializer.Deserialize(tr);
                }
                sol.Id = sdao.GetNextSolutionId();
                sdao.AddSolution(sol);
            }

            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                ipAddress = ipHostInfo.AddressList[1];
                port = int.Parse(portTextBox.Text);

                serverSocket = new TcpListener(ipAddress, port);
                serverSocket.Start();

                pdao = new ProblemDAO();
                sdao = new SolutionDAO();

                UpdateTable();
                InitializeSolution_ProPicker();

                reloadTimer.Enabled = true;
                tabControl.Enabled = true;
                startServerButton.Enabled = false;
                stopServerButton.Enabled = true;
                //communicator = new BackgroundWorker();
                //communicator.DoWork += new DoWorkEventHandler(MaintainConnection);
                //communicator.RunWorkerAsync();
                AddStatus(String.Format("Successfully opened socket at {0}:{1}.", ipAddress, port));
            }
            catch (Exception exc)
            {
                AddStatus(exc.Message);
            }
        }

        private void StopServerButton_MouseClick(object sender, MouseEventArgs e)
        {
            reloadTimer.Enabled = false;
            if (communicator != null)
            {
                communicator.Dispose();
                communicator = null;
            }
            if (serverSocket != null)
            {
                problemTable.Rows.Clear();
                problemTable.Refresh();
                pdao = null;
                serverSocket.Stop();
                AddStatus("Successfully closed socket.");
            }
            tabControl.Enabled = false;
            startServerButton.Enabled = true;
            stopServerButton.Enabled = false;
        }

        private void StatusBox_TextChanged(object sender, EventArgs e)
        {
            statusBox.SelectionStart = statusBox.Text.Length;
            statusBox.ScrollToCaret();
            statusBox.Refresh();
        }

        private void PortTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && startServerButton.Enabled) startServerButton.PerformClick();
        }

        private void ProblemTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            int colId = e.ColumnIndex;
            if (rowId > -1 && colId == 4)
            {
                EditProblemForm editForm = new EditProblemForm(this, pList[rowId]);
                editForm.Show();
            }
            else if (rowId > -1 && colId == 5)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this problem?\r\nDeleting a problem will delete ALL solutions associated with it.", "Confirm deletion", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    int id = int.Parse(problemTable.Rows[rowId].Cells[0].Value.ToString());
                    AddStatus(String.Format("Successfully deleted problem with id #{0}.", id));
                    List<Solution> associatedSolutionList = sdao.ListSolutionsFromProblem(id);
                    for (int i = 0; i < associatedSolutionList.Count; i++)
                    {
                        sdao.DeleteSolution(associatedSolutionList[i].Id);
                    }
                    pdao.DeleteProblem(id);
                    UpdateTable();
                    MessageBox.Show("Deleted!");
                }
            }
        }

        private void AddProblemButton_Click(object sender, EventArgs e)
        {
            AddProblemForm addForm = new AddProblemForm(this);
            addForm.Show();
        }

        private void ProblemPickBox_TextChanged(object sender, EventArgs e)
        {
            solutionPickBox.Items.Clear();
            if (problemPickBox.Text == "") return;
            Problem selected = pdao.GetProblem(Problem.Parse(problemPickBox.Text).Id);
            sList = sdao.ListSolutionsFromProblem(selected.Id);
            for (int i = 0; i < sList.Count; i++)
            {
                solutionPickBox.Items.Add(sList[i].ToString);
            }
            UpdatePreview("");
            editSolutionButton.Enabled = false;
            deleteSolutionButton.Enabled = false;
        }

        private void SolutionPickBox_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview("");
            editSolutionButton.Enabled = false;
            deleteSolutionButton.Enabled = false;
            if (solutionPickBox.Text == "") return;
            editSolutionButton.Enabled = true;
            deleteSolutionButton.Enabled = true;
            Solution selected = sdao.GetSolution(Solution.Parse(solutionPickBox.Text).Id);
            UpdatePreview(selected.Content);
        }

        private void AddSolutionButton_Click(object sender, EventArgs e)
        {
            AddSolutionForm addForm = new AddSolutionForm(this);
            addForm.Show();
        }

        private void EditSolutionButton_Click(object sender, EventArgs e)
        {
            Solution selected = sdao.GetSolution(Solution.Parse(solutionPickBox.Text).Id);
            EditSolutionForm editForm = new EditSolutionForm(this, selected);
            editForm.Show();
        }

        private void DeleteSolutionButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this solution?", "Confirm deletion", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int id = sdao.GetSolution(Solution.Parse(solutionPickBox.Text).Id).Id;
                AddStatus(String.Format("Successfully deleted solution with id #{0}.", id));
                sdao.DeleteSolution(id);
                ResetSolPicker();
                MessageBox.Show("Deleted!");
            }
        }

        private void viewLogsButton_Click(object sender, EventArgs e)
        {
            ViewLogsForm vlf = new ViewLogsForm(this);
            vlf.Show();
        }

        private void setJPlagButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = jplagOpenFileDialog.ShowDialog();
            if (dr != DialogResult.OK) return;
            if (string.IsNullOrWhiteSpace(jplagOpenFileDialog.FileName)) return;
            jplagDir = jplagOpenFileDialog.FileName;
            StreamWriter sw = new StreamWriter("JPlagDirectory.txt");
            sw.WriteLine(jplagDir); sw.Close();
            AddStatus(string.Format("Set up JPlag directory as {0}", jplagDir));
        }

        private void ServerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopServerButton.PerformClick();
        }

        private void reloadTimer_Tick(object sender, EventArgs e)
        {
            if (serverSocket.Pending()) ReceiveAndResponse();
        }
    }
}