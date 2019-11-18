using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlagCheck_Client
{
    public partial class DisplayResultsForm : Form
    {
        private readonly ClientMainForm sourceForm;
        private PlagCheck_Server.Response sourceResponse;
        private double rate = 0;
        private string[] fileList;

        private class AdjacencyListHelper : IComparer, IComparer<List<KeyValuePair<double, int>>>
        {
            public int Compare(List<KeyValuePair<double, int>> a, List<KeyValuePair<double, int>> b)
            {
                int n = (a.Count < b.Count) ? a.Count : b.Count;
                for (int i = 0; i < n; i++)
                {
                    if (a[i].Key == b[i].Key) continue;
                    return -a[i].Key.CompareTo(b[i].Key);
                }
                if (a.Count > n) return -1;
                if (b.Count > n) return +1;
                return 0;
            }

            int IComparer.Compare(object x, object y)
            {
                return Compare((List<KeyValuePair<double, int>>)x, (List<KeyValuePair<double, int>>)y);
            }
        }

        public PlagCheck_Server.Response SourceResponse { get => sourceResponse; set => sourceResponse = value; }
        public double Rate { get => rate; set => rate = value; }
        public string[] FileList { get => fileList; set => fileList = value; }

        public void AnalyzeResponse()
        {

            int N = sourceResponse.SimilarityMatrix.Count;
            int LN = SourceResponse.SourceRequest.SolutionList.Count;
            int total = N * (N - 1) / 2;
            double avg = 0, mn = 101, mx = -1;
            int total_100 = 0, total_80 = 0, total_60 = 0, total_40 = 0, total_20 = 0;
            for (int i=0; i<LN; i++)
            {
                for (int j=i+1; j<N; j++)
                {
                    avg += sourceResponse.SimilarityMatrix[i][j] / total;
                    mx = (mx < sourceResponse.SimilarityMatrix[i][j]) ? sourceResponse.SimilarityMatrix[i][j] : mx;
                    mn = (mn > sourceResponse.SimilarityMatrix[i][j]) ? sourceResponse.SimilarityMatrix[i][j] : mn;
                    if (sourceResponse.SimilarityMatrix[i][j] > 80) total_100 += 1;
                    else if (sourceResponse.SimilarityMatrix[i][j] > 60) total_80 += 1;
                    else if (sourceResponse.SimilarityMatrix[i][j] > 40) total_60 += 1;
                    else if (sourceResponse.SimilarityMatrix[i][j] > 20) total_40 += 1;
                    else total_20 += 1;
                }
            }
            int maxTotal = new[] { total_100, total_80, total_60, total_40, total_20 }.Max();
            countBox_100.Text = total_100.ToString();
            countBox_80.Text = total_80.ToString();
            countBox_60.Text = total_60.ToString();
            countBox_40.Text = total_40.ToString();
            countBox_20.Text = total_20.ToString();
            percentileBar_100.Value = (total_100 * 10000) / maxTotal;
            percentileBar_80.Value = (total_80 * 10000) / maxTotal;
            percentileBar_60.Value = (total_60 * 10000) / maxTotal;
            percentileBar_40.Value = (total_40 * 10000) / maxTotal;
            percentileBar_20.Value = (total_20 * 10000) / maxTotal;

            overviewBox.Text = "";
            overviewBox.Text += string.Format("Language: {0}\r\n", sourceResponse.SourceRequest.ChosenLanguage);
            overviewBox.Text += string.Format("Local submission counts: {0}\r\n", sourceResponse.SourceRequest.SolutionList.Count);
            overviewBox.Text += string.Format("Server submission counts: {0}\r\n", sourceResponse.ServerSolutionList.Count);
            overviewBox.Text += string.Format("Total submission counts: {0}\r\n", N);
            overviewBox.Text += string.Format("Maximum similarity: {0:00.00}%\r\n", mx);
            overviewBox.Text += string.Format("Minimum similarity: {0:00.00}%\r\n", mn);
            overviewBox.Text += string.Format("Average similarity: {0:00.00}%\r\n", avg);

            List<List<KeyValuePair<double, int>>> adjacencyList = new List<List<KeyValuePair<double, int>>>();
            for (int i = 0; i < LN; i++) adjacencyList.Add(new List<KeyValuePair<double, int>>());
            int maxAdjacencySize = 0;
            for (int i = 0; i < LN; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (sourceResponse.SimilarityMatrix[i][j] >= rate || i == j)
                    {
                        adjacencyList[i].Add(new KeyValuePair<double, int>((i == j) ? -1.0 : sourceResponse.SimilarityMatrix[i][j], j));
                        maxAdjacencySize = (maxAdjacencySize < adjacencyList[i].Count - 1) ? adjacencyList[i].Count - 1 : maxAdjacencySize;
                    }
                }
            }
            for (int i = 0; i < LN; i++)
            {
                adjacencyList[i].Sort((x, y) => -x.Key.CompareTo(y.Key));
            }
            adjacencyList.Sort(new AdjacencyListHelper());

            var col1 = new DataGridViewTextBoxColumn
            {
                HeaderText = "File name",
                Name = "FileName",
                Width = 64
            };
            var col2 = new DataGridViewTextBoxColumn
            {
                HeaderText = "File size",
                Name = "FileSize",
                Width = 48
    };
            var col3 = new DataGridViewButtonColumn
            {
                HeaderText = "Add solution",
                Name = "AddButton",
                Width = 64
            };

            plagiarismGrid.Rows.Clear();
            plagiarismGrid.Columns.Clear();
            plagiarismGrid.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3 });
            for (int i=1; i<=maxAdjacencySize; i++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = string.Format("#{0}", i),
                    Name = string.Format("Candidate{0}", i),
                    Width = 64
                };
                plagiarismGrid.Columns.Add(col);
            }
            plagiarismGrid.Rows.Add(LN);
            for (int i=0; i<LN; i++)
            {
                int id = adjacencyList[i][adjacencyList[i].Count - 1].Value;
                plagiarismGrid.Rows[i].Cells[0].Value = fileList[id].Clone();
                plagiarismGrid.Rows[i].Cells[1].Value = sourceResponse.SourceRequest.SolutionList[id].Content.Length;
                plagiarismGrid.Rows[i].Cells[2].Value = "Add";
                int x = 3, index = 0;
                while (x < 3+maxAdjacencySize)
                {
                    if (index >= adjacencyList[i].Count)
                    {
                        plagiarismGrid.Rows[i].Cells[x].Value = "N/A";
                        x += 1; continue;
                    }
                    int j = adjacencyList[i][index].Value;
                    if (j == id) { index++; continue; }
                    string cellLabel = "";
                    if (j < LN) cellLabel += fileList[j];
                    else cellLabel += string.Format("sv_{0}.{1}", sourceResponse.ServerSolutionList[j - LN].Id, (sourceResponse.ServerSolutionList[j - LN].Lang.Equals("C++")) ? "cpp" : "java");
                    cellLabel += "\r\n";
                    cellLabel += string.Format("({0:00.00}%)", sourceResponse.SimilarityMatrix[id][j]);
                    plagiarismGrid.Rows[i].Cells[x].Value = cellLabel;
                    x += 1; index += 1;
                }
            }
            plagiarismGrid.Refresh();
        }
        public DisplayResultsForm()
        {
            InitializeComponent();
            sourceResponse = new PlagCheck_Server.Response();
            AnalyzeResponse();
        }
        public DisplayResultsForm(ClientMainForm src, PlagCheck_Server.Response res)
        {
            sourceForm = src;
            InitializeComponent();
            sourceResponse = res;
            AnalyzeResponse();
        }
        public DisplayResultsForm(ClientMainForm src, PlagCheck_Server.Response res, string[] filename)
        {
            sourceForm = src;
            InitializeComponent();
            sourceResponse = res;
            fileList = filename;
            AnalyzeResponse();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try {
                rate = double.Parse(simRateBox.Text);
                AnalyzeResponse();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid numeric format!");
                return;
            }
            if (rate < 0 || rate > 100)
            {
                MessageBox.Show("Invalid rate - it must be in between 0 and 100!");
                return;
            }
        }

        private void DisplayResultsForm_Load(object sender, EventArgs e)
        {
            sourceForm.Enabled = false;
        }

        private void DisplayResultsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceForm.Enabled = true;
        }

        private void PlagiarismGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            int colId = e.ColumnIndex;
            if (rowId == -1) return;

            PlagCheck_Server.Solution srcSolution = new PlagCheck_Server.Solution();
            PlagCheck_Server.Solution similarSolution = new PlagCheck_Server.Solution();
            string srcName = "null", similarName = "null";
            int srcId = -1, similarId = -1;
            float similarity = -1;
            for (int i = 0; i < fileList.Length; i++)
            {
                if (plagiarismGrid.Rows[rowId].Cells[0].Value.ToString().Equals(fileList[i]))
                {
                    srcSolution = sourceResponse.SourceRequest.SolutionList[i];
                    srcName = fileList[i]; srcId = i;
                }
            }
            for (int i = 0; i < SourceResponse.ServerSolutionList.Count; i++)
            {
                if (plagiarismGrid.Rows[rowId].Cells[0].Value.ToString().Equals(string.Format("sv_{0}.{1}", sourceResponse.ServerSolutionList[i].Id, (sourceResponse.ServerSolutionList[i].Lang.Equals("C++")) ? "cpp" : "java")))
                {
                    srcSolution = sourceResponse.ServerSolutionList[i];
                    srcName = string.Format("sv_{0}.{1}", sourceResponse.ServerSolutionList[i].Id, (sourceResponse.ServerSolutionList[i].Lang.Equals("C++")) ? "cpp" : "java");
                    srcId = SourceResponse.SourceRequest.SolutionList.Count + i;
                }
            }

            if (colId == 0)
            {
                // choose solution
                ViewSingleSolution sglForm = new ViewSingleSolution(this, srcSolution);
                sglForm.Show();
            }
            else if (colId == 2)
            {
                // add solution
                DialogResult dr = MessageBox.Show(string.Format("Are you sure to add the solution {0}?", plagiarismGrid.Rows[rowId].Cells[0].Value.ToString()), "Confirm addition", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    sourceForm.Enabled = true;
                    sourceForm.AddSolution(srcSolution);
                    sourceForm.Enabled = false;
                }
            }
            else if (colId > 2)
            {
                // choose 2 solutions
                if (plagiarismGrid.Rows[rowId].Cells[colId].Value.ToString().Equals("N/A"))
                {
                    MessageBox.Show("Nothing to see here!");
                }
                else
                {
                    for (int i = 0; i < fileList.Length; i++)
                    {
                        if (plagiarismGrid.Rows[rowId].Cells[colId].Value.ToString().Contains(fileList[i]))
                        {
                            similarSolution = sourceResponse.SourceRequest.SolutionList[i];
                            similarName = fileList[i]; similarId = i;
                            similarity = sourceResponse.SimilarityMatrix[srcId][similarId];
                        }
                    }
                    for (int i = 0; i < SourceResponse.ServerSolutionList.Count; i++)
                    {
                        if (plagiarismGrid.Rows[rowId].Cells[colId].Value.ToString().Contains(string.Format("sv_{0}.{1}", sourceResponse.ServerSolutionList[i].Id, (sourceResponse.ServerSolutionList[i].Lang.Equals("C++")) ? "cpp" : "java")))
                        {
                            similarSolution = sourceResponse.ServerSolutionList[i];
                            similarName = string.Format("sv_{0}.{1}", sourceResponse.ServerSolutionList[i].Id, (sourceResponse.ServerSolutionList[i].Lang.Equals("C++")) ? "cpp" : "java");
                            similarId = sourceResponse.SourceRequest.SolutionList.Count + i;
                            similarity = sourceResponse.SimilarityMatrix[srcId][similarId];
                        }
                    }
                }
                ViewDoubleSolutions dblForm = new ViewDoubleSolutions(this, srcSolution, similarSolution, srcName, similarName, similarity);
                dblForm.Show();
            }
        }

        private void SimRateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) refreshButton.PerformClick();
        }
    }
}
