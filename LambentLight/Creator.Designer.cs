namespace LambentLight
{
    partial class Creator
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
            this.CreatorTabControl = new System.Windows.Forms.TabControl();
            this.IntroductionTabPage = new System.Windows.Forms.TabPage();
            this.CreatorTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreatorTabControl
            // 
            this.CreatorTabControl.Controls.Add(this.IntroductionTabPage);
            this.CreatorTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreatorTabControl.Location = new System.Drawing.Point(0, 0);
            this.CreatorTabControl.Name = "CreatorTabControl";
            this.CreatorTabControl.SelectedIndex = 0;
            this.CreatorTabControl.Size = new System.Drawing.Size(254, 336);
            this.CreatorTabControl.TabIndex = 0;
            // 
            // IntroductionTabPage
            // 
            this.IntroductionTabPage.Location = new System.Drawing.Point(4, 22);
            this.IntroductionTabPage.Name = "IntroductionTabPage";
            this.IntroductionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.IntroductionTabPage.Size = new System.Drawing.Size(246, 310);
            this.IntroductionTabPage.TabIndex = 0;
            this.IntroductionTabPage.Text = "Introduction";
            this.IntroductionTabPage.UseVisualStyleBackColor = true;
            // 
            // Creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 376);
            this.Controls.Add(this.CreatorTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Creator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Folder Creator";
            this.CreatorTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl CreatorTabControl;
        private System.Windows.Forms.TabPage IntroductionTabPage;
    }
}