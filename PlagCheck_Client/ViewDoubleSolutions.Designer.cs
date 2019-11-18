namespace PlagCheck_Client
{
    partial class ViewDoubleSolutions
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
            this.okButton = new System.Windows.Forms.Button();
            this.contentBox1 = new System.Windows.Forms.TextBox();
            this.contentBox2 = new System.Windows.Forms.TextBox();
            this.solNameBox1 = new System.Windows.Forms.TextBox();
            this.solNameBox2 = new System.Windows.Forms.TextBox();
            this.similarityBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(453, 426);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // contentBox1
            // 
            this.contentBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentBox1.Location = new System.Drawing.Point(12, 38);
            this.contentBox1.Multiline = true;
            this.contentBox1.Name = "contentBox1";
            this.contentBox1.ReadOnly = true;
            this.contentBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contentBox1.Size = new System.Drawing.Size(477, 382);
            this.contentBox1.TabIndex = 2;
            // 
            // contentBox2
            // 
            this.contentBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentBox2.Location = new System.Drawing.Point(495, 38);
            this.contentBox2.Multiline = true;
            this.contentBox2.Name = "contentBox2";
            this.contentBox2.ReadOnly = true;
            this.contentBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contentBox2.Size = new System.Drawing.Size(477, 382);
            this.contentBox2.TabIndex = 2;
            // 
            // solNameBox1
            // 
            this.solNameBox1.Location = new System.Drawing.Point(12, 12);
            this.solNameBox1.Name = "solNameBox1";
            this.solNameBox1.ReadOnly = true;
            this.solNameBox1.Size = new System.Drawing.Size(379, 20);
            this.solNameBox1.TabIndex = 4;
            // 
            // solNameBox2
            // 
            this.solNameBox2.Location = new System.Drawing.Point(593, 12);
            this.solNameBox2.Name = "solNameBox2";
            this.solNameBox2.ReadOnly = true;
            this.solNameBox2.Size = new System.Drawing.Size(379, 20);
            this.solNameBox2.TabIndex = 4;
            this.solNameBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // similarityBox
            // 
            this.similarityBox.Location = new System.Drawing.Point(397, 12);
            this.similarityBox.Name = "similarityBox";
            this.similarityBox.ReadOnly = true;
            this.similarityBox.Size = new System.Drawing.Size(190, 20);
            this.similarityBox.TabIndex = 5;
            this.similarityBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ViewDoubleSolutions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.similarityBox);
            this.Controls.Add(this.solNameBox2);
            this.Controls.Add(this.solNameBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.contentBox2);
            this.Controls.Add(this.contentBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewDoubleSolutions";
            this.Text = "View two solutions...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewDoubleSolutions_FormClosed);
            this.Load += new System.EventHandler(this.ViewDoubleSolutions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox contentBox1;
        private System.Windows.Forms.TextBox contentBox2;
        private System.Windows.Forms.TextBox solNameBox1;
        private System.Windows.Forms.TextBox solNameBox2;
        private System.Windows.Forms.TextBox similarityBox;
    }
}