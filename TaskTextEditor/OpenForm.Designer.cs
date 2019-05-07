namespace TaskTextEditor
{
    partial class OpenForm
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
            this.FileslistBox = new System.Windows.Forms.ListBox();
            this.FileTitleTB = new System.Windows.Forms.TextBox();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileslistBox
            // 
            this.FileslistBox.FormattingEnabled = true;
            this.FileslistBox.Location = new System.Drawing.Point(12, 44);
            this.FileslistBox.Name = "FileslistBox";
            this.FileslistBox.Size = new System.Drawing.Size(223, 264);
            this.FileslistBox.TabIndex = 0;
            // 
            // FileTitleTB
            // 
            this.FileTitleTB.Location = new System.Drawing.Point(12, 12);
            this.FileTitleTB.Name = "FileTitleTB";
            this.FileTitleTB.Size = new System.Drawing.Size(223, 20);
            this.FileTitleTB.TabIndex = 1;
            this.FileTitleTB.TextChanged += new System.EventHandler(this.FileTitleTB_TextChanged);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(73, 321);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(100, 23);
            this.OpenBtn.TabIndex = 2;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // OpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 356);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.FileTitleTB);
            this.Controls.Add(this.FileslistBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OpenForm";
            this.Text = "Open File";
            this.Load += new System.EventHandler(this.OpenForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FileslistBox;
        private System.Windows.Forms.TextBox FileTitleTB;
        private System.Windows.Forms.Button OpenBtn;
    }
}