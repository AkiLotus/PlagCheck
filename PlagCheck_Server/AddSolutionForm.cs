using System.Collections.Generic;
using System.Windows.Forms;

namespace PlagCheck_Server
{
    partial class AddSolutionForm : Form
    {
        private readonly ServerMainForm sourceForm;
        public AddSolutionForm()
        {
            InitializeComponent();
        }
        public AddSolutionForm(ServerMainForm srcForm)
        {
            sourceForm = srcForm;
            InitializeComponent();
            for (int i = 0; i < sourceForm.PList.Count; i++)
            {
                problemPickBox.Items.Add(sourceForm.PList[i].ToString);
            }
        }

        private void AddSolutionForm_Load(object sender, System.EventArgs e)
        {
            sourceForm.Enabled = false;
        }

        private void AddSolutionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceForm.Enabled = true;
            sourceForm.ResetSolPicker();
        }

        private void AddSolutionButton_Click(object sender, System.EventArgs e)
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
            int id = sourceForm.Sdao.GetNextSolutionId();
            int pid = Problem.Parse(problemPickBox.Text).Id;
            string lang = languagePickBox.Text;
            string content = contentBox.Text.Replace("\r\n", "\n");
            sourceForm.Sdao.AddSolution(new Solution(id, pid, lang, content));
            DialogResult dr = MessageBox.Show("Addition successful!");
            sourceForm.AddStatus(string.Format("Successfully added solution #{0}.", id));
            if (dr == DialogResult.OK) this.Close();
        }
    }
}
