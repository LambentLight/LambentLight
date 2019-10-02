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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Landing));
            this.BuildsGroup = new System.Windows.Forms.GroupBox();
            this.BuildsListBox = new System.Windows.Forms.ListBox();
            this.BuildRefreshButton = new System.Windows.Forms.Button();
            this.DataGroup = new System.Windows.Forms.GroupBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FolderRefreshButton = new System.Windows.Forms.Button();
            this.DataBox = new System.Windows.Forms.ComboBox();
            this.TopStrip = new System.Windows.Forms.MenuStrip();
            this.StartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogsTab = new System.Windows.Forms.TabPage();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.ConsoleButton = new System.Windows.Forms.Button();
            this.ConsoleTextBox = new System.Windows.Forms.TextBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.ResourcesTab = new System.Windows.Forms.TabPage();
            this.UninstallerGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshUninstallerButton = new System.Windows.Forms.Button();
            this.UninstallerListBox = new System.Windows.Forms.ListBox();
            this.UninstallButton = new System.Windows.Forms.Button();
            this.InstallerListGroup = new System.Windows.Forms.GroupBox();
            this.InstallButton = new System.Windows.Forms.Button();
            this.RefreshInstallButton = new System.Windows.Forms.Button();
            this.VersionsListBox = new System.Windows.Forms.ListBox();
            this.InstallerListBox = new System.Windows.Forms.ListBox();
            this.ConfigurationTab = new System.Windows.Forms.TabPage();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ConfigTextBox = new System.Windows.Forms.TextBox();
            this.BuildsTabPage = new System.Windows.Forms.TabPage();
            this.BuildImportButton = new System.Windows.Forms.Button();
            this.AboutTab = new System.Windows.Forms.TabPage();
            this.AboutRichTextBox = new System.Windows.Forms.RichTextBox();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.BottomStrip = new System.Windows.Forms.StatusStrip();
            this.BottomStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BuildFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RestartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildsGroup.SuspendLayout();
            this.DataGroup.SuspendLayout();
            this.TopStrip.SuspendLayout();
            this.LogsTab.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.ResourcesTab.SuspendLayout();
            this.UninstallerGroupBox.SuspendLayout();
            this.InstallerListGroup.SuspendLayout();
            this.ConfigurationTab.SuspendLayout();
            this.BuildsTabPage.SuspendLayout();
            this.AboutTab.SuspendLayout();
            this.BottomStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildsGroup
            // 
            this.BuildsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsGroup.Controls.Add(this.BuildsListBox);
            this.BuildsGroup.Location = new System.Drawing.Point(6, 6);
            this.BuildsGroup.Name = "BuildsGroup";
            this.BuildsGroup.Size = new System.Drawing.Size(599, 267);
            this.BuildsGroup.TabIndex = 0;
            this.BuildsGroup.TabStop = false;
            this.BuildsGroup.Text = "Builds Available";
            // 
            // BuildsListBox
            // 
            this.BuildsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsListBox.FormattingEnabled = true;
            this.BuildsListBox.Location = new System.Drawing.Point(6, 19);
            this.BuildsListBox.Name = "BuildsListBox";
            this.BuildsListBox.Size = new System.Drawing.Size(587, 238);
            this.BuildsListBox.TabIndex = 2;
            // 
            // BuildRefreshButton
            // 
            this.BuildRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildRefreshButton.Location = new System.Drawing.Point(611, 6);
            this.BuildRefreshButton.Name = "BuildRefreshButton";
            this.BuildRefreshButton.Size = new System.Drawing.Size(150, 23);
            this.BuildRefreshButton.TabIndex = 1;
            this.BuildRefreshButton.Text = "Refresh";
            this.BuildRefreshButton.UseVisualStyleBackColor = true;
            this.BuildRefreshButton.Click += new System.EventHandler(this.BuildRefreshButton_Click);
            // 
            // DataGroup
            // 
            this.DataGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGroup.Controls.Add(this.BrowseButton);
            this.DataGroup.Controls.Add(this.FolderRefreshButton);
            this.DataGroup.Controls.Add(this.DataBox);
            this.DataGroup.Location = new System.Drawing.Point(12, 27);
            this.DataGroup.Name = "DataGroup";
            this.DataGroup.Size = new System.Drawing.Size(775, 52);
            this.DataGroup.TabIndex = 1;
            this.DataGroup.TabStop = false;
            this.DataGroup.Text = "Data Folder";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(613, 18);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FolderRefreshButton
            // 
            this.FolderRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderRefreshButton.Location = new System.Drawing.Point(694, 18);
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
            this.DataBox.Size = new System.Drawing.Size(601, 21);
            this.DataBox.TabIndex = 0;
            this.DataBox.SelectedIndexChanged += new System.EventHandler(this.DataBox_SelectedIndexChanged);
            // 
            // TopStrip
            // 
            this.TopStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartItem,
            this.StopItem,
            this.RestartItem,
            this.CreateItem,
            this.SettingsToolStripMenuItem,
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
            // RestartItem
            // 
            this.RestartItem.Image = global::LambentLight.Properties.Resources.Play;
            this.RestartItem.Name = "RestartItem";
            this.RestartItem.Size = new System.Drawing.Size(106, 20);
            this.RestartItem.Text = "Restart Server";
            this.RestartItem.Click += new System.EventHandler(this.RestartItem_Click);
            // 
            // CreateItem
            // 
            this.CreateItem.Image = global::LambentLight.Properties.Resources.Add;
            this.CreateItem.Name = "CreateItem";
            this.CreateItem.Size = new System.Drawing.Size(132, 20);
            this.CreateItem.Text = "Create Data Folder";
            this.CreateItem.Click += new System.EventHandler(this.CreateItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Image = global::LambentLight.Properties.Resources.Settings;
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.SettingsToolStripMenuItem.Text = "Application Settings";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
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
            this.LogsTab.Controls.Add(this.ClearLogButton);
            this.LogsTab.Controls.Add(this.ConsoleButton);
            this.LogsTab.Controls.Add(this.ConsoleTextBox);
            this.LogsTab.Controls.Add(this.LogTextBox);
            this.LogsTab.Location = new System.Drawing.Point(4, 22);
            this.LogsTab.Name = "LogsTab";
            this.LogsTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogsTab.Size = new System.Drawing.Size(767, 279);
            this.LogsTab.TabIndex = 0;
            this.LogsTab.Text = "Logs";
            this.LogsTab.UseVisualStyleBackColor = true;
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearLogButton.Location = new System.Drawing.Point(6, 246);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(75, 23);
            this.ClearLogButton.TabIndex = 3;
            this.ClearLogButton.Text = "Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // ConsoleButton
            // 
            this.ConsoleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleButton.Location = new System.Drawing.Point(686, 246);
            this.ConsoleButton.Name = "ConsoleButton";
            this.ConsoleButton.Size = new System.Drawing.Size(75, 23);
            this.ConsoleButton.TabIndex = 2;
            this.ConsoleButton.Text = "Send";
            this.ConsoleButton.UseVisualStyleBackColor = true;
            this.ConsoleButton.Click += new System.EventHandler(this.ConsoleButton_Click);
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleTextBox.Location = new System.Drawing.Point(87, 248);
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.Size = new System.Drawing.Size(593, 20);
            this.ConsoleTextBox.TabIndex = 1;
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
            this.LogTextBox.Size = new System.Drawing.Size(755, 236);
            this.LogTextBox.TabIndex = 0;
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.LogsTab);
            this.Tabs.Controls.Add(this.ResourcesTab);
            this.Tabs.Controls.Add(this.ConfigurationTab);
            this.Tabs.Controls.Add(this.BuildsTabPage);
            this.Tabs.Controls.Add(this.AboutTab);
            this.Tabs.Location = new System.Drawing.Point(12, 85);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(775, 305);
            this.Tabs.TabIndex = 3;
            this.Tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.Tabs_Selected);
            // 
            // ResourcesTab
            // 
            this.ResourcesTab.Controls.Add(this.UninstallerGroupBox);
            this.ResourcesTab.Controls.Add(this.InstallerListGroup);
            this.ResourcesTab.Location = new System.Drawing.Point(4, 22);
            this.ResourcesTab.Name = "ResourcesTab";
            this.ResourcesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ResourcesTab.Size = new System.Drawing.Size(767, 279);
            this.ResourcesTab.TabIndex = 2;
            this.ResourcesTab.Text = "Resources";
            this.ResourcesTab.UseVisualStyleBackColor = true;
            // 
            // UninstallerGroupBox
            // 
            this.UninstallerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UninstallerGroupBox.Controls.Add(this.RefreshUninstallerButton);
            this.UninstallerGroupBox.Controls.Add(this.UninstallerListBox);
            this.UninstallerGroupBox.Controls.Add(this.UninstallButton);
            this.UninstallerGroupBox.Location = new System.Drawing.Point(6, 6);
            this.UninstallerGroupBox.Name = "UninstallerGroupBox";
            this.UninstallerGroupBox.Size = new System.Drawing.Size(262, 267);
            this.UninstallerGroupBox.TabIndex = 2;
            this.UninstallerGroupBox.TabStop = false;
            this.UninstallerGroupBox.Text = "Installed";
            // 
            // RefreshUninstallerButton
            // 
            this.RefreshUninstallerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshUninstallerButton.Location = new System.Drawing.Point(6, 238);
            this.RefreshUninstallerButton.Name = "RefreshUninstallerButton";
            this.RefreshUninstallerButton.Size = new System.Drawing.Size(122, 23);
            this.RefreshUninstallerButton.TabIndex = 2;
            this.RefreshUninstallerButton.Text = "Refresh";
            this.RefreshUninstallerButton.UseVisualStyleBackColor = true;
            this.RefreshUninstallerButton.Click += new System.EventHandler(this.RefreshUninstallerButton_Click);
            // 
            // UninstallerListBox
            // 
            this.UninstallerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UninstallerListBox.FormattingEnabled = true;
            this.UninstallerListBox.Location = new System.Drawing.Point(6, 19);
            this.UninstallerListBox.Name = "UninstallerListBox";
            this.UninstallerListBox.Size = new System.Drawing.Size(250, 212);
            this.UninstallerListBox.TabIndex = 1;
            this.UninstallerListBox.SelectedIndexChanged += new System.EventHandler(this.UninstallerListBox_SelectedIndexChanged);
            // 
            // UninstallButton
            // 
            this.UninstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UninstallButton.Enabled = false;
            this.UninstallButton.Location = new System.Drawing.Point(134, 238);
            this.UninstallButton.Name = "UninstallButton";
            this.UninstallButton.Size = new System.Drawing.Size(122, 23);
            this.UninstallButton.TabIndex = 0;
            this.UninstallButton.Text = "Uninstall";
            this.UninstallButton.UseVisualStyleBackColor = true;
            this.UninstallButton.Click += new System.EventHandler(this.UninstallButton_Click);
            // 
            // InstallerListGroup
            // 
            this.InstallerListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerListGroup.Controls.Add(this.InstallButton);
            this.InstallerListGroup.Controls.Add(this.RefreshInstallButton);
            this.InstallerListGroup.Controls.Add(this.VersionsListBox);
            this.InstallerListGroup.Controls.Add(this.InstallerListBox);
            this.InstallerListGroup.Location = new System.Drawing.Point(305, 6);
            this.InstallerListGroup.Name = "InstallerListGroup";
            this.InstallerListGroup.Size = new System.Drawing.Size(456, 267);
            this.InstallerListGroup.TabIndex = 0;
            this.InstallerListGroup.TabStop = false;
            this.InstallerListGroup.Text = "Available for Installation";
            // 
            // InstallButton
            // 
            this.InstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallButton.Enabled = false;
            this.InstallButton.Location = new System.Drawing.Point(262, 238);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(188, 23);
            this.InstallButton.TabIndex = 0;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // RefreshInstallButton
            // 
            this.RefreshInstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshInstallButton.Location = new System.Drawing.Point(6, 238);
            this.RefreshInstallButton.Name = "RefreshInstallButton";
            this.RefreshInstallButton.Size = new System.Drawing.Size(250, 23);
            this.RefreshInstallButton.TabIndex = 2;
            this.RefreshInstallButton.Text = "Refresh";
            this.RefreshInstallButton.UseVisualStyleBackColor = true;
            this.RefreshInstallButton.Click += new System.EventHandler(this.RefreshInstallerButton_Click);
            // 
            // VersionsListBox
            // 
            this.VersionsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionsListBox.FormattingEnabled = true;
            this.VersionsListBox.Location = new System.Drawing.Point(262, 19);
            this.VersionsListBox.Name = "VersionsListBox";
            this.VersionsListBox.Size = new System.Drawing.Size(188, 212);
            this.VersionsListBox.TabIndex = 1;
            this.VersionsListBox.SelectedIndexChanged += new System.EventHandler(this.VersionsListBox_SelectedIndexChanged);
            // 
            // InstallerListBox
            // 
            this.InstallerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerListBox.FormattingEnabled = true;
            this.InstallerListBox.Location = new System.Drawing.Point(6, 19);
            this.InstallerListBox.Name = "InstallerListBox";
            this.InstallerListBox.Size = new System.Drawing.Size(250, 212);
            this.InstallerListBox.TabIndex = 0;
            this.InstallerListBox.SelectedIndexChanged += new System.EventHandler(this.InstallerListBox_SelectedIndexChanged);
            // 
            // ConfigurationTab
            // 
            this.ConfigurationTab.Controls.Add(this.SaveButton);
            this.ConfigurationTab.Controls.Add(this.GenerateButton);
            this.ConfigurationTab.Controls.Add(this.LoadButton);
            this.ConfigurationTab.Controls.Add(this.ConfigTextBox);
            this.ConfigurationTab.Location = new System.Drawing.Point(4, 22);
            this.ConfigurationTab.Name = "ConfigurationTab";
            this.ConfigurationTab.Size = new System.Drawing.Size(767, 279);
            this.ConfigurationTab.TabIndex = 3;
            this.ConfigurationTab.Text = "Server Configuration";
            this.ConfigurationTab.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(689, 61);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateButton.Location = new System.Drawing.Point(689, 32);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 2;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadButton.Location = new System.Drawing.Point(689, 3);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ConfigTextBox
            // 
            this.ConfigTextBox.AcceptsReturn = true;
            this.ConfigTextBox.AcceptsTab = true;
            this.ConfigTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigTextBox.Location = new System.Drawing.Point(2, 3);
            this.ConfigTextBox.Multiline = true;
            this.ConfigTextBox.Name = "ConfigTextBox";
            this.ConfigTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConfigTextBox.Size = new System.Drawing.Size(681, 265);
            this.ConfigTextBox.TabIndex = 0;
            this.ConfigTextBox.WordWrap = false;
            // 
            // BuildsTabPage
            // 
            this.BuildsTabPage.Controls.Add(this.BuildImportButton);
            this.BuildsTabPage.Controls.Add(this.BuildRefreshButton);
            this.BuildsTabPage.Controls.Add(this.BuildsGroup);
            this.BuildsTabPage.Location = new System.Drawing.Point(4, 22);
            this.BuildsTabPage.Name = "BuildsTabPage";
            this.BuildsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BuildsTabPage.Size = new System.Drawing.Size(767, 279);
            this.BuildsTabPage.TabIndex = 5;
            this.BuildsTabPage.Text = "Build Selector";
            this.BuildsTabPage.UseVisualStyleBackColor = true;
            // 
            // BuildImportButton
            // 
            this.BuildImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildImportButton.Location = new System.Drawing.Point(611, 35);
            this.BuildImportButton.Name = "BuildImportButton";
            this.BuildImportButton.Size = new System.Drawing.Size(150, 23);
            this.BuildImportButton.TabIndex = 2;
            this.BuildImportButton.Text = "Import Build";
            this.BuildImportButton.UseVisualStyleBackColor = true;
            this.BuildImportButton.Click += new System.EventHandler(this.BuildImportButton_Click);
            // 
            // AboutTab
            // 
            this.AboutTab.Controls.Add(this.AboutRichTextBox);
            this.AboutTab.Location = new System.Drawing.Point(4, 22);
            this.AboutTab.Name = "AboutTab";
            this.AboutTab.Padding = new System.Windows.Forms.Padding(3);
            this.AboutTab.Size = new System.Drawing.Size(767, 279);
            this.AboutTab.TabIndex = 4;
            this.AboutTab.Text = "About";
            this.AboutTab.UseVisualStyleBackColor = true;
            // 
            // AboutRichTextBox
            // 
            this.AboutRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AboutRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AboutRichTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AboutRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.AboutRichTextBox.Name = "AboutRichTextBox";
            this.AboutRichTextBox.ReadOnly = true;
            this.AboutRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.AboutRichTextBox.Size = new System.Drawing.Size(761, 273);
            this.AboutRichTextBox.TabIndex = 0;
            this.AboutRichTextBox.Text = "";
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainProgressBar.Location = new System.Drawing.Point(12, 396);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(775, 23);
            this.MainProgressBar.TabIndex = 4;
            // 
            // BottomStrip
            // 
            this.BottomStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BottomStripLabel});
            this.BottomStrip.Location = new System.Drawing.Point(0, 422);
            this.BottomStrip.Name = "BottomStrip";
            this.BottomStrip.Size = new System.Drawing.Size(799, 22);
            this.BottomStrip.TabIndex = 5;
            // 
            // BottomStripLabel
            // 
            this.BottomStripLabel.Name = "BottomStripLabel";
            this.BottomStripLabel.Size = new System.Drawing.Size(151, 17);
            this.BottomStripLabel.Text = "Welcome to LambentLight!";
            // 
            // BuildFileDialog
            // 
            this.BuildFileDialog.Filter = "All Supported Compressed Files|*.zip";
            // 
            // Landing
            // 
            this.AcceptButton = this.ConsoleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 444);
            this.Controls.Add(this.BottomStrip);
            this.Controls.Add(this.MainProgressBar);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.DataGroup);
            this.Controls.Add(this.TopStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TopStrip;
            this.MinimumSize = new System.Drawing.Size(815, 483);
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
            this.ResourcesTab.ResumeLayout(false);
            this.UninstallerGroupBox.ResumeLayout(false);
            this.InstallerListGroup.ResumeLayout(false);
            this.ConfigurationTab.ResumeLayout(false);
            this.ConfigurationTab.PerformLayout();
            this.BuildsTabPage.ResumeLayout(false);
            this.AboutTab.ResumeLayout(false);
            this.BottomStrip.ResumeLayout(false);
            this.BottomStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox BuildsGroup;
        private System.Windows.Forms.GroupBox DataGroup;
        private System.Windows.Forms.ComboBox DataBox;
        private System.Windows.Forms.MenuStrip TopStrip;
        private System.Windows.Forms.ToolStripMenuItem StartItem;
        private System.Windows.Forms.ToolStripMenuItem StopItem;
        private System.Windows.Forms.ToolStripMenuItem RestartItem;
        private System.Windows.Forms.TabPage LogsTab;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.ToolStripMenuItem CreateItem;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.Button BuildRefreshButton;
        private System.Windows.Forms.Button FolderRefreshButton;
        private System.Windows.Forms.TabPage ResourcesTab;
        private System.Windows.Forms.GroupBox InstallerListGroup;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.ListBox VersionsListBox;
        private System.Windows.Forms.ListBox InstallerListBox;
        private System.Windows.Forms.Button RefreshInstallButton;
        public System.Windows.Forms.TextBox LogTextBox;
        public System.Windows.Forms.ProgressBar MainProgressBar;
        private System.Windows.Forms.StatusStrip BottomStrip;
        public System.Windows.Forms.ToolStripStatusLabel BottomStripLabel;
        private System.Windows.Forms.TabPage ConfigurationTab;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox ConfigTextBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ConsoleButton;
        private System.Windows.Forms.TextBox ConsoleTextBox;
        private System.Windows.Forms.TabPage AboutTab;
        private System.Windows.Forms.RichTextBox AboutRichTextBox;
        private System.Windows.Forms.GroupBox UninstallerGroupBox;
        private System.Windows.Forms.Button UninstallButton;
        private System.Windows.Forms.ListBox UninstallerListBox;
        private System.Windows.Forms.Button RefreshUninstallerButton;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.TabPage BuildsTabPage;
        private System.Windows.Forms.ListBox BuildsListBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button ClearLogButton;
        private System.Windows.Forms.Button BuildImportButton;
        private System.Windows.Forms.OpenFileDialog BuildFileDialog;
    }
}

