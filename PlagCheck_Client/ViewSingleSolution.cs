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
    public partial class ViewSingleSolution : Form
    {
        DisplayResultsForm sourceForm;
        PlagCheck_Server.Solution sourceSolution;
        public ViewSingleSolution(DisplayResultsForm frm, PlagCheck_Server.Solution sol)
        {
            sourceForm = frm; sourceSolution = sol;
            InitializeComponent();
            contentBox.Text = sourceSolution.Content.Replace("\r\n", "\n").Replace("\n", "\r\n");
        }

        private void ViewSingleSolution_Load(object sender, EventArgs e)
        {
            sourceForm.Enabled = false;
        }

        private void ViewSingleSolution_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceForm.Enabled = true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
