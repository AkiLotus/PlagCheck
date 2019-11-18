using System;
using System.Windows.Forms;

namespace PlagCheck_Server
{
    partial class EditProblemForm : Form
    {
        private readonly ServerMainForm sourceForm;
        private readonly Problem oldProblem;
        public EditProblemForm()
        {
            InitializeComponent();
        }
        public EditProblemForm(ServerMainForm srcForm, Problem oldProb)
        {
            sourceForm = srcForm;
            oldProblem = oldProb;
            InitializeComponent();
            pnameBox.Text = oldProb.Name;
            ptlBox.Text = oldProb.TimeLimit.ToString();
            pmlBox.Text = oldProb.MemoryLimit.ToString();
        }

        private void EditProblemForm_Load(object sender, EventArgs e)
        {
            sourceForm.Enabled = false;
        }

        private void EditProblemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceForm.Enabled = true;
            sourceForm.UpdateTable();
        }

        private void EditProblemButton_Click(object sender, EventArgs e)
        {
            int id = oldProblem.Id;
            string name;
            float ptl, pml;
            try
            {
                name = this.pnameBox.Text;
                ptl = float.Parse(this.ptlBox.Text);
                pml = float.Parse(this.pmlBox.Text);
                sourceForm.Pdao.EditProblem(oldProblem, new Problem(id, name, ptl, pml));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            DialogResult dr = MessageBox.Show("Edit successful!");
            sourceForm.AddStatus(String.Format("Successfully edited problem with id #{0}.", id));
            sourceForm.InitializeSolution_ProPicker();
            if (dr == DialogResult.OK) this.Close();
        }
    }
}
