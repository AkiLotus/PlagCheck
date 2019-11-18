namespace PlagCheck_Client
{
    partial class ClientMainForm
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
            this.statusBox = new System.Windows.Forms.TextBox();
            this.disconnectServerButton = new System.Windows.Forms.Button();
            this.connectServerButton = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.reloadTimer = new System.Windows.Forms.Timer(this.components);
            this.problemPickBox = new System.Windows.Forms.ComboBox();
            this.problemPickLabel = new System.Windows.Forms.Label();
            this.langPickLabel = new System.Windows.Forms.Label();
            this.langPickBox = new System.Windows.Forms.ComboBox();
            this.pickFolderButton = new System.Windows.Forms.Button();
            this.pickFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.solutionTable = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chosen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.internalCheckButton = new System.Windows.Forms.Button();
            this.globalCheckButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.solutionTable)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(12, 338);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBox.Size = new System.Drawing.Size(560, 65);
            this.statusBox.TabIndex = 9;
            this.statusBox.TextChanged += new System.EventHandler(this.StatusBox_TextChanged);
            // 
            // disconnectServerButton
            // 
            this.disconnectServerButton.Enabled = false;
            this.disconnectServerButton.Location = new System.Drawing.Point(497, 7);
            this.disconnectServerButton.Name = "disconnectServerButton";
            this.disconnectServerButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectServerButton.TabIndex = 8;
            this.disconnectServerButton.Text = "Disconnect";
            this.disconnectServerButton.UseVisualStyleBackColor = true;
            this.disconnectServerButton.Click += new System.EventHandler(this.DisconnectServerButton_Click);
            // 
            // connectServerButton
            // 
            this.connectServerButton.Location = new System.Drawing.Point(416, 7);
            this.connectServerButton.Name = "connectServerButton";
            this.connectServerButton.Size = new System.Drawing.Size(75, 23);
            this.connectServerButton.TabIndex = 7;
            this.connectServerButton.Text = "Connect";
            this.connectServerButton.UseVisualStyleBackColor = true;
            this.connectServerButton.Click += new System.EventHandler(this.ConnectServerButton_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(301, 9);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(109, 20);
            this.portTextBox.TabIndex = 6;
            this.portTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortTextBox_KeyPress);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(266, 12);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 5;
            this.portLabel.Text = "Port:";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(9, 12);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(54, 13);
            this.ipLabel.TabIndex = 10;
            this.ipLabel.Text = "Server IP:";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(69, 9);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(191, 20);
            this.ipTextBox.TabIndex = 2;
            // 
            // reloadTimer
            // 
            this.reloadTimer.Interval = 30000;
            this.reloadTimer.Tick += new System.EventHandler(this.ReloadTimer_Tick);
            // 
            // problemPickBox
            // 
            this.problemPickBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.problemPickBox.Enabled = false;
            this.problemPickBox.FormattingEnabled = true;
            this.problemPickBox.Location = new System.Drawing.Point(63, 35);
            this.problemPickBox.Name = "problemPickBox";
            this.problemPickBox.Size = new System.Drawing.Size(232, 21);
            this.problemPickBox.TabIndex = 12;
            this.problemPickBox.SelectedIndexChanged += new System.EventHandler(this.ProblemPickBox_TextChanged);
            this.problemPickBox.TextUpdate += new System.EventHandler(this.ProblemPickBox_TextChanged);
            this.problemPickBox.SelectedValueChanged += new System.EventHandler(this.ProblemPickBox_TextChanged);
            this.problemPickBox.EnabledChanged += new System.EventHandler(this.ProblemPickBox_TextChanged);
            this.problemPickBox.TextChanged += new System.EventHandler(this.ProblemPickBox_TextChanged);
            // 
            // problemPickLabel
            // 
            this.problemPickLabel.AutoSize = true;
            this.problemPickLabel.Location = new System.Drawing.Point(9, 38);
            this.problemPickLabel.Name = "problemPickLabel";
            this.problemPickLabel.Size = new System.Drawing.Size(48, 13);
            this.problemPickLabel.TabIndex = 11;
            this.problemPickLabel.Text = "Problem:";
            // 
            // langPickLabel
            // 
            this.langPickLabel.AutoSize = true;
            this.langPickLabel.Location = new System.Drawing.Point(301, 38);
            this.langPickLabel.Name = "langPickLabel";
            this.langPickLabel.Size = new System.Drawing.Size(55, 13);
            this.langPickLabel.TabIndex = 13;
            this.langPickLabel.Text = "Language";
            // 
            // langPickBox
            // 
            this.langPickBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langPickBox.Enabled = false;
            this.langPickBox.FormattingEnabled = true;
            this.langPickBox.Items.AddRange(new object[] {
            "C++",
            "Java"});
            this.langPickBox.Location = new System.Drawing.Point(362, 35);
            this.langPickBox.Name = "langPickBox";
            this.langPickBox.Size = new System.Drawing.Size(90, 21);
            this.langPickBox.TabIndex = 14;
            this.langPickBox.TextChanged += new System.EventHandler(this.LangPickBox_TextChanged);
            // 
            // pickFolderButton
            // 
            this.pickFolderButton.Enabled = false;
            this.pickFolderButton.Location = new System.Drawing.Point(458, 33);
            this.pickFolderButton.Name = "pickFolderButton";
            this.pickFolderButton.Size = new System.Drawing.Size(114, 23);
            this.pickFolderButton.TabIndex = 15;
            this.pickFolderButton.Text = "Choose folder";
            this.pickFolderButton.UseVisualStyleBackColor = true;
            this.pickFolderButton.EnabledChanged += new System.EventHandler(this.PickFolderButton_EnabledChanged);
            this.pickFolderButton.Click += new System.EventHandler(this.PickFolderButton_Click);
            // 
            // solutionTable
            // 
            this.solutionTable.AllowUserToAddRows = false;
            this.solutionTable.AllowUserToDeleteRows = false;
            this.solutionTable.AllowUserToOrderColumns = true;
            this.solutionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solutionTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileSize,
            this.Chosen});
            this.solutionTable.Location = new System.Drawing.Point(12, 62);
            this.solutionTable.Name = "solutionTable";
            this.solutionTable.Size = new System.Drawing.Size(560, 241);
            this.solutionTable.TabIndex = 16;
            this.solutionTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SolutionTable_CellContentClick);
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 380;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "File size";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            this.FileSize.Width = 75;
            // 
            // Chosen
            // 
            this.Chosen.HeaderText = "Chosen";
            this.Chosen.Name = "Chosen";
            this.Chosen.ReadOnly = true;
            this.Chosen.Width = 50;
            // 
            // internalCheckButton
            // 
            this.internalCheckButton.Enabled = false;
            this.internalCheckButton.Location = new System.Drawing.Point(137, 309);
            this.internalCheckButton.Name = "internalCheckButton";
            this.internalCheckButton.Size = new System.Drawing.Size(123, 23);
            this.internalCheckButton.TabIndex = 17;
            this.internalCheckButton.Text = "Internal Check";
            this.internalCheckButton.UseVisualStyleBackColor = true;
            this.internalCheckButton.Click += new System.EventHandler(this.InternalCheckButton_Click);
            // 
            // globalCheckButton
            // 
            this.globalCheckButton.Enabled = false;
            this.globalCheckButton.Location = new System.Drawing.Point(329, 309);
            this.globalCheckButton.Name = "globalCheckButton";
            this.globalCheckButton.Size = new System.Drawing.Size(123, 23);
            this.globalCheckButton.TabIndex = 18;
            this.globalCheckButton.Text = "Global Check";
            this.globalCheckButton.UseVisualStyleBackColor = true;
            this.globalCheckButton.Click += new System.EventHandler(this.GlobalCheckButton_Click);
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.globalCheckButton);
            this.Controls.Add(this.internalCheckButton);
            this.Controls.Add(this.solutionTable);
            this.Controls.Add(this.pickFolderButton);
            this.Controls.Add(this.langPickBox);
            this.Controls.Add(this.langPickLabel);
            this.Controls.Add(this.problemPickBox);
            this.Controls.Add(this.problemPickLabel);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.disconnectServerButton);
            this.Controls.Add(this.connectServerButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClientMainForm";
            this.Text = "Source Code Analyzer by Ivy (Client)";
            ((System.ComponentModel.ISupportInitialize)(this.solutionTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Button disconnectServerButton;
        private System.Windows.Forms.Button connectServerButton;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Timer reloadTimer;
        private System.Windows.Forms.ComboBox problemPickBox;
        private System.Windows.Forms.Label problemPickLabel;
        private System.Windows.Forms.Label langPickLabel;
        private System.Windows.Forms.ComboBox langPickBox;
        private System.Windows.Forms.Button pickFolderButton;
        private System.Windows.Forms.FolderBrowserDialog pickFolderDialog;
        private System.Windows.Forms.DataGridView solutionTable;
        private System.Windows.Forms.Button internalCheckButton;
        private System.Windows.Forms.Button globalCheckButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chosen;
    }
}