namespace PlagCheck_Server
{
    partial class EditSolutionForm
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
            this.contentBox = new System.Windows.Forms.TextBox();
            this.editSolutionButton = new System.Windows.Forms.Button();
            this.languagePickBox = new System.Windows.Forms.ComboBox();
            this.languagePickLabel = new System.Windows.Forms.Label();
            this.problemPickBox = new System.Windows.Forms.ComboBox();
            this.problemPickLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contentBox
            // 
            this.contentBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentBox.Location = new System.Drawing.Point(12, 39);
            this.contentBox.Multiline = true;
            this.contentBox.Name = "contentBox";
            this.contentBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contentBox.Size = new System.Drawing.Size(560, 481);
            this.contentBox.TabIndex = 13;
            // 
            // editSolutionButton
            // 
            this.editSolutionButton.Location = new System.Drawing.Point(255, 526);
            this.editSolutionButton.Name = "editSolutionButton";
            this.editSolutionButton.Size = new System.Drawing.Size(75, 23);
            this.editSolutionButton.TabIndex = 12;
            this.editSolutionButton.Text = "Edit";
            this.editSolutionButton.UseVisualStyleBackColor = true;
            this.editSolutionButton.Click += new System.EventHandler(this.EditSolutionButton_Click);
            // 
            // languagePickBox
            // 
            this.languagePickBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languagePickBox.FormattingEnabled = true;
            this.languagePickBox.Items.AddRange(new object[] {
            "C++",
            "Java"});
            this.languagePickBox.Location = new System.Drawing.Point(360, 12);
            this.languagePickBox.Name = "languagePickBox";
            this.languagePickBox.Size = new System.Drawing.Size(212, 21);
            this.languagePickBox.TabIndex = 11;
            // 
            // languagePickLabel
            // 
            this.languagePickLabel.AutoSize = true;
            this.languagePickLabel.Location = new System.Drawing.Point(296, 15);
            this.languagePickLabel.Name = "languagePickLabel";
            this.languagePickLabel.Size = new System.Drawing.Size(58, 13);
            this.languagePickLabel.TabIndex = 10;
            this.languagePickLabel.Text = "Language:";
            // 
            // problemPickBox
            // 
            this.problemPickBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.problemPickBox.FormattingEnabled = true;
            this.problemPickBox.Location = new System.Drawing.Point(66, 12);
            this.problemPickBox.Name = "problemPickBox";
            this.problemPickBox.Size = new System.Drawing.Size(224, 21);
            this.problemPickBox.TabIndex = 9;
            // 
            // problemPickLabel
            // 
            this.problemPickLabel.AutoSize = true;
            this.problemPickLabel.Location = new System.Drawing.Point(12, 15);
            this.problemPickLabel.Name = "problemPickLabel";
            this.problemPickLabel.Size = new System.Drawing.Size(48, 13);
            this.problemPickLabel.TabIndex = 8;
            this.problemPickLabel.Text = "Problem:";
            // 
            // EditSolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.contentBox);
            this.Controls.Add(this.editSolutionButton);
            this.Controls.Add(this.languagePickBox);
            this.Controls.Add(this.languagePickLabel);
            this.Controls.Add(this.problemPickBox);
            this.Controls.Add(this.problemPickLabel);
            this.Name = "EditSolutionForm";
            this.Text = "Edit Solution...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditSolutionForm_FormClosed);
            this.Load += new System.EventHandler(this.EditSolutionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentBox;
        private System.Windows.Forms.Button editSolutionButton;
        private System.Windows.Forms.ComboBox languagePickBox;
        private System.Windows.Forms.Label languagePickLabel;
        private System.Windows.Forms.ComboBox problemPickBox;
        private System.Windows.Forms.Label problemPickLabel;
    }
}