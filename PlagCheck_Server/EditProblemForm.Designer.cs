namespace PlagCheck_Server
{
    partial class EditProblemForm
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
            this.editProblemButton = new System.Windows.Forms.Button();
            this.pmlBox = new System.Windows.Forms.TextBox();
            this.pmlLabel = new System.Windows.Forms.Label();
            this.ptlBox = new System.Windows.Forms.TextBox();
            this.ptlLabel = new System.Windows.Forms.Label();
            this.pnameBox = new System.Windows.Forms.TextBox();
            this.pnameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editProblemButton
            // 
            this.editProblemButton.Location = new System.Drawing.Point(132, 99);
            this.editProblemButton.Name = "editProblemButton";
            this.editProblemButton.Size = new System.Drawing.Size(75, 23);
            this.editProblemButton.TabIndex = 13;
            this.editProblemButton.Text = "Edit";
            this.editProblemButton.UseVisualStyleBackColor = true;
            this.editProblemButton.Click += new System.EventHandler(this.EditProblemButton_Click);
            // 
            // pmlBox
            // 
            this.pmlBox.Location = new System.Drawing.Point(110, 66);
            this.pmlBox.Name = "pmlBox";
            this.pmlBox.Size = new System.Drawing.Size(212, 20);
            this.pmlBox.TabIndex = 12;
            // 
            // pmlLabel
            // 
            this.pmlLabel.AutoSize = true;
            this.pmlLabel.Location = new System.Drawing.Point(12, 69);
            this.pmlLabel.Name = "pmlLabel";
            this.pmlLabel.Size = new System.Drawing.Size(92, 13);
            this.pmlLabel.TabIndex = 11;
            this.pmlLabel.Text = "Memory limit (MB):";
            // 
            // ptlBox
            // 
            this.ptlBox.Location = new System.Drawing.Point(110, 40);
            this.ptlBox.Name = "ptlBox";
            this.ptlBox.Size = new System.Drawing.Size(212, 20);
            this.ptlBox.TabIndex = 10;
            // 
            // ptlLabel
            // 
            this.ptlLabel.AutoSize = true;
            this.ptlLabel.Location = new System.Drawing.Point(37, 43);
            this.ptlLabel.Name = "ptlLabel";
            this.ptlLabel.Size = new System.Drawing.Size(67, 13);
            this.ptlLabel.TabIndex = 9;
            this.ptlLabel.Text = "Time limit (s):";
            // 
            // pnameBox
            // 
            this.pnameBox.Location = new System.Drawing.Point(110, 14);
            this.pnameBox.Name = "pnameBox";
            this.pnameBox.Size = new System.Drawing.Size(212, 20);
            this.pnameBox.TabIndex = 8;
            // 
            // pnameLabel
            // 
            this.pnameLabel.AutoSize = true;
            this.pnameLabel.Location = new System.Drawing.Point(27, 14);
            this.pnameLabel.Name = "pnameLabel";
            this.pnameLabel.Size = new System.Drawing.Size(77, 13);
            this.pnameLabel.TabIndex = 7;
            this.pnameLabel.Text = "Problem name:";
            this.pnameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditProblemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 136);
            this.Controls.Add(this.editProblemButton);
            this.Controls.Add(this.pmlBox);
            this.Controls.Add(this.pmlLabel);
            this.Controls.Add(this.ptlBox);
            this.Controls.Add(this.ptlLabel);
            this.Controls.Add(this.pnameBox);
            this.Controls.Add(this.pnameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditProblemForm";
            this.Text = "Edit Problem...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditProblemForm_FormClosed);
            this.Load += new System.EventHandler(this.EditProblemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editProblemButton;
        private System.Windows.Forms.TextBox pmlBox;
        private System.Windows.Forms.Label pmlLabel;
        private System.Windows.Forms.TextBox ptlBox;
        private System.Windows.Forms.Label ptlLabel;
        private System.Windows.Forms.TextBox pnameBox;
        private System.Windows.Forms.Label pnameLabel;
    }
}