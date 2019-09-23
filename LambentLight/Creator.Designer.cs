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
            this.BasicsTabPage = new System.Windows.Forms.TabPage();
            this.DownloadGroupBox = new System.Windows.Forms.GroupBox();
            this.DownloadCheckBox = new System.Windows.Forms.CheckBox();
            this.NameGroupBox = new System.Windows.Forms.GroupBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.IntroductionLabel = new System.Windows.Forms.Label();
            this.SecurityTabPage = new System.Windows.Forms.TabPage();
            this.SHVGroupBox = new System.Windows.Forms.GroupBox();
            this.SHVCheckBox = new System.Windows.Forms.CheckBox();
            this.RCONGroupBox = new System.Windows.Forms.GroupBox();
            this.RCONTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.CreatorTabControl.SuspendLayout();
            this.BasicsTabPage.SuspendLayout();
            this.DownloadGroupBox.SuspendLayout();
            this.NameGroupBox.SuspendLayout();
            this.SecurityTabPage.SuspendLayout();
            this.SHVGroupBox.SuspendLayout();
            this.RCONGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreatorTabControl
            // 
            this.CreatorTabControl.Controls.Add(this.BasicsTabPage);
            this.CreatorTabControl.Controls.Add(this.SecurityTabPage);
            this.CreatorTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreatorTabControl.Location = new System.Drawing.Point(0, 0);
            this.CreatorTabControl.Name = "CreatorTabControl";
            this.CreatorTabControl.SelectedIndex = 0;
            this.CreatorTabControl.Size = new System.Drawing.Size(432, 336);
            this.CreatorTabControl.TabIndex = 0;
            this.CreatorTabControl.SelectedIndexChanged += new System.EventHandler(this.CreatorTabControl_SelectedIndexChanged);
            // 
            // BasicsTabPage
            // 
            this.BasicsTabPage.Controls.Add(this.DownloadGroupBox);
            this.BasicsTabPage.Controls.Add(this.NameGroupBox);
            this.BasicsTabPage.Controls.Add(this.IntroductionLabel);
            this.BasicsTabPage.Location = new System.Drawing.Point(4, 22);
            this.BasicsTabPage.Name = "BasicsTabPage";
            this.BasicsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BasicsTabPage.Size = new System.Drawing.Size(424, 310);
            this.BasicsTabPage.TabIndex = 0;
            this.BasicsTabPage.Text = "Basics";
            this.BasicsTabPage.UseVisualStyleBackColor = true;
            // 
            // DownloadGroupBox
            // 
            this.DownloadGroupBox.Controls.Add(this.DownloadCheckBox);
            this.DownloadGroupBox.Location = new System.Drawing.Point(6, 259);
            this.DownloadGroupBox.Name = "DownloadGroupBox";
            this.DownloadGroupBox.Size = new System.Drawing.Size(412, 45);
            this.DownloadGroupBox.TabIndex = 2;
            this.DownloadGroupBox.TabStop = false;
            this.DownloadGroupBox.Text = "Download Required Scripts (Recommended)";
            // 
            // DownloadCheckBox
            // 
            this.DownloadCheckBox.AutoSize = true;
            this.DownloadCheckBox.Location = new System.Drawing.Point(6, 19);
            this.DownloadCheckBox.Name = "DownloadCheckBox";
            this.DownloadCheckBox.Size = new System.Drawing.Size(308, 17);
            this.DownloadCheckBox.TabIndex = 0;
            this.DownloadCheckBox.Text = "Download Vanilla FiveM scripts required for running a server";
            this.DownloadCheckBox.UseVisualStyleBackColor = true;
            // 
            // NameGroupBox
            // 
            this.NameGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameGroupBox.Controls.Add(this.NameTextBox);
            this.NameGroupBox.Location = new System.Drawing.Point(6, 204);
            this.NameGroupBox.Name = "NameGroupBox";
            this.NameGroupBox.Size = new System.Drawing.Size(412, 49);
            this.NameGroupBox.TabIndex = 1;
            this.NameGroupBox.TabStop = false;
            this.NameGroupBox.Text = "Name of your Data Folder (Required)";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(6, 19);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(400, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // IntroductionLabel
            // 
            this.IntroductionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.IntroductionLabel.Location = new System.Drawing.Point(3, 3);
            this.IntroductionLabel.Name = "IntroductionLabel";
            this.IntroductionLabel.Size = new System.Drawing.Size(418, 198);
            this.IntroductionLabel.TabIndex = 0;
            this.IntroductionLabel.Text = resources.GetString("IntroductionLabel.Text");
            this.IntroductionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SecurityTabPage
            // 
            this.SecurityTabPage.Controls.Add(this.SHVGroupBox);
            this.SecurityTabPage.Controls.Add(this.RCONGroupBox);
            this.SecurityTabPage.Location = new System.Drawing.Point(4, 22);
            this.SecurityTabPage.Name = "SecurityTabPage";
            this.SecurityTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SecurityTabPage.Size = new System.Drawing.Size(424, 310);
            this.SecurityTabPage.TabIndex = 1;
            this.SecurityTabPage.Text = "Security";
            this.SecurityTabPage.UseVisualStyleBackColor = true;
            // 
            // SHVGroupBox
            // 
            this.SHVGroupBox.Controls.Add(this.SHVCheckBox);
            this.SHVGroupBox.Location = new System.Drawing.Point(6, 62);
            this.SHVGroupBox.Name = "SHVGroupBox";
            this.SHVGroupBox.Size = new System.Drawing.Size(412, 45);
            this.SHVGroupBox.TabIndex = 1;
            this.SHVGroupBox.TabStop = false;
            this.SHVGroupBox.Text = "ScriptHookV Scripts";
            // 
            // SHVCheckBox
            // 
            this.SHVCheckBox.AutoSize = true;
            this.SHVCheckBox.Location = new System.Drawing.Point(6, 19);
            this.SHVCheckBox.Name = "SHVCheckBox";
            this.SHVCheckBox.Size = new System.Drawing.Size(251, 17);
            this.SHVCheckBox.TabIndex = 0;
            this.SHVCheckBox.Text = "Allow ScriptHookV Scripts to be used on Clients";
            this.SHVCheckBox.UseVisualStyleBackColor = true;
            // 
            // RCONGroupBox
            // 
            this.RCONGroupBox.Controls.Add(this.RCONTextBox);
            this.RCONGroupBox.Location = new System.Drawing.Point(6, 6);
            this.RCONGroupBox.Name = "RCONGroupBox";
            this.RCONGroupBox.Size = new System.Drawing.Size(412, 50);
            this.RCONGroupBox.TabIndex = 0;
            this.RCONGroupBox.TabStop = false;
            this.RCONGroupBox.Text = "RCON Password (Leave Empty to generate one)";
            // 
            // RCONTextBox
            // 
            this.RCONTextBox.Location = new System.Drawing.Point(6, 19);
            this.RCONTextBox.Name = "RCONTextBox";
            this.RCONTextBox.Size = new System.Drawing.Size(400, 20);
            this.RCONTextBox.TabIndex = 0;
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
            this.BasicsTabPage.ResumeLayout(false);
            this.DownloadGroupBox.ResumeLayout(false);
            this.DownloadGroupBox.PerformLayout();
            this.NameGroupBox.ResumeLayout(false);
            this.NameGroupBox.PerformLayout();
            this.SecurityTabPage.ResumeLayout(false);
            this.SHVGroupBox.ResumeLayout(false);
            this.SHVGroupBox.PerformLayout();
            this.RCONGroupBox.ResumeLayout(false);
            this.RCONGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl CreatorTabControl;
        private System.Windows.Forms.TabPage BasicsTabPage;
        private System.Windows.Forms.Label IntroductionLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.TabPage SecurityTabPage;
        private System.Windows.Forms.GroupBox NameGroupBox;
        private System.Windows.Forms.GroupBox DownloadGroupBox;
        private System.Windows.Forms.CheckBox DownloadCheckBox;
        private System.Windows.Forms.GroupBox RCONGroupBox;
        private System.Windows.Forms.GroupBox SHVGroupBox;
        public System.Windows.Forms.TextBox NameTextBox;
        public System.Windows.Forms.TextBox RCONTextBox;
        public System.Windows.Forms.CheckBox SHVCheckBox;
    }
}