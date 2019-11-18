namespace PlagCheck_Server
{
    partial class ServerMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.startServerButton = new System.Windows.Forms.Button();
            this.stopServerButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.problemTab = new System.Windows.Forms.TabPage();
            this.addProblemButton = new System.Windows.Forms.Button();
            this.problemTable = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptlColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmlColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peditColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pdelColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.solutionTab = new System.Windows.Forms.TabPage();
            this.deleteSolutionButton = new System.Windows.Forms.Button();
            this.editSolutionButton = new System.Windows.Forms.Button();
            this.solutionPreviewBox = new System.Windows.Forms.TextBox();
            this.addSolutionButton = new System.Windows.Forms.Button();
            this.solutionPickBox = new System.Windows.Forms.ComboBox();
            this.solutionPickLabel = new System.Windows.Forms.Label();
            this.problemPickBox = new System.Windows.Forms.ComboBox();
            this.problemPickLabel = new System.Windows.Forms.Label();
            this.viewLogsButton = new System.Windows.Forms.Button();
            this.setJPlagButton = new System.Windows.Forms.Button();
            this.jplagOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.reloadTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.problemTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.problemTable)).BeginInit();
            this.solutionTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(12, 9);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(47, 6);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(167, 20);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortTextBox_KeyPress);
            // 
            // startServerButton
            // 
            this.startServerButton.Location = new System.Drawing.Point(220, 4);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(75, 23);
            this.startServerButton.TabIndex = 2;
            this.startServerButton.Text = "Start";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // stopServerButton
            // 
            this.stopServerButton.Enabled = false;
            this.stopServerButton.Location = new System.Drawing.Point(301, 4);
            this.stopServerButton.Name = "stopServerButton";
            this.stopServerButton.Size = new System.Drawing.Size(75, 23);
            this.stopServerButton.TabIndex = 3;
            this.stopServerButton.Text = "Stop";
            this.stopServerButton.UseVisualStyleBackColor = true;
            this.stopServerButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StopServerButton_MouseClick);
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(12, 334);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBox.Size = new System.Drawing.Size(560, 65);
            this.statusBox.TabIndex = 4;
            this.statusBox.TextChanged += new System.EventHandler(this.StatusBox_TextChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.problemTab);
            this.tabControl.Controls.Add(this.solutionTab);
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(12, 33);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(560, 295);
            this.tabControl.TabIndex = 5;
            // 
            // problemTab
            // 
            this.problemTab.Controls.Add(this.addProblemButton);
            this.problemTab.Controls.Add(this.problemTable);
            this.problemTab.Location = new System.Drawing.Point(4, 22);
            this.problemTab.Name = "problemTab";
            this.problemTab.Padding = new System.Windows.Forms.Padding(3);
            this.problemTab.Size = new System.Drawing.Size(552, 269);
            this.problemTab.TabIndex = 0;
            this.problemTab.Text = "Problems Manager";
            this.problemTab.UseVisualStyleBackColor = true;
            // 
            // addProblemButton
            // 
            this.addProblemButton.Location = new System.Drawing.Point(219, 240);
            this.addProblemButton.Name = "addProblemButton";
            this.addProblemButton.Size = new System.Drawing.Size(115, 23);
            this.addProblemButton.TabIndex = 1;
            this.addProblemButton.Text = "Add a new problem";
            this.addProblemButton.UseVisualStyleBackColor = true;
            this.addProblemButton.Click += new System.EventHandler(this.AddProblemButton_Click);
            // 
            // problemTable
            // 
            this.problemTable.AllowUserToAddRows = false;
            this.problemTable.AllowUserToDeleteRows = false;
            this.problemTable.AllowUserToOrderColumns = true;
            this.problemTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.problemTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.pnameColumn,
            this.ptlColumn,
            this.pmlColumn,
            this.peditColumn,
            this.pdelColumn});
            this.problemTable.Location = new System.Drawing.Point(16, 12);
            this.problemTable.Name = "problemTable";
            this.problemTable.ReadOnly = true;
            this.problemTable.Size = new System.Drawing.Size(521, 222);
            this.problemTable.TabIndex = 0;
            this.problemTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProblemTable_CellContentClick);
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "ID";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Width = 32;
            // 
            // pnameColumn
            // 
            this.pnameColumn.HeaderText = "Name";
            this.pnameColumn.Name = "pnameColumn";
            this.pnameColumn.ReadOnly = true;
            this.pnameColumn.Width = 176;
            // 
            // ptlColumn
            // 
            this.ptlColumn.HeaderText = "Time limit";
            this.ptlColumn.Name = "ptlColumn";
            this.ptlColumn.ReadOnly = true;
            this.ptlColumn.Width = 75;
            // 
            // pmlColumn
            // 
            this.pmlColumn.HeaderText = "Memory limit";
            this.pmlColumn.Name = "pmlColumn";
            this.pmlColumn.ReadOnly = true;
            this.pmlColumn.Width = 90;
            // 
            // peditColumn
            // 
            this.peditColumn.HeaderText = "Edit";
            this.peditColumn.Name = "peditColumn";
            this.peditColumn.ReadOnly = true;
            this.peditColumn.Width = 36;
            // 
            // pdelColumn
            // 
            this.pdelColumn.HeaderText = "Delete";
            this.pdelColumn.Name = "pdelColumn";
            this.pdelColumn.ReadOnly = true;
            this.pdelColumn.Width = 48;
            // 
            // solutionTab
            // 
            this.solutionTab.Controls.Add(this.deleteSolutionButton);
            this.solutionTab.Controls.Add(this.editSolutionButton);
            this.solutionTab.Controls.Add(this.solutionPreviewBox);
            this.solutionTab.Controls.Add(this.addSolutionButton);
            this.solutionTab.Controls.Add(this.solutionPickBox);
            this.solutionTab.Controls.Add(this.solutionPickLabel);
            this.solutionTab.Controls.Add(this.problemPickBox);
            this.solutionTab.Controls.Add(this.problemPickLabel);
            this.solutionTab.Location = new System.Drawing.Point(4, 22);
            this.solutionTab.Name = "solutionTab";
            this.solutionTab.Padding = new System.Windows.Forms.Padding(3);
            this.solutionTab.Size = new System.Drawing.Size(552, 269);
            this.solutionTab.TabIndex = 1;
            this.solutionTab.Text = "Solutions Manager";
            this.solutionTab.UseVisualStyleBackColor = true;
            // 
            // deleteSolutionButton
            // 
            this.deleteSolutionButton.Enabled = false;
            this.deleteSolutionButton.Location = new System.Drawing.Point(429, 240);
            this.deleteSolutionButton.Name = "deleteSolutionButton";
            this.deleteSolutionButton.Size = new System.Drawing.Size(90, 23);
            this.deleteSolutionButton.TabIndex = 7;
            this.deleteSolutionButton.Text = "Delete solution";
            this.deleteSolutionButton.UseVisualStyleBackColor = true;
            this.deleteSolutionButton.Click += new System.EventHandler(this.DeleteSolutionButton_Click);
            // 
            // editSolutionButton
            // 
            this.editSolutionButton.Enabled = false;
            this.editSolutionButton.Location = new System.Drawing.Point(246, 240);
            this.editSolutionButton.Name = "editSolutionButton";
            this.editSolutionButton.Size = new System.Drawing.Size(75, 23);
            this.editSolutionButton.TabIndex = 6;
            this.editSolutionButton.Text = "Edit solution";
            this.editSolutionButton.UseVisualStyleBackColor = true;
            this.editSolutionButton.Click += new System.EventHandler(this.EditSolutionButton_Click);
            // 
            // solutionPreviewBox
            // 
            this.solutionPreviewBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solutionPreviewBox.Location = new System.Drawing.Point(9, 33);
            this.solutionPreviewBox.Multiline = true;
            this.solutionPreviewBox.Name = "solutionPreviewBox";
            this.solutionPreviewBox.ReadOnly = true;
            this.solutionPreviewBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.solutionPreviewBox.Size = new System.Drawing.Size(537, 201);
            this.solutionPreviewBox.TabIndex = 5;
            this.solutionPreviewBox.WordWrap = false;
            // 
            // addSolutionButton
            // 
            this.addSolutionButton.Location = new System.Drawing.Point(31, 240);
            this.addSolutionButton.Name = "addSolutionButton";
            this.addSolutionButton.Size = new System.Drawing.Size(113, 23);
            this.addSolutionButton.TabIndex = 4;
            this.addSolutionButton.Text = "Add a new solution";
            this.addSolutionButton.UseVisualStyleBackColor = true;
            this.addSolutionButton.Click += new System.EventHandler(this.AddSolutionButton_Click);
            // 
            // solutionPickBox
            // 
            this.solutionPickBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solutionPickBox.FormattingEnabled = true;
            this.solutionPickBox.Location = new System.Drawing.Point(344, 6);
            this.solutionPickBox.Name = "solutionPickBox";
            this.solutionPickBox.Size = new System.Drawing.Size(202, 21);
            this.solutionPickBox.TabIndex = 3;
            this.solutionPickBox.TextChanged += new System.EventHandler(this.SolutionPickBox_TextChanged);
            // 
            // solutionPickLabel
            // 
            this.solutionPickLabel.AutoSize = true;
            this.solutionPickLabel.Location = new System.Drawing.Point(290, 9);
            this.solutionPickLabel.Name = "solutionPickLabel";
            this.solutionPickLabel.Size = new System.Drawing.Size(48, 13);
            this.solutionPickLabel.TabIndex = 2;
            this.solutionPickLabel.Text = "Solution:";
            // 
            // problemPickBox
            // 
            this.problemPickBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.problemPickBox.FormattingEnabled = true;
            this.problemPickBox.Location = new System.Drawing.Point(60, 6);
            this.problemPickBox.Name = "problemPickBox";
            this.problemPickBox.Size = new System.Drawing.Size(224, 21);
            this.problemPickBox.TabIndex = 1;
            this.problemPickBox.TextChanged += new System.EventHandler(this.ProblemPickBox_TextChanged);
            // 
            // problemPickLabel
            // 
            this.problemPickLabel.AutoSize = true;
            this.problemPickLabel.Location = new System.Drawing.Point(6, 9);
            this.problemPickLabel.Name = "problemPickLabel";
            this.problemPickLabel.Size = new System.Drawing.Size(48, 13);
            this.problemPickLabel.TabIndex = 0;
            this.problemPickLabel.Text = "Problem:";
            // 
            // viewLogsButton
            // 
            this.viewLogsButton.Location = new System.Drawing.Point(382, 4);
            this.viewLogsButton.Name = "viewLogsButton";
            this.viewLogsButton.Size = new System.Drawing.Size(75, 23);
            this.viewLogsButton.TabIndex = 6;
            this.viewLogsButton.Text = "View logs";
            this.viewLogsButton.UseVisualStyleBackColor = true;
            this.viewLogsButton.Click += new System.EventHandler(this.viewLogsButton_Click);
            // 
            // setJPlagButton
            // 
            this.setJPlagButton.Location = new System.Drawing.Point(463, 4);
            this.setJPlagButton.Name = "setJPlagButton";
            this.setJPlagButton.Size = new System.Drawing.Size(105, 23);
            this.setJPlagButton.TabIndex = 7;
            this.setJPlagButton.Text = "Set JPlag location";
            this.setJPlagButton.UseVisualStyleBackColor = true;
            this.setJPlagButton.Click += new System.EventHandler(this.setJPlagButton_Click);
            // 
            // jplagOpenFileDialog
            // 
            this.jplagOpenFileDialog.DefaultExt = "jar";
            // 
            // reloadTimer
            // 
            this.reloadTimer.Interval = 500;
            this.reloadTimer.Tick += new System.EventHandler(this.reloadTimer_Tick);
            // 
            // ServerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.setJPlagButton);
            this.Controls.Add(this.viewLogsButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.stopServerButton);
            this.Controls.Add(this.startServerButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ServerMainForm";
            this.Text = "Source Code Analyzer by Ivy (Server)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerMainForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.problemTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.problemTable)).EndInit();
            this.solutionTab.ResumeLayout(false);
            this.solutionTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.Button stopServerButton;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage problemTab;
        private System.Windows.Forms.TabPage solutionTab;
        private System.Windows.Forms.Button addProblemButton;
        private System.Windows.Forms.DataGridView problemTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ptlColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmlColumn;
        private System.Windows.Forms.DataGridViewButtonColumn peditColumn;
        private System.Windows.Forms.DataGridViewButtonColumn pdelColumn;
        private System.Windows.Forms.TextBox solutionPreviewBox;
        private System.Windows.Forms.Button addSolutionButton;
        private System.Windows.Forms.ComboBox solutionPickBox;
        private System.Windows.Forms.Label solutionPickLabel;
        private System.Windows.Forms.ComboBox problemPickBox;
        private System.Windows.Forms.Label problemPickLabel;
        private System.Windows.Forms.Button deleteSolutionButton;
        private System.Windows.Forms.Button editSolutionButton;
        private System.Windows.Forms.Button viewLogsButton;
        private System.Windows.Forms.Button setJPlagButton;
        private System.Windows.Forms.OpenFileDialog jplagOpenFileDialog;
        private System.Windows.Forms.Timer reloadTimer;
    }
}

