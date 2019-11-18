using System;
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
    public partial class ViewDoubleSolutions : Form
    {
        DisplayResultsForm sourceForm;
        PlagCheck_Server.Solution sourceSolution1, sourceSolution2;
        public ViewDoubleSolutions(DisplayResultsForm frm, PlagCheck_Server.Solution sol1, PlagCheck_Server.Solution sol2, string sol1Name, string sol2Name, float similarity)
        {
            sourceForm = frm; sourceSolution1 = sol1; sourceSolution2 = sol2;
            InitializeComponent();
            contentBox1.Text = sourceSolution1.Content.Replace("\r\n", "\n").Replace("\n", "\r\n");
            contentBox2.Text = sourceSolution2.Content.Replace("\r\n", "\n").Replace("\n", "\r\n");
            solNameBox1.Text = sol1Name; solNameBox2.Text = sol2Name;
            similarityBox.Text = string.Format("Similarity percentage: {0:00.00}%", similarity);
        }

        private void ViewDoubleSolutions_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceForm.Enabled = true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewDoubleSolutions_Load(object sender, EventArgs e)
        {
            sourceForm.Enabled = false;
        }
    }
}
