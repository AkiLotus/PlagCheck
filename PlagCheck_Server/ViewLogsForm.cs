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
    public partial class ViewLogsForm : Form
    {
        ServerMainForm srcForm;
        public ViewLogsForm(ServerMainForm src)
        {
            srcForm = src;
            InitializeComponent();
            contentBox.Text = srcForm.FullLogs;
        }

        private void ViewLogsForm_Load(object sender, EventArgs e)
        {
            srcForm.Enabled = false;
        }

        private void ViewLogsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            srcForm.Enabled = true;
        }
    }
}
