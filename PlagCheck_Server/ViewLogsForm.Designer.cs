namespace PlagCheck_Server
{
    partial class ViewLogsForm
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
            this.SuspendLayout();
            // 
            // contentBox
            // 
            this.contentBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentBox.Location = new System.Drawing.Point(12, 12);
            this.contentBox.Multiline = true;
            this.contentBox.Name = "contentBox";
            this.contentBox.ReadOnly = true;
            this.contentBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contentBox.Size = new System.Drawing.Size(960, 437);
            this.contentBox.TabIndex = 0;
            // 
            // ViewLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.contentBox);
            this.Name = "ViewLogsForm";
            this.Text = "View logs....";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewLogsForm_FormClosed);
            this.Load += new System.EventHandler(this.ViewLogsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentBox;
    }
}