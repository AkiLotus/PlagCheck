using System;
using System.Windows.Forms;

namespace PlagCheck_Server
{
    partial class AddProblemForm : Form
    {
        private readonly ServerMainForm sourceForm;
        public AddProblemForm()
        {
            InitializeComponent();
        }
        public AddProblemForm(ServerMainForm srcForm)
        {
            sourceForm = srcForm;
            InitializeComponent();
        }

        private void AddProblemForm_Load(object sender, EventArgs e)
        {
            sourceForm.Enabled = false;
        }

        private void AddProblemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceForm.Enabled = true;
            sourceForm.UpdateTable();
        }

        private void AddProblemButton_Click(object sender, EventArgs e)
        {
            int id = sourceForm.Pdao.GetNextProblemId();
            string name;
            float ptl, pml;
            try
            {
                name = this.pnameBox.Text;
                ptl = float.Parse(this.ptlBox.Text);
                pml = float.Parse(this.pmlBox.Text);
                sourceForm.Pdao.AddProblem(new Problem(id, name, ptl, pml));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            DialogResult dr = MessageBox.Show("Addition successful!");
            sourceForm.AddStatus(String.Format("Successfully added problem {0}.", name));
            sourceForm.InitializeSolution_ProPicker();
            if (dr == DialogResult.OK) this.Close();
        }
    }
}
