namespace ServerManager
{
    partial class Editor
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
            this.TopBar = new System.Windows.Forms.MenuStrip();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TextField = new System.Windows.Forms.TextBox();
            this.TopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveFile,
            this.ReloadFile});
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(484, 24);
            this.TopBar.TabIndex = 0;
            this.TopBar.Text = "menuStrip1";
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(43, 20);
            this.SaveFile.Text = "Save";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // ReloadFile
            // 
            this.ReloadFile.Name = "ReloadFile";
            this.ReloadFile.Size = new System.Drawing.Size(120, 20);
            this.ReloadFile.Text = "Discard and Reload";
            this.ReloadFile.Click += new System.EventHandler(this.ReloadFile_Click);
            // 
            // TextField
            // 
            this.TextField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextField.Location = new System.Drawing.Point(12, 27);
            this.TextField.Multiline = true;
            this.TextField.Name = "TextField";
            this.TextField.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextField.Size = new System.Drawing.Size(460, 352);
            this.TextField.TabIndex = 1;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 391);
            this.Controls.Add(this.TextField);
            this.Controls.Add(this.TopBar);
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopBar;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripMenuItem ReloadFile;
        private System.Windows.Forms.TextBox TextField;
    }
}