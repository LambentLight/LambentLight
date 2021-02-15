﻿namespace LambentLight
{
    partial class FormManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManager));
            this.BuildsGroupBox = new System.Windows.Forms.GroupBox();
            this.BuildsListBox = new System.Windows.Forms.ListBox();
            this.BuildsRefreshButton = new System.Windows.Forms.Button();
            this.DataFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.DataFolderDeleteButton = new System.Windows.Forms.Button();
            this.DataFolderBrowseButton = new System.Windows.Forms.Button();
            this.DataFolderRefreshButton = new System.Windows.Forms.Button();
            this.DataFolderComboBox = new System.Windows.Forms.ComboBox();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsoleTabPage = new System.Windows.Forms.TabPage();
            this.ConsoleClearButton = new System.Windows.Forms.Button();
            this.ConsoleSendButton = new System.Windows.Forms.Button();
            this.ConsoleInputTextBox = new System.Windows.Forms.TextBox();
            this.ConsoleTextBox = new System.Windows.Forms.TextBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ResourcesTabPage = new System.Windows.Forms.TabPage();
            this.InstalledGroupBox = new System.Windows.Forms.GroupBox();
            this.ResourceRestartButton = new System.Windows.Forms.Button();
            this.ResourceStopButton = new System.Windows.Forms.Button();
            this.ResourceStartButton = new System.Windows.Forms.Button();
            this.InstalledRefreshButton = new System.Windows.Forms.Button();
            this.InstalledListBox = new System.Windows.Forms.ListBox();
            this.InstalledUninstallButton = new System.Windows.Forms.Button();
            this.InstallerGroupBox = new System.Windows.Forms.GroupBox();
            this.InstallerInstallButton = new System.Windows.Forms.Button();
            this.InstallerRefreshButton = new System.Windows.Forms.Button();
            this.InstallerVersionsListBox = new System.Windows.Forms.ListBox();
            this.InstallerResourcesListBox = new System.Windows.Forms.ListBox();
            this.ConfigurationTabPage = new System.Windows.Forms.TabPage();
            this.ConfigurationSaveButton = new System.Windows.Forms.Button();
            this.ConfigurationGenerateButton = new System.Windows.Forms.Button();
            this.ConfigurationLoadButton = new System.Windows.Forms.Button();
            this.ConfigurationTextBox = new System.Windows.Forms.TextBox();
            this.BuildsTabPage = new System.Windows.Forms.TabPage();
            this.BuildDownloadButton = new System.Windows.Forms.Button();
            this.BuildBrowserButton = new System.Windows.Forms.Button();
            this.BuildsImportButton = new System.Windows.Forms.Button();
            this.GeneralProgressBar = new System.Windows.Forms.ProgressBar();
            this.BottomStrip = new System.Windows.Forms.StatusStrip();
            this.BottomToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BuildFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BuildsGroupBox.SuspendLayout();
            this.DataFolderGroupBox.SuspendLayout();
            this.TopMenuStrip.SuspendLayout();
            this.ConsoleTabPage.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.ResourcesTabPage.SuspendLayout();
            this.InstalledGroupBox.SuspendLayout();
            this.InstallerGroupBox.SuspendLayout();
            this.ConfigurationTabPage.SuspendLayout();
            this.BuildsTabPage.SuspendLayout();
            this.BottomStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildsGroupBox
            // 
            this.BuildsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsGroupBox.Controls.Add(this.BuildsListBox);
            this.BuildsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.BuildsGroupBox.Name = "BuildsGroupBox";
            this.BuildsGroupBox.Size = new System.Drawing.Size(575, 267);
            this.BuildsGroupBox.TabIndex = 0;
            this.BuildsGroupBox.TabStop = false;
            this.BuildsGroupBox.Text = "Builds Available";
            // 
            // BuildsListBox
            // 
            this.BuildsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsListBox.FormattingEnabled = true;
            this.BuildsListBox.Location = new System.Drawing.Point(6, 19);
            this.BuildsListBox.Name = "BuildsListBox";
            this.BuildsListBox.Size = new System.Drawing.Size(563, 238);
            this.BuildsListBox.TabIndex = 2;
            // 
            // BuildsRefreshButton
            // 
            this.BuildsRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsRefreshButton.Location = new System.Drawing.Point(587, 6);
            this.BuildsRefreshButton.Name = "BuildsRefreshButton";
            this.BuildsRefreshButton.Size = new System.Drawing.Size(150, 23);
            this.BuildsRefreshButton.TabIndex = 1;
            this.BuildsRefreshButton.Text = "Refresh";
            this.BuildsRefreshButton.UseVisualStyleBackColor = true;
            // 
            // DataFolderGroupBox
            // 
            this.DataFolderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFolderGroupBox.Controls.Add(this.DataFolderDeleteButton);
            this.DataFolderGroupBox.Controls.Add(this.DataFolderBrowseButton);
            this.DataFolderGroupBox.Controls.Add(this.DataFolderRefreshButton);
            this.DataFolderGroupBox.Controls.Add(this.DataFolderComboBox);
            this.DataFolderGroupBox.Location = new System.Drawing.Point(36, 12);
            this.DataFolderGroupBox.Name = "DataFolderGroupBox";
            this.DataFolderGroupBox.Size = new System.Drawing.Size(751, 52);
            this.DataFolderGroupBox.TabIndex = 1;
            this.DataFolderGroupBox.TabStop = false;
            this.DataFolderGroupBox.Text = "Data Folder";
            // 
            // DataFolderDeleteButton
            // 
            this.DataFolderDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFolderDeleteButton.Enabled = false;
            this.DataFolderDeleteButton.Location = new System.Drawing.Point(589, 18);
            this.DataFolderDeleteButton.Name = "DataFolderDeleteButton";
            this.DataFolderDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DataFolderDeleteButton.TabIndex = 3;
            this.DataFolderDeleteButton.Text = "Delete";
            this.DataFolderDeleteButton.UseVisualStyleBackColor = true;
            // 
            // DataFolderBrowseButton
            // 
            this.DataFolderBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFolderBrowseButton.Enabled = false;
            this.DataFolderBrowseButton.Location = new System.Drawing.Point(508, 18);
            this.DataFolderBrowseButton.Name = "DataFolderBrowseButton";
            this.DataFolderBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.DataFolderBrowseButton.TabIndex = 2;
            this.DataFolderBrowseButton.Text = "Browse";
            this.DataFolderBrowseButton.UseVisualStyleBackColor = true;
            // 
            // DataFolderRefreshButton
            // 
            this.DataFolderRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFolderRefreshButton.Location = new System.Drawing.Point(670, 18);
            this.DataFolderRefreshButton.Name = "DataFolderRefreshButton";
            this.DataFolderRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.DataFolderRefreshButton.TabIndex = 1;
            this.DataFolderRefreshButton.Text = "Refresh";
            this.DataFolderRefreshButton.UseVisualStyleBackColor = true;
            // 
            // DataFolderComboBox
            // 
            this.DataFolderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFolderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataFolderComboBox.FormattingEnabled = true;
            this.DataFolderComboBox.Location = new System.Drawing.Point(6, 19);
            this.DataFolderComboBox.Name = "DataFolderComboBox";
            this.DataFolderComboBox.Size = new System.Drawing.Size(496, 21);
            this.DataFolderComboBox.TabIndex = 0;
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.TopMenuStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.StopToolStripMenuItem,
            this.RestartToolStripMenuItem,
            this.CreateToolStripMenuItem,
            this.SettingsToolStripMenuItem});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Padding = new System.Windows.Forms.Padding(2);
            this.TopMenuStrip.Size = new System.Drawing.Size(12, 444);
            this.TopMenuStrip.TabIndex = 2;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(3, 8);
            this.StartToolStripMenuItem.Text = "Start Server";
            // 
            // StopToolStripMenuItem
            // 
            this.StopToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            this.StopToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.StopToolStripMenuItem.Size = new System.Drawing.Size(3, 8);
            this.StopToolStripMenuItem.Text = "Stop Server";
            // 
            // RestartToolStripMenuItem
            // 
            this.RestartToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem";
            this.RestartToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.RestartToolStripMenuItem.Size = new System.Drawing.Size(3, 8);
            this.RestartToolStripMenuItem.Text = "Restart Server";
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(3, 8);
            this.CreateToolStripMenuItem.Text = "Create Data Folder";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(3, 8);
            this.SettingsToolStripMenuItem.Text = "Application Settings";
            // 
            // ConsoleTabPage
            // 
            this.ConsoleTabPage.Controls.Add(this.ConsoleClearButton);
            this.ConsoleTabPage.Controls.Add(this.ConsoleSendButton);
            this.ConsoleTabPage.Controls.Add(this.ConsoleInputTextBox);
            this.ConsoleTabPage.Controls.Add(this.ConsoleTextBox);
            this.ConsoleTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConsoleTabPage.Name = "ConsoleTabPage";
            this.ConsoleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConsoleTabPage.Size = new System.Drawing.Size(743, 294);
            this.ConsoleTabPage.TabIndex = 0;
            this.ConsoleTabPage.Text = "Console";
            this.ConsoleTabPage.UseVisualStyleBackColor = true;
            // 
            // ConsoleClearButton
            // 
            this.ConsoleClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConsoleClearButton.Location = new System.Drawing.Point(6, 261);
            this.ConsoleClearButton.Name = "ConsoleClearButton";
            this.ConsoleClearButton.Size = new System.Drawing.Size(75, 23);
            this.ConsoleClearButton.TabIndex = 3;
            this.ConsoleClearButton.Text = "Clear";
            this.ConsoleClearButton.UseVisualStyleBackColor = true;
            // 
            // ConsoleSendButton
            // 
            this.ConsoleSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleSendButton.Location = new System.Drawing.Point(662, 261);
            this.ConsoleSendButton.Name = "ConsoleSendButton";
            this.ConsoleSendButton.Size = new System.Drawing.Size(75, 23);
            this.ConsoleSendButton.TabIndex = 2;
            this.ConsoleSendButton.Text = "Send";
            this.ConsoleSendButton.UseVisualStyleBackColor = true;
            // 
            // ConsoleInputTextBox
            // 
            this.ConsoleInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleInputTextBox.Location = new System.Drawing.Point(87, 263);
            this.ConsoleInputTextBox.Name = "ConsoleInputTextBox";
            this.ConsoleInputTextBox.Size = new System.Drawing.Size(569, 20);
            this.ConsoleInputTextBox.TabIndex = 1;
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleTextBox.Location = new System.Drawing.Point(6, 6);
            this.ConsoleTextBox.Multiline = true;
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ReadOnly = true;
            this.ConsoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConsoleTextBox.Size = new System.Drawing.Size(731, 251);
            this.ConsoleTextBox.TabIndex = 0;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.ConsoleTabPage);
            this.MainTabControl.Controls.Add(this.ResourcesTabPage);
            this.MainTabControl.Controls.Add(this.ConfigurationTabPage);
            this.MainTabControl.Controls.Add(this.BuildsTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(36, 70);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(751, 320);
            this.MainTabControl.TabIndex = 3;
            // 
            // ResourcesTabPage
            // 
            this.ResourcesTabPage.Controls.Add(this.InstalledGroupBox);
            this.ResourcesTabPage.Controls.Add(this.InstallerGroupBox);
            this.ResourcesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ResourcesTabPage.Name = "ResourcesTabPage";
            this.ResourcesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResourcesTabPage.Size = new System.Drawing.Size(743, 294);
            this.ResourcesTabPage.TabIndex = 2;
            this.ResourcesTabPage.Text = "Resources";
            this.ResourcesTabPage.UseVisualStyleBackColor = true;
            // 
            // InstalledGroupBox
            // 
            this.InstalledGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InstalledGroupBox.Controls.Add(this.ResourceRestartButton);
            this.InstalledGroupBox.Controls.Add(this.ResourceStopButton);
            this.InstalledGroupBox.Controls.Add(this.ResourceStartButton);
            this.InstalledGroupBox.Controls.Add(this.InstalledRefreshButton);
            this.InstalledGroupBox.Controls.Add(this.InstalledListBox);
            this.InstalledGroupBox.Controls.Add(this.InstalledUninstallButton);
            this.InstalledGroupBox.Location = new System.Drawing.Point(6, 6);
            this.InstalledGroupBox.Name = "InstalledGroupBox";
            this.InstalledGroupBox.Size = new System.Drawing.Size(262, 267);
            this.InstalledGroupBox.TabIndex = 2;
            this.InstalledGroupBox.TabStop = false;
            this.InstalledGroupBox.Text = "Installed";
            // 
            // ResourceRestartButton
            // 
            this.ResourceRestartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourceRestartButton.Location = new System.Drawing.Point(89, 209);
            this.ResourceRestartButton.Name = "ResourceRestartButton";
            this.ResourceRestartButton.Size = new System.Drawing.Size(84, 23);
            this.ResourceRestartButton.TabIndex = 5;
            this.ResourceRestartButton.Text = "Restart";
            this.ResourceRestartButton.UseVisualStyleBackColor = true;
            // 
            // ResourceStopButton
            // 
            this.ResourceStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourceStopButton.Location = new System.Drawing.Point(179, 209);
            this.ResourceStopButton.Name = "ResourceStopButton";
            this.ResourceStopButton.Size = new System.Drawing.Size(77, 23);
            this.ResourceStopButton.TabIndex = 4;
            this.ResourceStopButton.Text = "Stop";
            this.ResourceStopButton.UseVisualStyleBackColor = true;
            // 
            // ResourceStartButton
            // 
            this.ResourceStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResourceStartButton.Location = new System.Drawing.Point(6, 209);
            this.ResourceStartButton.Name = "ResourceStartButton";
            this.ResourceStartButton.Size = new System.Drawing.Size(77, 23);
            this.ResourceStartButton.TabIndex = 3;
            this.ResourceStartButton.Text = "Start";
            this.ResourceStartButton.UseVisualStyleBackColor = true;
            // 
            // InstalledRefreshButton
            // 
            this.InstalledRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InstalledRefreshButton.Location = new System.Drawing.Point(6, 238);
            this.InstalledRefreshButton.Name = "InstalledRefreshButton";
            this.InstalledRefreshButton.Size = new System.Drawing.Size(122, 23);
            this.InstalledRefreshButton.TabIndex = 2;
            this.InstalledRefreshButton.Text = "Refresh";
            this.InstalledRefreshButton.UseVisualStyleBackColor = true;
            // 
            // InstalledListBox
            // 
            this.InstalledListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstalledListBox.FormattingEnabled = true;
            this.InstalledListBox.Location = new System.Drawing.Point(6, 19);
            this.InstalledListBox.Name = "InstalledListBox";
            this.InstalledListBox.Size = new System.Drawing.Size(250, 186);
            this.InstalledListBox.TabIndex = 1;
            // 
            // InstalledUninstallButton
            // 
            this.InstalledUninstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InstalledUninstallButton.Enabled = false;
            this.InstalledUninstallButton.Location = new System.Drawing.Point(134, 238);
            this.InstalledUninstallButton.Name = "InstalledUninstallButton";
            this.InstalledUninstallButton.Size = new System.Drawing.Size(122, 23);
            this.InstalledUninstallButton.TabIndex = 0;
            this.InstalledUninstallButton.Text = "Uninstall";
            this.InstalledUninstallButton.UseVisualStyleBackColor = true;
            // 
            // InstallerGroupBox
            // 
            this.InstallerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerGroupBox.Controls.Add(this.InstallerInstallButton);
            this.InstallerGroupBox.Controls.Add(this.InstallerRefreshButton);
            this.InstallerGroupBox.Controls.Add(this.InstallerVersionsListBox);
            this.InstallerGroupBox.Controls.Add(this.InstallerResourcesListBox);
            this.InstallerGroupBox.Location = new System.Drawing.Point(281, 6);
            this.InstallerGroupBox.Name = "InstallerGroupBox";
            this.InstallerGroupBox.Size = new System.Drawing.Size(456, 267);
            this.InstallerGroupBox.TabIndex = 0;
            this.InstallerGroupBox.TabStop = false;
            this.InstallerGroupBox.Text = "Available for Installation";
            // 
            // InstallerInstallButton
            // 
            this.InstallerInstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerInstallButton.Enabled = false;
            this.InstallerInstallButton.Location = new System.Drawing.Point(262, 238);
            this.InstallerInstallButton.Name = "InstallerInstallButton";
            this.InstallerInstallButton.Size = new System.Drawing.Size(188, 23);
            this.InstallerInstallButton.TabIndex = 0;
            this.InstallerInstallButton.Text = "Install";
            this.InstallerInstallButton.UseVisualStyleBackColor = true;
            // 
            // InstallerRefreshButton
            // 
            this.InstallerRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerRefreshButton.Location = new System.Drawing.Point(6, 238);
            this.InstallerRefreshButton.Name = "InstallerRefreshButton";
            this.InstallerRefreshButton.Size = new System.Drawing.Size(250, 23);
            this.InstallerRefreshButton.TabIndex = 2;
            this.InstallerRefreshButton.Text = "Refresh";
            this.InstallerRefreshButton.UseVisualStyleBackColor = true;
            // 
            // InstallerVersionsListBox
            // 
            this.InstallerVersionsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerVersionsListBox.FormattingEnabled = true;
            this.InstallerVersionsListBox.Location = new System.Drawing.Point(262, 19);
            this.InstallerVersionsListBox.Name = "InstallerVersionsListBox";
            this.InstallerVersionsListBox.Size = new System.Drawing.Size(188, 212);
            this.InstallerVersionsListBox.TabIndex = 1;
            // 
            // InstallerResourcesListBox
            // 
            this.InstallerResourcesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerResourcesListBox.FormattingEnabled = true;
            this.InstallerResourcesListBox.Location = new System.Drawing.Point(6, 19);
            this.InstallerResourcesListBox.Name = "InstallerResourcesListBox";
            this.InstallerResourcesListBox.Size = new System.Drawing.Size(250, 212);
            this.InstallerResourcesListBox.TabIndex = 0;
            // 
            // ConfigurationTabPage
            // 
            this.ConfigurationTabPage.Controls.Add(this.ConfigurationSaveButton);
            this.ConfigurationTabPage.Controls.Add(this.ConfigurationGenerateButton);
            this.ConfigurationTabPage.Controls.Add(this.ConfigurationLoadButton);
            this.ConfigurationTabPage.Controls.Add(this.ConfigurationTextBox);
            this.ConfigurationTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConfigurationTabPage.Name = "ConfigurationTabPage";
            this.ConfigurationTabPage.Size = new System.Drawing.Size(743, 294);
            this.ConfigurationTabPage.TabIndex = 3;
            this.ConfigurationTabPage.Text = "Server Configuration";
            this.ConfigurationTabPage.UseVisualStyleBackColor = true;
            // 
            // ConfigurationSaveButton
            // 
            this.ConfigurationSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigurationSaveButton.Location = new System.Drawing.Point(665, 61);
            this.ConfigurationSaveButton.Name = "ConfigurationSaveButton";
            this.ConfigurationSaveButton.Size = new System.Drawing.Size(75, 23);
            this.ConfigurationSaveButton.TabIndex = 3;
            this.ConfigurationSaveButton.Text = "Save";
            this.ConfigurationSaveButton.UseVisualStyleBackColor = true;
            // 
            // ConfigurationGenerateButton
            // 
            this.ConfigurationGenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigurationGenerateButton.Location = new System.Drawing.Point(665, 32);
            this.ConfigurationGenerateButton.Name = "ConfigurationGenerateButton";
            this.ConfigurationGenerateButton.Size = new System.Drawing.Size(75, 23);
            this.ConfigurationGenerateButton.TabIndex = 2;
            this.ConfigurationGenerateButton.Text = "Generate";
            this.ConfigurationGenerateButton.UseVisualStyleBackColor = true;
            // 
            // ConfigurationLoadButton
            // 
            this.ConfigurationLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigurationLoadButton.Location = new System.Drawing.Point(665, 3);
            this.ConfigurationLoadButton.Name = "ConfigurationLoadButton";
            this.ConfigurationLoadButton.Size = new System.Drawing.Size(75, 23);
            this.ConfigurationLoadButton.TabIndex = 1;
            this.ConfigurationLoadButton.Text = "Load";
            this.ConfigurationLoadButton.UseVisualStyleBackColor = true;
            // 
            // ConfigurationTextBox
            // 
            this.ConfigurationTextBox.AcceptsReturn = true;
            this.ConfigurationTextBox.AcceptsTab = true;
            this.ConfigurationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigurationTextBox.Location = new System.Drawing.Point(2, 3);
            this.ConfigurationTextBox.Multiline = true;
            this.ConfigurationTextBox.Name = "ConfigurationTextBox";
            this.ConfigurationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConfigurationTextBox.Size = new System.Drawing.Size(657, 265);
            this.ConfigurationTextBox.TabIndex = 0;
            this.ConfigurationTextBox.WordWrap = false;
            // 
            // BuildsTabPage
            // 
            this.BuildsTabPage.Controls.Add(this.BuildDownloadButton);
            this.BuildsTabPage.Controls.Add(this.BuildBrowserButton);
            this.BuildsTabPage.Controls.Add(this.BuildsImportButton);
            this.BuildsTabPage.Controls.Add(this.BuildsRefreshButton);
            this.BuildsTabPage.Controls.Add(this.BuildsGroupBox);
            this.BuildsTabPage.Location = new System.Drawing.Point(4, 22);
            this.BuildsTabPage.Name = "BuildsTabPage";
            this.BuildsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BuildsTabPage.Size = new System.Drawing.Size(743, 294);
            this.BuildsTabPage.TabIndex = 5;
            this.BuildsTabPage.Text = "Build Selector";
            this.BuildsTabPage.UseVisualStyleBackColor = true;
            // 
            // BuildDownloadButton
            // 
            this.BuildDownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildDownloadButton.Location = new System.Drawing.Point(587, 93);
            this.BuildDownloadButton.Name = "BuildDownloadButton";
            this.BuildDownloadButton.Size = new System.Drawing.Size(150, 23);
            this.BuildDownloadButton.TabIndex = 4;
            this.BuildDownloadButton.Text = "Download";
            this.BuildDownloadButton.UseVisualStyleBackColor = true;
            // 
            // BuildBrowserButton
            // 
            this.BuildBrowserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildBrowserButton.Location = new System.Drawing.Point(587, 64);
            this.BuildBrowserButton.Name = "BuildBrowserButton";
            this.BuildBrowserButton.Size = new System.Drawing.Size(150, 23);
            this.BuildBrowserButton.TabIndex = 3;
            this.BuildBrowserButton.Text = "Open in Browser";
            this.BuildBrowserButton.UseVisualStyleBackColor = true;
            // 
            // BuildsImportButton
            // 
            this.BuildsImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsImportButton.Location = new System.Drawing.Point(587, 35);
            this.BuildsImportButton.Name = "BuildsImportButton";
            this.BuildsImportButton.Size = new System.Drawing.Size(150, 23);
            this.BuildsImportButton.TabIndex = 2;
            this.BuildsImportButton.Text = "Import Build from ZIP";
            this.BuildsImportButton.UseVisualStyleBackColor = true;
            // 
            // GeneralProgressBar
            // 
            this.GeneralProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralProgressBar.Location = new System.Drawing.Point(36, 396);
            this.GeneralProgressBar.Name = "GeneralProgressBar";
            this.GeneralProgressBar.Size = new System.Drawing.Size(751, 23);
            this.GeneralProgressBar.TabIndex = 4;
            // 
            // BottomStrip
            // 
            this.BottomStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BottomToolStripStatusLabel});
            this.BottomStrip.Location = new System.Drawing.Point(12, 422);
            this.BottomStrip.Name = "BottomStrip";
            this.BottomStrip.Size = new System.Drawing.Size(787, 22);
            this.BottomStrip.TabIndex = 5;
            // 
            // BottomToolStripStatusLabel
            // 
            this.BottomToolStripStatusLabel.Name = "BottomToolStripStatusLabel";
            this.BottomToolStripStatusLabel.Size = new System.Drawing.Size(151, 17);
            this.BottomToolStripStatusLabel.Text = "Welcome to LambentLight!";
            // 
            // BuildFileDialog
            // 
            this.BuildFileDialog.Filter = "All Supported Compressed Files|*.zip";
            // 
            // FormManager
            // 
            this.AcceptButton = this.ConsoleSendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 444);
            this.Controls.Add(this.BottomStrip);
            this.Controls.Add(this.GeneralProgressBar);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.DataFolderGroupBox);
            this.Controls.Add(this.TopMenuStrip);
            this.MainMenuStrip = this.TopMenuStrip;
            this.MinimumSize = new System.Drawing.Size(815, 483);
            this.Name = "FormManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LambentLight: Connected to";
            this.BuildsGroupBox.ResumeLayout(false);
            this.DataFolderGroupBox.ResumeLayout(false);
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.ConsoleTabPage.ResumeLayout(false);
            this.ConsoleTabPage.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.ResourcesTabPage.ResumeLayout(false);
            this.InstalledGroupBox.ResumeLayout(false);
            this.InstallerGroupBox.ResumeLayout(false);
            this.ConfigurationTabPage.ResumeLayout(false);
            this.ConfigurationTabPage.PerformLayout();
            this.BuildsTabPage.ResumeLayout(false);
            this.BottomStrip.ResumeLayout(false);
            this.BottomStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox BuildsGroupBox;
        private System.Windows.Forms.GroupBox DataFolderGroupBox;
        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopToolStripMenuItem;
        private System.Windows.Forms.TabPage ConsoleTabPage;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.Button BuildsRefreshButton;
        private System.Windows.Forms.Button DataFolderRefreshButton;
        private System.Windows.Forms.TabPage ResourcesTabPage;
        private System.Windows.Forms.GroupBox InstallerGroupBox;
        private System.Windows.Forms.Button InstallerInstallButton;
        private System.Windows.Forms.ListBox InstallerVersionsListBox;
        private System.Windows.Forms.ListBox InstallerResourcesListBox;
        private System.Windows.Forms.Button InstallerRefreshButton;
        public System.Windows.Forms.ProgressBar GeneralProgressBar;
        private System.Windows.Forms.StatusStrip BottomStrip;
        private System.Windows.Forms.TabPage ConfigurationTabPage;
        private System.Windows.Forms.Button ConfigurationLoadButton;
        private System.Windows.Forms.TextBox ConfigurationTextBox;
        private System.Windows.Forms.Button ConfigurationGenerateButton;
        private System.Windows.Forms.Button ConfigurationSaveButton;
        private System.Windows.Forms.Button ConsoleSendButton;
        private System.Windows.Forms.TextBox ConsoleInputTextBox;
        private System.Windows.Forms.GroupBox InstalledGroupBox;
        private System.Windows.Forms.Button InstalledUninstallButton;
        private System.Windows.Forms.ListBox InstalledListBox;
        private System.Windows.Forms.Button InstalledRefreshButton;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.TabPage BuildsTabPage;
        private System.Windows.Forms.Button DataFolderBrowseButton;
        private System.Windows.Forms.Button ConsoleClearButton;
        private System.Windows.Forms.Button BuildsImportButton;
        private System.Windows.Forms.OpenFileDialog BuildFileDialog;
        private System.Windows.Forms.ToolStripMenuItem RestartToolStripMenuItem;
        private System.Windows.Forms.Button ResourceRestartButton;
        private System.Windows.Forms.Button ResourceStopButton;
        private System.Windows.Forms.Button ResourceStartButton;
        internal System.Windows.Forms.ListBox BuildsListBox;
        internal System.Windows.Forms.ComboBox DataFolderComboBox;
        private System.Windows.Forms.Button BuildBrowserButton;
        private System.Windows.Forms.Button BuildDownloadButton;
        private System.Windows.Forms.Button DataFolderDeleteButton;
        internal System.Windows.Forms.TextBox ConsoleTextBox;
        internal System.Windows.Forms.ToolStripStatusLabel BottomToolStripStatusLabel;
    }
}

