using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlagCheck_Server
{
    partial class EditSolutionForm : Form
    {
        private readonly ServerMainForm sourceForm;
        private readonly Solution oldSolution;
        public EditSolutionForm()
        {
            InitializeComponent();
        }
        public EditSolutionForm(ServerMainForm srcForm, Solution oldSol)
        {
            sourceForm = srcForm;
            oldSolution = oldSol;
            InitializeComponent();
            for (int i = 0; i < sourceForm.PList.Count; i++)
            {
                problemPickBox.Items.Add(sourceForm.PList[i].ToString);
            }
            problemPickBox.Text = sourceForm.Pdao.GetProblem(oldSolution.ProblemId).ToString;
            languagePickBox.Text = oldSol.Lang;
            contentBox.Text = oldSol.Content;
            contentBox.Text = contentBox.Text.Replace("\r\n", "\n");
            contentBox.Text = contentBox.Text.Replace("\n", "\r\n");
        }

        private void EditSolutionForm_Load(object sender, EventArgs e)
        {
            sourceForm.Enabled = false;
        }

        private void EditSolutionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceForm.Enabled = true;
            sourceForm.ResetSolPicker();
        }

        private void EditSolutionButton_Click(object sender, EventArgs e)
        {
            if (problemPickBox.Text == "")
            {
                MessageBox.Show("Choose a problem!");
                return;
            }
            if (languagePickBox.Text == "")
            {
                MessageBox.Show("Choose a language!");
                return;
            }
            int id = oldSolution.Id;
            int pid = Problem.Parse(problemPickBox.Text).Id;
            string lang = languagePickBox.Text;
            string content = contentBox.Text.Replace("\r\n", "\n");
            sourceForm.Sdao.EditSolution(oldSolution, new Solution(id, pid, lang, content));
            DialogResult dr = MessageBox.Show("Edition successful!");
            sourceForm.AddStatus(string.Format("Successfully edited solution #{0}.", id));
            if (dr == DialogResult.OK) this.Close();
        }
    }
}
