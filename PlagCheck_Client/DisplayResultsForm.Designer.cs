namespace PlagCheck_Client
{
    partial class DisplayResultsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.overviewBox = new System.Windows.Forms.TextBox();
            this.simRateLabel = new System.Windows.Forms.Label();
            this.simRateBox = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.percentileLabel_100 = new System.Windows.Forms.Label();
            this.percentileBar_100 = new System.Windows.Forms.ProgressBar();
            this.percentileBar_80 = new System.Windows.Forms.ProgressBar();
            this.percentileLabel_80 = new System.Windows.Forms.Label();
            this.percentileLabel_60 = new System.Windows.Forms.Label();
            this.percentileBar_60 = new System.Windows.Forms.ProgressBar();
            this.percentileLabel_40 = new System.Windows.Forms.Label();
            this.percentileBar_40 = new System.Windows.Forms.ProgressBar();
            this.percentileLabel_20 = new System.Windows.Forms.Label();
            this.percentileBar_20 = new System.Windows.Forms.ProgressBar();
            this.plagiarismGrid = new System.Windows.Forms.DataGridView();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.countBox_100 = new System.Windows.Forms.TextBox();
            this.countBox_80 = new System.Windows.Forms.TextBox();
            this.countBox_60 = new System.Windows.Forms.TextBox();
            this.countBox_40 = new System.Windows.Forms.TextBox();
            this.countBox_20 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.plagiarismGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // overviewBox
            // 
            this.overviewBox.Location = new System.Drawing.Point(12, 12);
            this.overviewBox.Multiline = true;
            this.overviewBox.Name = "overviewBox";
            this.overviewBox.ReadOnly = true;
            this.overviewBox.Size = new System.Drawing.Size(458, 102);
            this.overviewBox.TabIndex = 0;
            // 
            // simRateLabel
            // 
            this.simRateLabel.AutoSize = true;
            this.simRateLabel.Location = new System.Drawing.Point(12, 123);
            this.simRateLabel.Name = "simRateLabel";
            this.simRateLabel.Size = new System.Drawing.Size(244, 13);
            this.simRateLabel.TabIndex = 1;
            this.simRateLabel.Text = "Similarity percentile to be considered as plagiarism:";
            // 
            // simRateBox
            // 
            this.simRateBox.Location = new System.Drawing.Point(262, 120);
            this.simRateBox.Name = "simRateBox";
            this.simRateBox.Size = new System.Drawing.Size(100, 20);
            this.simRateBox.TabIndex = 2;
            this.simRateBox.Text = "0";
            this.simRateBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SimRateBox_KeyPress);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(368, 120);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(102, 23);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // percentileLabel_100
            // 
            this.percentileLabel_100.AutoSize = true;
            this.percentileLabel_100.Location = new System.Drawing.Point(476, 12);
            this.percentileLabel_100.Name = "percentileLabel_100";
            this.percentileLabel_100.Size = new System.Drawing.Size(48, 13);
            this.percentileLabel_100.TabIndex = 4;
            this.percentileLabel_100.Text = "80-100%";
            // 
            // percentileBar_100
            // 
            this.percentileBar_100.Location = new System.Drawing.Point(530, 12);
            this.percentileBar_100.Maximum = 10000;
            this.percentileBar_100.Name = "percentileBar_100";
            this.percentileBar_100.Size = new System.Drawing.Size(386, 23);
            this.percentileBar_100.Step = 1;
            this.percentileBar_100.TabIndex = 5;
            // 
            // percentileBar_80
            // 
            this.percentileBar_80.Location = new System.Drawing.Point(530, 41);
            this.percentileBar_80.Maximum = 10000;
            this.percentileBar_80.Name = "percentileBar_80";
            this.percentileBar_80.Size = new System.Drawing.Size(386, 23);
            this.percentileBar_80.Step = 1;
            this.percentileBar_80.TabIndex = 7;
            // 
            // percentileLabel_80
            // 
            this.percentileLabel_80.AutoSize = true;
            this.percentileLabel_80.Location = new System.Drawing.Point(482, 41);
            this.percentileLabel_80.Name = "percentileLabel_80";
            this.percentileLabel_80.Size = new System.Drawing.Size(42, 13);
            this.percentileLabel_80.TabIndex = 6;
            this.percentileLabel_80.Text = "60-80%";
            // 
            // percentileLabel_60
            // 
            this.percentileLabel_60.AutoSize = true;
            this.percentileLabel_60.Location = new System.Drawing.Point(482, 70);
            this.percentileLabel_60.Name = "percentileLabel_60";
            this.percentileLabel_60.Size = new System.Drawing.Size(42, 13);
            this.percentileLabel_60.TabIndex = 6;
            this.percentileLabel_60.Text = "40-60%";
            // 
            // percentileBar_60
            // 
            this.percentileBar_60.Location = new System.Drawing.Point(530, 70);
            this.percentileBar_60.Maximum = 10000;
            this.percentileBar_60.Name = "percentileBar_60";
            this.percentileBar_60.Size = new System.Drawing.Size(386, 23);
            this.percentileBar_60.Step = 1;
            this.percentileBar_60.TabIndex = 7;
            // 
            // percentileLabel_40
            // 
            this.percentileLabel_40.AutoSize = true;
            this.percentileLabel_40.Location = new System.Drawing.Point(482, 99);
            this.percentileLabel_40.Name = "percentileLabel_40";
            this.percentileLabel_40.Size = new System.Drawing.Size(42, 13);
            this.percentileLabel_40.TabIndex = 6;
            this.percentileLabel_40.Text = "20-40%";
            // 
            // percentileBar_40
            // 
            this.percentileBar_40.Location = new System.Drawing.Point(530, 99);
            this.percentileBar_40.Maximum = 10000;
            this.percentileBar_40.Name = "percentileBar_40";
            this.percentileBar_40.Size = new System.Drawing.Size(386, 23);
            this.percentileBar_40.Step = 1;
            this.percentileBar_40.TabIndex = 7;
            // 
            // percentileLabel_20
            // 
            this.percentileLabel_20.AutoSize = true;
            this.percentileLabel_20.Location = new System.Drawing.Point(488, 128);
            this.percentileLabel_20.Name = "percentileLabel_20";
            this.percentileLabel_20.Size = new System.Drawing.Size(36, 13);
            this.percentileLabel_20.TabIndex = 6;
            this.percentileLabel_20.Text = "0-20%";
            // 
            // percentileBar_20
            // 
            this.percentileBar_20.Location = new System.Drawing.Point(530, 128);
            this.percentileBar_20.Maximum = 10000;
            this.percentileBar_20.Name = "percentileBar_20";
            this.percentileBar_20.Size = new System.Drawing.Size(386, 23);
            this.percentileBar_20.Step = 1;
            this.percentileBar_20.TabIndex = 7;
            // 
            // plagiarismGrid
            // 
            this.plagiarismGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.plagiarismGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.plagiarismGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.plagiarismGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.plagiarismGrid.Location = new System.Drawing.Point(12, 157);
            this.plagiarismGrid.Name = "plagiarismGrid";
            this.plagiarismGrid.Size = new System.Drawing.Size(960, 279);
            this.plagiarismGrid.TabIndex = 8;
            this.plagiarismGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlagiarismGrid_CellContentClick);
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(12, 439);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(831, 13);
            this.instructionsLabel.TabIndex = 9;
            this.instructionsLabel.Text = "Click on a file name to view its content. Click a comparison to view both files. " +
    "If you want to add a solution to the server database, click the \"Add\" button on " +
    "the respective line.";
            // 
            // countBox_100
            // 
            this.countBox_100.Location = new System.Drawing.Point(922, 15);
            this.countBox_100.Name = "countBox_100";
            this.countBox_100.ReadOnly = true;
            this.countBox_100.Size = new System.Drawing.Size(50, 20);
            this.countBox_100.TabIndex = 10;
            this.countBox_100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // countBox_80
            // 
            this.countBox_80.Location = new System.Drawing.Point(922, 44);
            this.countBox_80.Name = "countBox_80";
            this.countBox_80.ReadOnly = true;
            this.countBox_80.Size = new System.Drawing.Size(50, 20);
            this.countBox_80.TabIndex = 10;
            this.countBox_80.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // countBox_60
            // 
            this.countBox_60.Location = new System.Drawing.Point(922, 73);
            this.countBox_60.Name = "countBox_60";
            this.countBox_60.ReadOnly = true;
            this.countBox_60.Size = new System.Drawing.Size(50, 20);
            this.countBox_60.TabIndex = 10;
            this.countBox_60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // countBox_40
            // 
            this.countBox_40.Location = new System.Drawing.Point(922, 102);
            this.countBox_40.Name = "countBox_40";
            this.countBox_40.ReadOnly = true;
            this.countBox_40.Size = new System.Drawing.Size(50, 20);
            this.countBox_40.TabIndex = 10;
            this.countBox_40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // countBox_20
            // 
            this.countBox_20.Location = new System.Drawing.Point(922, 131);
            this.countBox_20.Name = "countBox_20";
            this.countBox_20.ReadOnly = true;
            this.countBox_20.Size = new System.Drawing.Size(50, 20);
            this.countBox_20.TabIndex = 10;
            this.countBox_20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DisplayResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.countBox_20);
            this.Controls.Add(this.countBox_40);
            this.Controls.Add(this.countBox_60);
            this.Controls.Add(this.countBox_80);
            this.Controls.Add(this.countBox_100);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.plagiarismGrid);
            this.Controls.Add(this.percentileBar_20);
            this.Controls.Add(this.percentileLabel_20);
            this.Controls.Add(this.percentileBar_40);
            this.Controls.Add(this.percentileLabel_40);
            this.Controls.Add(this.percentileBar_60);
            this.Controls.Add(this.percentileLabel_60);
            this.Controls.Add(this.percentileBar_80);
            this.Controls.Add(this.percentileLabel_80);
            this.Controls.Add(this.percentileBar_100);
            this.Controls.Add(this.percentileLabel_100);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.simRateBox);
            this.Controls.Add(this.simRateLabel);
            this.Controls.Add(this.overviewBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DisplayResultsForm";
            this.Text = "Display Results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DisplayResultsForm_FormClosed);
            this.Load += new System.EventHandler(this.DisplayResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.plagiarismGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox overviewBox;
        private System.Windows.Forms.Label simRateLabel;
        private System.Windows.Forms.TextBox simRateBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label percentileLabel_100;
        private System.Windows.Forms.ProgressBar percentileBar_100;
        private System.Windows.Forms.ProgressBar percentileBar_80;
        private System.Windows.Forms.Label percentileLabel_80;
        private System.Windows.Forms.Label percentileLabel_60;
        private System.Windows.Forms.ProgressBar percentileBar_60;
        private System.Windows.Forms.Label percentileLabel_40;
        private System.Windows.Forms.ProgressBar percentileBar_40;
        private System.Windows.Forms.Label percentileLabel_20;
        private System.Windows.Forms.ProgressBar percentileBar_20;
        private System.Windows.Forms.DataGridView plagiarismGrid;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.TextBox countBox_100;
        private System.Windows.Forms.TextBox countBox_80;
        private System.Windows.Forms.TextBox countBox_60;
        private System.Windows.Forms.TextBox countBox_40;
        private System.Windows.Forms.TextBox countBox_20;
    }
}