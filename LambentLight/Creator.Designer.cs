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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Creator));
            this.CreatorTabControl = new System.Windows.Forms.TabControl();
            this.IntroductionTabPage = new System.Windows.Forms.TabPage();
            this.IntroductionLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.BasicsTabPage = new System.Windows.Forms.TabPage();
            this.CreatorTabControl.SuspendLayout();
            this.IntroductionTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreatorTabControl
            // 
            this.CreatorTabControl.Controls.Add(this.IntroductionTabPage);
            this.CreatorTabControl.Controls.Add(this.BasicsTabPage);
            this.CreatorTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreatorTabControl.Location = new System.Drawing.Point(0, 0);
            this.CreatorTabControl.Name = "CreatorTabControl";
            this.CreatorTabControl.SelectedIndex = 0;
            this.CreatorTabControl.Size = new System.Drawing.Size(432, 336);
            this.CreatorTabControl.TabIndex = 0;
            this.CreatorTabControl.SelectedIndexChanged += new System.EventHandler(this.CreatorTabControl_SelectedIndexChanged);
            // 
            // IntroductionTabPage
            // 
            this.IntroductionTabPage.Controls.Add(this.IntroductionLabel);
            this.IntroductionTabPage.Location = new System.Drawing.Point(4, 22);
            this.IntroductionTabPage.Name = "IntroductionTabPage";
            this.IntroductionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.IntroductionTabPage.Size = new System.Drawing.Size(467, 310);
            this.IntroductionTabPage.TabIndex = 0;
            this.IntroductionTabPage.Text = "Introduction";
            this.IntroductionTabPage.UseVisualStyleBackColor = true;
            // 
            // IntroductionLabel
            // 
            this.IntroductionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IntroductionLabel.Location = new System.Drawing.Point(3, 3);
            this.IntroductionLabel.Name = "IntroductionLabel";
            this.IntroductionLabel.Size = new System.Drawing.Size(461, 304);
            this.IntroductionLabel.TabIndex = 0;
            this.IntroductionLabel.Text = resources.GetString("IntroductionLabel.Text");
            this.IntroductionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Location = new System.Drawing.Point(93, 342);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateButton.Location = new System.Drawing.Point(12, 342);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(174, 342);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Location = new System.Drawing.Point(345, 342);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 4;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviousButton.Enabled = false;
            this.PreviousButton.Location = new System.Drawing.Point(264, 342);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousButton.TabIndex = 5;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // BasicsTabPage
            // 
            this.BasicsTabPage.Location = new System.Drawing.Point(4, 22);
            this.BasicsTabPage.Name = "BasicsTabPage";
            this.BasicsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BasicsTabPage.Size = new System.Drawing.Size(424, 310);
            this.BasicsTabPage.TabIndex = 1;
            this.BasicsTabPage.Text = "Basics";
            this.BasicsTabPage.UseVisualStyleBackColor = true;
            // 
            // Creator
            // 
            this.AcceptButton = this.CreateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(432, 376);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CreatorTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Creator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Folder Creator";
            this.CreatorTabControl.ResumeLayout(false);
            this.IntroductionTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl CreatorTabControl;
        private System.Windows.Forms.TabPage IntroductionTabPage;
        private System.Windows.Forms.Label IntroductionLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.TabPage BasicsTabPage;
    }
}