using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PlagCheck_Client
{
    public partial class ClientMainForm : Form
    {
        private IPHostEntry ipHostInfo;
        private IPAddress ipAddress;
        private Socket clientSocket;
        private readonly XmlSerializer pListSerializer;
        private readonly XmlSerializer requestSerializer;
        private readonly XmlSerializer responseSerializer;
        private readonly XmlSerializer solutionSerializer;
        private List<PlagCheck_Server.Problem> pList;
        private string[] fileList;
        private string[] shortenedFileList;
        private string folderDirectory;

        public ClientMainForm()
        {
            InitializeComponent();
            pListSerializer = new XmlSerializer(typeof(List<PlagCheck_Server.Problem>));
            requestSerializer = new XmlSerializer(typeof(Request));
            responseSerializer = new XmlSerializer(typeof(PlagCheck_Server.Response));
            solutionSerializer = new XmlSerializer(typeof(PlagCheck_Server.Solution));
        }

        public bool EqualProblemList(List<PlagCheck_Server.Problem> a, List<PlagCheck_Server.Problem> b)
        {
            if (a == null || b == null) return false;
            if (a.Count != b.Count) return false;
            for (int i=0; i<a.Count; i++)
            {
                if (!a[i].Equals(b[i])) return false;
            }
            return true;
        }

        public void AddLogs(string s)
        {
            statusBox.Text += s;
            statusBox.Text += "\r\n";
        }

        public void DisplayFiles(string path, string language)
        {
            internalCheckButton.Enabled = true;
            globalCheckButton.Enabled = true;
            string pattern = "";
            if (language.Equals("C++")) pattern = "*.cpp";
            else if (language.Equals("Java")) pattern = "*.java";
            fileList = Directory.GetFiles(path, pattern);
            shortenedFileList = (string[])fileList.Clone();
            solutionTable.Rows.Clear();
            for (int i=0; i<fileList.Length; i++)
            {
                string relativePath = fileList[i].Replace(path + "\\", "");
                shortenedFileList[i] = relativePath;
                long fileSize = new FileInfo(fileList[i]).Length;
                solutionTable.Rows.Add(relativePath, fileSize, true);
            }
            solutionTable.Refresh();
        }

        public void AssureConnection()
        {
            try
            {
                ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                ipAddress = ipHostInfo.AddressList[1];
                clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.SendBufferSize = 1048576;
                clientSocket.ReceiveBufferSize = 1048576;
                string ip = ipTextBox.Text;
                int port = int.Parse(portTextBox.Text);
                clientSocket.Connect(ip, port);
                string message = ((IPEndPoint)clientSocket.LocalEndPoint).Address.ToString() + ":" + ((IPEndPoint)clientSocket.LocalEndPoint).Port.ToString();
                byte[] messageSent = Encoding.UTF8.GetBytes("<INI>" + message + "<EOM>");
                int byteSent = clientSocket.Send(messageSent);
                byte[] messageReceived = new byte[65536];
                int byteRecv = clientSocket.Receive(messageReceived);
                string received = Encoding.UTF8.GetString(messageReceived, 0, byteRecv);
                AddLogs(String.Format("Text received at {0} -> {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt"), ((received.Length > 64 || received.Contains("\n")) ? (received.Substring(0, (received.IndexOf("\n") > 64) ? 64 : received.IndexOf("\n")) + "...") : received)));
                if (received.Length >= 5 && received.Substring(0, 5).Equals("<ACK>"))
                {
                    AddLogs(String.Format("Successfully connected to socket at {0}:{1}", ip, port));
                    List<PlagCheck_Server.Problem> tmpPList;
                    using (TextReader tr = new StringReader(received.Substring(5)))
                    {
                        tmpPList = (List<PlagCheck_Server.Problem>)pListSerializer.Deserialize(tr);
                    }
                    if (!EqualProblemList(tmpPList, pList))
                    {
                        pList = tmpPList;
                        problemPickBox.Items.Clear();
                        for (int i = 0; i < pList.Count; i++)
                        {
                            problemPickBox.Items.Add(pList[i].ToString);
                        }
                        folderDirectory = null;
                    }
                    problemPickBox.Enabled = true;
                    langPickBox.Enabled = true;
                    disconnectServerButton.Enabled = true;
                    connectServerButton.Enabled = false;
                    DisplayFiles(pickFolderDialog.SelectedPath, langPickBox.Text);
                }
                else
                {
                    AddLogs(String.Format("Failed to connect to socket at {0}:{1}.", ip, port));
                    disconnectServerButton.PerformClick();
                }
            }
            catch (Exception exc)
            {
                AddLogs(exc.Message);
                disconnectServerButton.PerformClick();
            }
            clientSocket.Dispose();
        }

        public void SendRequest(Request req)
        {
            PlagCheck_Server.Response res = null;
            try
            {
                ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                ipAddress = ipHostInfo.AddressList[1];
                clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.SendBufferSize = 1048576;
                clientSocket.ReceiveBufferSize = 1048576;
                string ip = ipTextBox.Text;
                int port = int.Parse(portTextBox.Text);
                clientSocket.Connect(ip, port);
                string message = "";
                using (StringWriter sw = new StringWriter()) {
                    requestSerializer.Serialize(sw, req);
                    message = sw.ToString();
                }
                byte[] messageSent = Encoding.UTF8.GetBytes("<REQ>" + message + "<EOM>");
                int byteSent = clientSocket.Send(messageSent);
                byte[] messageReceived = new byte[16777216];
                int byteRecv = clientSocket.Receive(messageReceived);
                string received = Encoding.UTF8.GetString(messageReceived, 0, byteRecv);
                AddLogs(String.Format("Text received at {0} -> {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt"), ((received.Length > 64 || received.Contains("\n")) ? (received.Substring(0, (received.IndexOf("\n") > 64) ? 64 : received.IndexOf("\n")) + "...") : received)));
                if (received.Length >= 5 && received.Substring(0, 5).Equals("<ACK>"))
                {
                    AddLogs("Server responded.");
                    using (TextReader tr = new StringReader(received.Substring(5)))
                    {
                        res = (PlagCheck_Server.Response)responseSerializer.Deserialize(tr);
                    }
                }
                else
                {
                    AddLogs("Failed to obtain server\'s response.");
                }
            }
            catch (Exception exc)
            {
                AddLogs(exc.Message);
            }
            if (res != null)
            {
                try
                {
                    DisplayResultsForm display = new DisplayResultsForm(this, res, shortenedFileList);
                    display.Show();
                }
                catch (Exception exc) { AddLogs(exc.Message); }
            }
            clientSocket.Dispose();
        }

        public void AddSolution(PlagCheck_Server.Solution sol)
        {
            try
            {
                ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                ipAddress = ipHostInfo.AddressList[1];
                clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.SendBufferSize = 1048576;
                clientSocket.ReceiveBufferSize = 1048576;
                string ip = ipTextBox.Text;
                int port = int.Parse(portTextBox.Text);
                clientSocket.Connect(ip, port);
                string message = "";
                using (StringWriter sw = new StringWriter())
                {
                    solutionSerializer.Serialize(sw, sol);
                    message = sw.ToString();
                }
                byte[] messageSent = Encoding.UTF8.GetBytes("<ADD>" + message + "<EOM>");
                int byteSent = clientSocket.Send(messageSent);
                byte[] messageReceived = new byte[16];
                int byteRecv = clientSocket.Receive(messageReceived);
                string received = Encoding.UTF8.GetString(messageReceived, 0, byteRecv);
                AddLogs(String.Format("Text received at {0} -> {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt"), ((received.Length > 64 || received.Contains("\n")) ? (received.Substring(0, (received.IndexOf("\n") > 64) ? 64 : received.IndexOf("\n")) + "...") : received)));
                if (received.Length >= 5 && received.Substring(0, 5).Equals("<ACK>"))
                {
                    AddLogs("Addtion request sent successfully.");
                }
                else
                {
                    AddLogs("Failed to send addition request.");
                }
            }
            catch (Exception exc)
            {
                AddLogs(exc.Message);
            }
            clientSocket.Dispose();
        }

        private void ConnectServerButton_Click(object sender, EventArgs e)
        {
            reloadTimer.Start();
            AssureConnection();
        }

        private void DisconnectServerButton_Click(object sender, EventArgs e)
        {
            pList.Clear();
            if (clientSocket.Connected)
            {
                AddLogs("Successfully closed connection.");
                clientSocket.Close();
            }
            reloadTimer.Stop();
            connectServerButton.Enabled = true;
            disconnectServerButton.Enabled = false;
            problemPickBox.Items.Clear();
            problemPickBox.Enabled = false;
            langPickBox.Enabled = false;
        }

        private void ReloadTimer_Tick(object sender, EventArgs e)
        {
            AssureConnection();
        }

        private void PortTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && connectServerButton.Enabled) connectServerButton.PerformClick();
        }

        private void StatusBox_TextChanged(object sender, EventArgs e)
        {
            statusBox.SelectionStart = statusBox.Text.Length;
            statusBox.ScrollToCaret();
            statusBox.Refresh();
        }

        private void ProblemPickBox_TextChanged(object sender, EventArgs e)
        {
            if (problemPickBox.Text.Equals("")) { pickFolderButton.Enabled = false; return; }
            if (!langPickBox.Text.Equals("")) { pickFolderButton.Enabled = true; return; }
        }

        private void LangPickBox_TextChanged(object sender, EventArgs e)
        {
            if (langPickBox.Text.Equals("")) { pickFolderButton.Enabled = false; return; }
            if (!problemPickBox.Text.Equals("")) { 
                if (folderDirectory != null) DisplayFiles(folderDirectory, langPickBox.Text);
                pickFolderButton.Enabled = true; return; 
            }
        }

        private void PickFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult picked = pickFolderDialog.ShowDialog();
            if (picked != DialogResult.OK) return;
            if (string.IsNullOrWhiteSpace(pickFolderDialog.SelectedPath))
            {
                internalCheckButton.Enabled = false;
                globalCheckButton.Enabled = false;
                return;
            }
            folderDirectory = pickFolderDialog.SelectedPath;
            AddLogs(string.Format("Chosen directory \"{0}\" to lookup for solutions in {1}", folderDirectory, langPickBox.Text));
            DisplayFiles(folderDirectory, langPickBox.Text);
        }

        private void SolutionTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            int colId = e.ColumnIndex;
            if (rowId == -1 || colId == -1) return;
            if (colId == 2)
            {
                if (Convert.ToBoolean(solutionTable.Rows[rowId].Cells[colId].Value) == true)
                {
                    solutionTable.Rows[rowId].Cells[colId].Value = "false";
                }
                else if (Convert.ToBoolean(solutionTable.Rows[rowId].Cells[colId].Value) == false)
                {
                    solutionTable.Rows[rowId].Cells[colId].Value = "true";
                }
            }
        }

        private void PickFolderButton_EnabledChanged(object sender, EventArgs e)
        {
            if (!pickFolderButton.Enabled)
            {
                solutionTable.Rows.Clear();
                solutionTable.Refresh();
                internalCheckButton.Enabled = false;
                globalCheckButton.Enabled = false;
            }
        }

        private void InternalCheckButton_Click(object sender, EventArgs e)
        {
            Request req = new Request
            {
                ChosenProblem = PlagCheck_Server.Problem.Parse(problemPickBox.Text),
                ChosenLanguage = langPickBox.Text,
                IsInternalCheck = true
            };
            for (int i=0; i<fileList.Length; i++)
            {
                if (Convert.ToBoolean(solutionTable.Rows[i].Cells[2].Value) == true)
                {
                    req.SolutionList.Add(new PlagCheck_Server.Solution(-1, req.ChosenProblem.Id, req.ChosenLanguage, File.ReadAllText(fileList[i])));
                }
            }
            SendRequest(req);
        }

        private void GlobalCheckButton_Click(object sender, EventArgs e)
        {
            Request req = new Request
            {
                ChosenProblem = PlagCheck_Server.Problem.Parse(problemPickBox.Text),
                ChosenLanguage = langPickBox.Text,
                IsInternalCheck = false
            };
            for (int i = 0; i < fileList.Length; i++)
            {
                if (Convert.ToBoolean(solutionTable.Rows[i].Cells[2].Value) == true)
                {
                    req.SolutionList.Add(new PlagCheck_Server.Solution(-1, req.ChosenProblem.Id, req.ChosenLanguage, File.ReadAllText(fileList[i])));
                }
            }
            SendRequest(req);
        }
    }
}
