namespace LambentLight
{
    partial class Landing
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
            this.BuildsGroup = new System.Windows.Forms.GroupBox();
            this.BuildRefreshButton = new System.Windows.Forms.Button();
            this.BuildsBox = new System.Windows.Forms.ComboBox();
            this.DataGroup = new System.Windows.Forms.GroupBox();
            this.FolderRefreshButton = new System.Windows.Forms.Button();
            this.DataBox = new System.Windows.Forms.ComboBox();
            this.TopStrip = new System.Windows.Forms.MenuStrip();
            this.StartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogsTab = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.FolderCreationGroupBox = new System.Windows.Forms.GroupBox();
            this.DownloadScriptsCheckBox = new System.Windows.Forms.CheckBox();
            this.APIsGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveAPIsButton = new System.Windows.Forms.Button();
            this.BuildsTextBox = new System.Windows.Forms.TextBox();
            this.BuildsLabel = new System.Windows.Forms.Label();
            this.ResourcesTextBox = new System.Windows.Forms.TextBox();
            this.ResourcesLabel = new System.Windows.Forms.Label();
            this.LicenseGroupBox = new System.Windows.Forms.GroupBox();
            this.GenerateLicenseButton = new System.Windows.Forms.Button();
            this.SaveLicenseButton = new System.Windows.Forms.Button();
            this.VisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.LicenseTextBox = new System.Windows.Forms.TextBox();
            this.CreateConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.BuildsGroup.SuspendLayout();
            this.DataGroup.SuspendLayout();
            this.TopStrip.SuspendLayout();
            this.LogsTab.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.FolderCreationGroupBox.SuspendLayout();
            this.APIsGroupBox.SuspendLayout();
            this.LicenseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildsGroup
            // 
            this.BuildsGroup.Controls.Add(this.BuildRefreshButton);
            this.BuildsGroup.Controls.Add(this.BuildsBox);
            this.BuildsGroup.Location = new System.Drawing.Point(12, 27);
            this.BuildsGroup.Name = "BuildsGroup";
            this.BuildsGroup.Size = new System.Drawing.Size(380, 52);
            this.BuildsGroup.TabIndex = 0;
            this.BuildsGroup.TabStop = false;
            this.BuildsGroup.Text = "Build";
            // 
            // BuildRefreshButton
            // 
            this.BuildRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildRefreshButton.Location = new System.Drawing.Point(299, 18);
            this.BuildRefreshButton.Name = "BuildRefreshButton";
            this.BuildRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.BuildRefreshButton.TabIndex = 1;
            this.BuildRefreshButton.Text = "Refresh";
            this.BuildRefreshButton.UseVisualStyleBackColor = true;
            this.BuildRefreshButton.Click += new System.EventHandler(this.BuildRefreshButton_Click);
            // 
            // BuildsBox
            // 
            this.BuildsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildsBox.FormattingEnabled = true;
            this.BuildsBox.Location = new System.Drawing.Point(6, 19);
            this.BuildsBox.Name = "BuildsBox";
            this.BuildsBox.Size = new System.Drawing.Size(287, 21);
            this.BuildsBox.TabIndex = 0;
            // 
            // DataGroup
            // 
            this.DataGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGroup.Controls.Add(this.FolderRefreshButton);
            this.DataGroup.Controls.Add(this.DataBox);
            this.DataGroup.Location = new System.Drawing.Point(407, 27);
            this.DataGroup.Name = "DataGroup";
            this.DataGroup.Size = new System.Drawing.Size(380, 52);
            this.DataGroup.TabIndex = 1;
            this.DataGroup.TabStop = false;
            this.DataGroup.Text = "Data Folder";
            // 
            // FolderRefreshButton
            // 
            this.FolderRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderRefreshButton.Location = new System.Drawing.Point(299, 18);
            this.FolderRefreshButton.Name = "FolderRefreshButton";
            this.FolderRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.FolderRefreshButton.TabIndex = 1;
            this.FolderRefreshButton.Text = "Refresh";
            this.FolderRefreshButton.UseVisualStyleBackColor = true;
            this.FolderRefreshButton.Click += new System.EventHandler(this.FolderRefreshButton_Click);
            // 
            // DataBox
            // 
            this.DataBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBox.FormattingEnabled = true;
            this.DataBox.Location = new System.Drawing.Point(6, 19);
            this.DataBox.Name = "DataBox";
            this.DataBox.Size = new System.Drawing.Size(287, 21);
            this.DataBox.TabIndex = 0;
            // 
            // TopStrip
            // 
            this.TopStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartItem,
            this.StopItem,
            this.CreateItem,
            this.ExitItem});
            this.TopStrip.Location = new System.Drawing.Point(0, 0);
            this.TopStrip.Name = "TopStrip";
            this.TopStrip.Size = new System.Drawing.Size(799, 24);
            this.TopStrip.TabIndex = 2;
            this.TopStrip.Text = "menuStrip1";
            // 
            // StartItem
            // 
            this.StartItem.Image = global::LambentLight.Properties.Resources.Play;
            this.StartItem.Name = "StartItem";
            this.StartItem.Size = new System.Drawing.Size(94, 20);
            this.StartItem.Text = "Start Server";
            this.StartItem.Click += new System.EventHandler(this.StartItem_Click);
            // 
            // StopItem
            // 
            this.StopItem.Image = global::LambentLight.Properties.Resources.Stop;
            this.StopItem.Name = "StopItem";
            this.StopItem.Size = new System.Drawing.Size(94, 20);
            this.StopItem.Text = "Stop Server";
            this.StopItem.Click += new System.EventHandler(this.StopItem_Click);
            // 
            // CreateItem
            // 
            this.CreateItem.Image = global::LambentLight.Properties.Resources.Add;
            this.CreateItem.Name = "CreateItem";
            this.CreateItem.Size = new System.Drawing.Size(132, 20);
            this.CreateItem.Text = "Create Data Folder";
            this.CreateItem.Click += new System.EventHandler(this.CreateItem_Click);
            // 
            // ExitItem
            // 
            this.ExitItem.Image = global::LambentLight.Properties.Resources.Exit;
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(54, 20);
            this.ExitItem.Text = "Exit";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // LogsTab
            // 
            this.LogsTab.Controls.Add(this.LogTextBox);
            this.LogsTab.Location = new System.Drawing.Point(4, 22);
            this.LogsTab.Name = "LogsTab";
            this.LogsTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogsTab.Size = new System.Drawing.Size(767, 313);
            this.LogsTab.TabIndex = 0;
            this.LogsTab.Text = "Logs";
            this.LogsTab.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.Location = new System.Drawing.Point(6, 6);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(755, 301);
            this.LogTextBox.TabIndex = 0;
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.LogsTab);
            this.Tabs.Controls.Add(this.SettingsTab);
            this.Tabs.Location = new System.Drawing.Point(12, 85);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(775, 339);
            this.Tabs.TabIndex = 3;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.FolderCreationGroupBox);
            this.SettingsTab.Controls.Add(this.APIsGroupBox);
            this.SettingsTab.Controls.Add(this.LicenseGroupBox);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(767, 313);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // FolderCreationGroupBox
            // 
            this.FolderCreationGroupBox.Controls.Add(this.CreateConfigCheckBox);
            this.FolderCreationGroupBox.Controls.Add(this.DownloadScriptsCheckBox);
            this.FolderCreationGroupBox.Location = new System.Drawing.Point(6, 86);
            this.FolderCreationGroupBox.Name = "FolderCreationGroupBox";
            this.FolderCreationGroupBox.Size = new System.Drawing.Size(370, 68);
            this.FolderCreationGroupBox.TabIndex = 2;
            this.FolderCreationGroupBox.TabStop = false;
            this.FolderCreationGroupBox.Text = "Data Folder Creation";
            // 
            // DownloadScriptsCheckBox
            // 
            this.DownloadScriptsCheckBox.AutoSize = true;
            this.DownloadScriptsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.DownloadScriptsCheckBox.Name = "DownloadScriptsCheckBox";
            this.DownloadScriptsCheckBox.Size = new System.Drawing.Size(238, 17);
            this.DownloadScriptsCheckBox.TabIndex = 0;
            this.DownloadScriptsCheckBox.Text = "Download Base Scripts from the FiveM Repo";
            this.DownloadScriptsCheckBox.UseVisualStyleBackColor = true;
            this.DownloadScriptsCheckBox.CheckedChanged += new System.EventHandler(this.DownloadScriptsCheckBox_CheckedChanged);
            // 
            // APIsGroupBox
            // 
            this.APIsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.APIsGroupBox.Controls.Add(this.SaveAPIsButton);
            this.APIsGroupBox.Controls.Add(this.BuildsTextBox);
            this.APIsGroupBox.Controls.Add(this.BuildsLabel);
            this.APIsGroupBox.Controls.Add(this.ResourcesTextBox);
            this.APIsGroupBox.Controls.Add(this.ResourcesLabel);
            this.APIsGroupBox.Location = new System.Drawing.Point(391, 6);
            this.APIsGroupBox.Name = "APIsGroupBox";
            this.APIsGroupBox.Size = new System.Drawing.Size(370, 125);
            this.APIsGroupBox.TabIndex = 1;
            this.APIsGroupBox.TabStop = false;
            this.APIsGroupBox.Text = "API URLs";
            // 
            // SaveAPIsButton
            // 
            this.SaveAPIsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAPIsButton.Location = new System.Drawing.Point(289, 97);
            this.SaveAPIsButton.Name = "SaveAPIsButton";
            this.SaveAPIsButton.Size = new System.Drawing.Size(75, 23);
            this.SaveAPIsButton.TabIndex = 4;
            this.SaveAPIsButton.Text = "Save";
            this.SaveAPIsButton.UseVisualStyleBackColor = true;
            this.SaveAPIsButton.Click += new System.EventHandler(this.SaveAPIsButton_Click);
            // 
            // BuildsTextBox
            // 
            this.BuildsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsTextBox.Location = new System.Drawing.Point(6, 71);
            this.BuildsTextBox.Name = "BuildsTextBox";
            this.BuildsTextBox.Size = new System.Drawing.Size(358, 20);
            this.BuildsTextBox.TabIndex = 3;
            // 
            // BuildsLabel
            // 
            this.BuildsLabel.AutoSize = true;
            this.BuildsLabel.Location = new System.Drawing.Point(6, 55);
            this.BuildsLabel.Name = "BuildsLabel";
            this.BuildsLabel.Size = new System.Drawing.Size(35, 13);
            this.BuildsLabel.TabIndex = 2;
            this.BuildsLabel.Text = "Builds";
            // 
            // ResourcesTextBox
            // 
            this.ResourcesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourcesTextBox.Location = new System.Drawing.Point(6, 32);
            this.ResourcesTextBox.Name = "ResourcesTextBox";
            this.ResourcesTextBox.Size = new System.Drawing.Size(358, 20);
            this.ResourcesTextBox.TabIndex = 1;
            // 
            // ResourcesLabel
            // 
            this.ResourcesLabel.AutoSize = true;
            this.ResourcesLabel.Location = new System.Drawing.Point(6, 16);
            this.ResourcesLabel.Name = "ResourcesLabel";
            this.ResourcesLabel.Size = new System.Drawing.Size(58, 13);
            this.ResourcesLabel.TabIndex = 0;
            this.ResourcesLabel.Text = "Resources";
            // 
            // LicenseGroupBox
            // 
            this.LicenseGroupBox.Controls.Add(this.GenerateLicenseButton);
            this.LicenseGroupBox.Controls.Add(this.SaveLicenseButton);
            this.LicenseGroupBox.Controls.Add(this.VisibleCheckBox);
            this.LicenseGroupBox.Controls.Add(this.LicenseTextBox);
            this.LicenseGroupBox.Location = new System.Drawing.Point(6, 6);
            this.LicenseGroupBox.Name = "LicenseGroupBox";
            this.LicenseGroupBox.Size = new System.Drawing.Size(370, 74);
            this.LicenseGroupBox.TabIndex = 0;
            this.LicenseGroupBox.TabStop = false;
            this.LicenseGroupBox.Text = "FiveM License";
            // 
            // GenerateLicenseButton
            // 
            this.GenerateLicenseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateLicenseButton.Location = new System.Drawing.Point(208, 45);
            this.GenerateLicenseButton.Name = "GenerateLicenseButton";
            this.GenerateLicenseButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateLicenseButton.TabIndex = 3;
            this.GenerateLicenseButton.Text = "Generate";
            this.GenerateLicenseButton.UseVisualStyleBackColor = true;
            this.GenerateLicenseButton.Click += new System.EventHandler(this.GenerateLicenseButton_Click);
            // 
            // SaveLicenseButton
            // 
            this.SaveLicenseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveLicenseButton.Enabled = false;
            this.SaveLicenseButton.Location = new System.Drawing.Point(289, 45);
            this.SaveLicenseButton.Name = "SaveLicenseButton";
            this.SaveLicenseButton.Size = new System.Drawing.Size(75, 23);
            this.SaveLicenseButton.TabIndex = 2;
            this.SaveLicenseButton.Text = "Save";
            this.SaveLicenseButton.UseVisualStyleBackColor = true;
            this.SaveLicenseButton.Click += new System.EventHandler(this.SaveLicenseButton_Click);
            // 
            // VisibleCheckBox
            // 
            this.VisibleCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VisibleCheckBox.AutoSize = true;
            this.VisibleCheckBox.Location = new System.Drawing.Point(6, 49);
            this.VisibleCheckBox.Name = "VisibleCheckBox";
            this.VisibleCheckBox.Size = new System.Drawing.Size(126, 17);
            this.VisibleCheckBox.TabIndex = 1;
            this.VisibleCheckBox.Text = "Make License Visible";
            this.VisibleCheckBox.UseVisualStyleBackColor = true;
            this.VisibleCheckBox.CheckedChanged += new System.EventHandler(this.VisibleTextBox_CheckedChanged);
            // 
            // LicenseTextBox
            // 
            this.LicenseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseTextBox.Enabled = false;
            this.LicenseTextBox.Location = new System.Drawing.Point(6, 19);
            this.LicenseTextBox.Name = "LicenseTextBox";
            this.LicenseTextBox.Size = new System.Drawing.Size(358, 20);
            this.LicenseTextBox.TabIndex = 0;
            // 
            // CreateConfigCheckBox
            // 
            this.CreateConfigCheckBox.AutoSize = true;
            this.CreateConfigCheckBox.Location = new System.Drawing.Point(6, 42);
            this.CreateConfigCheckBox.Name = "CreateConfigCheckBox";
            this.CreateConfigCheckBox.Size = new System.Drawing.Size(276, 17);
            this.CreateConfigCheckBox.TabIndex = 1;
            this.CreateConfigCheckBox.Text = "Generate Configuration after creating the Data Folder";
            this.CreateConfigCheckBox.UseVisualStyleBackColor = true;
            this.CreateConfigCheckBox.CheckedChanged += new System.EventHandler(this.CreateConfigCheckBox_CheckedChanged);
            // 
            // Landing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 436);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.DataGroup);
            this.Controls.Add(this.BuildsGroup);
            this.Controls.Add(this.TopStrip);
            this.MainMenuStrip = this.TopStrip;
            this.MinimumSize = new System.Drawing.Size(815, 475);
            this.Name = "Landing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LambentLight: A FiveM Server Manager";
            this.Load += new System.EventHandler(this.Landing_Load);
            this.BuildsGroup.ResumeLayout(false);
            this.DataGroup.ResumeLayout(false);
            this.TopStrip.ResumeLayout(false);
            this.TopStrip.PerformLayout();
            this.LogsTab.ResumeLayout(false);
            this.LogsTab.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.FolderCreationGroupBox.ResumeLayout(false);
            this.FolderCreationGroupBox.PerformLayout();
            this.APIsGroupBox.ResumeLayout(false);
            this.APIsGroupBox.PerformLayout();
            this.LicenseGroupBox.ResumeLayout(false);
            this.LicenseGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox BuildsGroup;
        private System.Windows.Forms.ComboBox BuildsBox;
        private System.Windows.Forms.GroupBox DataGroup;
        private System.Windows.Forms.ComboBox DataBox;
        private System.Windows.Forms.MenuStrip TopStrip;
        private System.Windows.Forms.ToolStripMenuItem StartItem;
        private System.Windows.Forms.ToolStripMenuItem StopItem;
        private System.Windows.Forms.TabPage LogsTab;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.ToolStripMenuItem CreateItem;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.GroupBox LicenseGroupBox;
        private System.Windows.Forms.TextBox LicenseTextBox;
        private System.Windows.Forms.CheckBox VisibleCheckBox;
        private System.Windows.Forms.Button SaveLicenseButton;
        private System.Windows.Forms.Button GenerateLicenseButton;
        private System.Windows.Forms.GroupBox APIsGroupBox;
        private System.Windows.Forms.Label ResourcesLabel;
        private System.Windows.Forms.TextBox ResourcesTextBox;
        private System.Windows.Forms.Label BuildsLabel;
        private System.Windows.Forms.TextBox BuildsTextBox;
        private System.Windows.Forms.Button SaveAPIsButton;
        private System.Windows.Forms.Button BuildRefreshButton;
        private System.Windows.Forms.Button FolderRefreshButton;
        private System.Windows.Forms.GroupBox FolderCreationGroupBox;
        private System.Windows.Forms.CheckBox DownloadScriptsCheckBox;
        private System.Windows.Forms.CheckBox CreateConfigCheckBox;
    }
}

