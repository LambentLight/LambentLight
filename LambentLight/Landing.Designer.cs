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
            this.ConsoleButton = new System.Windows.Forms.Button();
            this.ConsoleTextBox = new System.Windows.Forms.TextBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.ResourcesTab = new System.Windows.Forms.TabPage();
            this.VersionListGroup = new System.Windows.Forms.GroupBox();
            this.VersionsListBox = new System.Windows.Forms.ListBox();
            this.InstallButton = new System.Windows.Forms.Button();
            this.InstallerListGroup = new System.Windows.Forms.GroupBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.InstallerListBox = new System.Windows.Forms.ListBox();
            this.ConfigurationTab = new System.Windows.Forms.TabPage();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ConfigTextBox = new System.Windows.Forms.TextBox();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.ResetSettingsButton = new System.Windows.Forms.Button();
            this.AutomatedRestartGroupBox = new System.Windows.Forms.GroupBox();
            this.RestartAtButton = new System.Windows.Forms.Button();
            this.RestartEveryButton = new System.Windows.Forms.Button();
            this.RestartAtTextBox = new System.Windows.Forms.TextBox();
            this.RestartAtCheckBox = new System.Windows.Forms.CheckBox();
            this.RestartEveryTextBox = new System.Windows.Forms.TextBox();
            this.RestartEveryCheckBox = new System.Windows.Forms.CheckBox();
            this.RuntimeGroupBox = new System.Windows.Forms.GroupBox();
            this.ClearCacheCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoRestartCheckBox = new System.Windows.Forms.CheckBox();
            this.FolderCreationGroupBox = new System.Windows.Forms.GroupBox();
            this.CreateConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.DownloadScriptsCheckBox = new System.Windows.Forms.CheckBox();
            this.APIsGroupBox = new System.Windows.Forms.GroupBox();
            this.BuildsLinTextBox = new System.Windows.Forms.TextBox();
            this.BuildsLinLabel = new System.Windows.Forms.Label();
            this.SaveAPIsButton = new System.Windows.Forms.Button();
            this.BuildsWinTextBox = new System.Windows.Forms.TextBox();
            this.BuildsWinLabel = new System.Windows.Forms.Label();
            this.ResourcesTextBox = new System.Windows.Forms.TextBox();
            this.ResourcesLabel = new System.Windows.Forms.Label();
            this.LicenseGroupBox = new System.Windows.Forms.GroupBox();
            this.GenerateLicenseButton = new System.Windows.Forms.Button();
            this.SaveLicenseButton = new System.Windows.Forms.Button();
            this.VisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.LicenseTextBox = new System.Windows.Forms.TextBox();
            this.AboutTab = new System.Windows.Forms.TabPage();
            this.AboutRichTextBox = new System.Windows.Forms.RichTextBox();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.BottomStrip = new System.Windows.Forms.StatusStrip();
            this.BottomStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BuildsGroup.SuspendLayout();
            this.DataGroup.SuspendLayout();
            this.TopStrip.SuspendLayout();
            this.LogsTab.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.ResourcesTab.SuspendLayout();
            this.VersionListGroup.SuspendLayout();
            this.InstallerListGroup.SuspendLayout();
            this.ConfigurationTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.AutomatedRestartGroupBox.SuspendLayout();
            this.RuntimeGroupBox.SuspendLayout();
            this.FolderCreationGroupBox.SuspendLayout();
            this.APIsGroupBox.SuspendLayout();
            this.LicenseGroupBox.SuspendLayout();
            this.AboutTab.SuspendLayout();
            this.BottomStrip.SuspendLayout();
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
            this.ConsoleTextBox.Location = new System.Drawing.Point(6, 248);
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.Size = new System.Drawing.Size(674, 20);
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
            this.Tabs.Controls.Add(this.SettingsTab);
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
            this.ResourcesTab.Controls.Add(this.VersionListGroup);
            this.ResourcesTab.Controls.Add(this.InstallerListGroup);
            this.ResourcesTab.Location = new System.Drawing.Point(4, 22);
            this.ResourcesTab.Name = "ResourcesTab";
            this.ResourcesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ResourcesTab.Size = new System.Drawing.Size(767, 279);
            this.ResourcesTab.TabIndex = 2;
            this.ResourcesTab.Text = "Resources";
            this.ResourcesTab.UseVisualStyleBackColor = true;
            // 
            // VersionListGroup
            // 
            this.VersionListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionListGroup.Controls.Add(this.VersionsListBox);
            this.VersionListGroup.Controls.Add(this.InstallButton);
            this.VersionListGroup.Location = new System.Drawing.Point(391, 6);
            this.VersionListGroup.Name = "VersionListGroup";
            this.VersionListGroup.Size = new System.Drawing.Size(370, 259);
            this.VersionListGroup.TabIndex = 1;
            this.VersionListGroup.TabStop = false;
            this.VersionListGroup.Text = "Versions";
            // 
            // VersionsListBox
            // 
            this.VersionsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionsListBox.FormattingEnabled = true;
            this.VersionsListBox.Location = new System.Drawing.Point(6, 19);
            this.VersionsListBox.Name = "VersionsListBox";
            this.VersionsListBox.Size = new System.Drawing.Size(358, 199);
            this.VersionsListBox.TabIndex = 1;
            this.VersionsListBox.SelectedIndexChanged += new System.EventHandler(this.VersionsListBox_SelectedIndexChanged);
            // 
            // InstallButton
            // 
            this.InstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallButton.Enabled = false;
            this.InstallButton.Location = new System.Drawing.Point(6, 230);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(358, 23);
            this.InstallButton.TabIndex = 0;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // InstallerListGroup
            // 
            this.InstallerListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerListGroup.Controls.Add(this.RefreshButton);
            this.InstallerListGroup.Controls.Add(this.InstallerListBox);
            this.InstallerListGroup.Location = new System.Drawing.Point(6, 6);
            this.InstallerListGroup.Name = "InstallerListGroup";
            this.InstallerListGroup.Size = new System.Drawing.Size(370, 259);
            this.InstallerListGroup.TabIndex = 0;
            this.InstallerListGroup.TabStop = false;
            this.InstallerListGroup.Text = "To Be Installed";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Location = new System.Drawing.Point(6, 230);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(358, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // InstallerListBox
            // 
            this.InstallerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallerListBox.FormattingEnabled = true;
            this.InstallerListBox.Location = new System.Drawing.Point(6, 19);
            this.InstallerListBox.Name = "InstallerListBox";
            this.InstallerListBox.Size = new System.Drawing.Size(358, 199);
            this.InstallerListBox.TabIndex = 0;
            this.InstallerListBox.SelectedIndexChanged += new System.EventHandler(this.ResourcesListBox_SelectedIndexChanged);
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
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.ResetSettingsButton);
            this.SettingsTab.Controls.Add(this.AutomatedRestartGroupBox);
            this.SettingsTab.Controls.Add(this.RuntimeGroupBox);
            this.SettingsTab.Controls.Add(this.FolderCreationGroupBox);
            this.SettingsTab.Controls.Add(this.APIsGroupBox);
            this.SettingsTab.Controls.Add(this.LicenseGroupBox);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(767, 279);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Application Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // ResetSettingsButton
            // 
            this.ResetSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetSettingsButton.Location = new System.Drawing.Point(6, 249);
            this.ResetSettingsButton.Name = "ResetSettingsButton";
            this.ResetSettingsButton.Size = new System.Drawing.Size(755, 23);
            this.ResetSettingsButton.TabIndex = 5;
            this.ResetSettingsButton.Text = "Reset Settings to their Default Values";
            this.ResetSettingsButton.UseVisualStyleBackColor = true;
            this.ResetSettingsButton.Click += new System.EventHandler(this.ResetSettingsButton_Click);
            // 
            // AutomatedRestartGroupBox
            // 
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartAtButton);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartEveryButton);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartAtTextBox);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartAtCheckBox);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartEveryTextBox);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartEveryCheckBox);
            this.AutomatedRestartGroupBox.Location = new System.Drawing.Point(6, 160);
            this.AutomatedRestartGroupBox.Name = "AutomatedRestartGroupBox";
            this.AutomatedRestartGroupBox.Size = new System.Drawing.Size(370, 75);
            this.AutomatedRestartGroupBox.TabIndex = 4;
            this.AutomatedRestartGroupBox.TabStop = false;
            this.AutomatedRestartGroupBox.Text = "Automated Restarts";
            // 
            // RestartAtButton
            // 
            this.RestartAtButton.Location = new System.Drawing.Point(289, 42);
            this.RestartAtButton.Name = "RestartAtButton";
            this.RestartAtButton.Size = new System.Drawing.Size(75, 23);
            this.RestartAtButton.TabIndex = 5;
            this.RestartAtButton.Text = "Save";
            this.RestartAtButton.UseVisualStyleBackColor = true;
            this.RestartAtButton.Click += new System.EventHandler(this.RestartAtButton_Click);
            // 
            // RestartEveryButton
            // 
            this.RestartEveryButton.Location = new System.Drawing.Point(289, 15);
            this.RestartEveryButton.Name = "RestartEveryButton";
            this.RestartEveryButton.Size = new System.Drawing.Size(75, 23);
            this.RestartEveryButton.TabIndex = 4;
            this.RestartEveryButton.Text = "Save";
            this.RestartEveryButton.UseVisualStyleBackColor = true;
            this.RestartEveryButton.Click += new System.EventHandler(this.RestartEveryButton_Click);
            // 
            // RestartAtTextBox
            // 
            this.RestartAtTextBox.Location = new System.Drawing.Point(183, 42);
            this.RestartAtTextBox.Name = "RestartAtTextBox";
            this.RestartAtTextBox.Size = new System.Drawing.Size(100, 20);
            this.RestartAtTextBox.TabIndex = 3;
            this.RestartAtTextBox.Text = "00:00:00";
            // 
            // RestartAtCheckBox
            // 
            this.RestartAtCheckBox.AutoSize = true;
            this.RestartAtCheckBox.Location = new System.Drawing.Point(6, 44);
            this.RestartAtCheckBox.Name = "RestartAtCheckBox";
            this.RestartAtCheckBox.Size = new System.Drawing.Size(96, 17);
            this.RestartAtCheckBox.TabIndex = 2;
            this.RestartAtCheckBox.Text = "Restart daily at";
            this.RestartAtCheckBox.UseVisualStyleBackColor = true;
            this.RestartAtCheckBox.CheckedChanged += new System.EventHandler(this.RestartAtCheckBox_CheckedChanged);
            // 
            // RestartEveryTextBox
            // 
            this.RestartEveryTextBox.Location = new System.Drawing.Point(183, 17);
            this.RestartEveryTextBox.Name = "RestartEveryTextBox";
            this.RestartEveryTextBox.Size = new System.Drawing.Size(100, 20);
            this.RestartEveryTextBox.TabIndex = 1;
            this.RestartEveryTextBox.Text = "00:00:00";
            // 
            // RestartEveryCheckBox
            // 
            this.RestartEveryCheckBox.AutoSize = true;
            this.RestartEveryCheckBox.Location = new System.Drawing.Point(6, 19);
            this.RestartEveryCheckBox.Name = "RestartEveryCheckBox";
            this.RestartEveryCheckBox.Size = new System.Drawing.Size(89, 17);
            this.RestartEveryCheckBox.TabIndex = 0;
            this.RestartEveryCheckBox.Text = "Restart every";
            this.RestartEveryCheckBox.UseVisualStyleBackColor = true;
            this.RestartEveryCheckBox.CheckedChanged += new System.EventHandler(this.RestartEveryCheckBox_CheckedChanged);
            // 
            // RuntimeGroupBox
            // 
            this.RuntimeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RuntimeGroupBox.Controls.Add(this.ClearCacheCheckBox);
            this.RuntimeGroupBox.Controls.Add(this.AutoRestartCheckBox);
            this.RuntimeGroupBox.Location = new System.Drawing.Point(391, 177);
            this.RuntimeGroupBox.Name = "RuntimeGroupBox";
            this.RuntimeGroupBox.Size = new System.Drawing.Size(370, 66);
            this.RuntimeGroupBox.TabIndex = 3;
            this.RuntimeGroupBox.TabStop = false;
            this.RuntimeGroupBox.Text = "Runtime";
            // 
            // ClearCacheCheckBox
            // 
            this.ClearCacheCheckBox.AutoSize = true;
            this.ClearCacheCheckBox.Location = new System.Drawing.Point(6, 42);
            this.ClearCacheCheckBox.Name = "ClearCacheCheckBox";
            this.ClearCacheCheckBox.Size = new System.Drawing.Size(223, 17);
            this.ClearCacheCheckBox.TabIndex = 1;
            this.ClearCacheCheckBox.Text = "Clear the cache prior to starting the server";
            this.ClearCacheCheckBox.UseVisualStyleBackColor = true;
            this.ClearCacheCheckBox.CheckedChanged += new System.EventHandler(this.ClearCacheCheckBox_CheckedChanged);
            // 
            // AutoRestartCheckBox
            // 
            this.AutoRestartCheckBox.AutoSize = true;
            this.AutoRestartCheckBox.Location = new System.Drawing.Point(6, 19);
            this.AutoRestartCheckBox.Name = "AutoRestartCheckBox";
            this.AutoRestartCheckBox.Size = new System.Drawing.Size(226, 17);
            this.AutoRestartCheckBox.TabIndex = 0;
            this.AutoRestartCheckBox.Text = "Automatically restart the server if it crashes";
            this.AutoRestartCheckBox.UseVisualStyleBackColor = true;
            this.AutoRestartCheckBox.CheckedChanged += new System.EventHandler(this.AutoRestartCheckBox_CheckedChanged);
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
            this.APIsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.APIsGroupBox.Controls.Add(this.BuildsLinTextBox);
            this.APIsGroupBox.Controls.Add(this.BuildsLinLabel);
            this.APIsGroupBox.Controls.Add(this.SaveAPIsButton);
            this.APIsGroupBox.Controls.Add(this.BuildsWinTextBox);
            this.APIsGroupBox.Controls.Add(this.BuildsWinLabel);
            this.APIsGroupBox.Controls.Add(this.ResourcesTextBox);
            this.APIsGroupBox.Controls.Add(this.ResourcesLabel);
            this.APIsGroupBox.Location = new System.Drawing.Point(391, 6);
            this.APIsGroupBox.Name = "APIsGroupBox";
            this.APIsGroupBox.Size = new System.Drawing.Size(370, 165);
            this.APIsGroupBox.TabIndex = 1;
            this.APIsGroupBox.TabStop = false;
            this.APIsGroupBox.Text = "API URLs";
            // 
            // BuildsLinTextBox
            // 
            this.BuildsLinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsLinTextBox.Location = new System.Drawing.Point(6, 110);
            this.BuildsLinTextBox.Name = "BuildsLinTextBox";
            this.BuildsLinTextBox.Size = new System.Drawing.Size(358, 20);
            this.BuildsLinTextBox.TabIndex = 6;
            // 
            // BuildsLinLabel
            // 
            this.BuildsLinLabel.AutoSize = true;
            this.BuildsLinLabel.Location = new System.Drawing.Point(6, 94);
            this.BuildsLinLabel.Name = "BuildsLinLabel";
            this.BuildsLinLabel.Size = new System.Drawing.Size(78, 13);
            this.BuildsLinLabel.TabIndex = 5;
            this.BuildsLinLabel.Text = "Builds for Linux";
            // 
            // SaveAPIsButton
            // 
            this.SaveAPIsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAPIsButton.Location = new System.Drawing.Point(289, 137);
            this.SaveAPIsButton.Name = "SaveAPIsButton";
            this.SaveAPIsButton.Size = new System.Drawing.Size(75, 23);
            this.SaveAPIsButton.TabIndex = 4;
            this.SaveAPIsButton.Text = "Save";
            this.SaveAPIsButton.UseVisualStyleBackColor = true;
            this.SaveAPIsButton.Click += new System.EventHandler(this.SaveAPIsButton_Click);
            // 
            // BuildsWinTextBox
            // 
            this.BuildsWinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsWinTextBox.Location = new System.Drawing.Point(6, 71);
            this.BuildsWinTextBox.Name = "BuildsWinTextBox";
            this.BuildsWinTextBox.Size = new System.Drawing.Size(358, 20);
            this.BuildsWinTextBox.TabIndex = 3;
            // 
            // BuildsWinLabel
            // 
            this.BuildsWinLabel.AutoSize = true;
            this.BuildsWinLabel.Location = new System.Drawing.Point(6, 55);
            this.BuildsWinLabel.Name = "BuildsWinLabel";
            this.BuildsWinLabel.Size = new System.Drawing.Size(97, 13);
            this.BuildsWinLabel.TabIndex = 2;
            this.BuildsWinLabel.Text = "Builds for Windows";
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
            this.Controls.Add(this.BuildsGroup);
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
            this.VersionListGroup.ResumeLayout(false);
            this.InstallerListGroup.ResumeLayout(false);
            this.ConfigurationTab.ResumeLayout(false);
            this.ConfigurationTab.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.AutomatedRestartGroupBox.ResumeLayout(false);
            this.AutomatedRestartGroupBox.PerformLayout();
            this.RuntimeGroupBox.ResumeLayout(false);
            this.RuntimeGroupBox.PerformLayout();
            this.FolderCreationGroupBox.ResumeLayout(false);
            this.FolderCreationGroupBox.PerformLayout();
            this.APIsGroupBox.ResumeLayout(false);
            this.APIsGroupBox.PerformLayout();
            this.LicenseGroupBox.ResumeLayout(false);
            this.LicenseGroupBox.PerformLayout();
            this.AboutTab.ResumeLayout(false);
            this.BottomStrip.ResumeLayout(false);
            this.BottomStrip.PerformLayout();
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
        private System.Windows.Forms.Label BuildsWinLabel;
        private System.Windows.Forms.TextBox BuildsWinTextBox;
        private System.Windows.Forms.Button SaveAPIsButton;
        private System.Windows.Forms.Button BuildRefreshButton;
        private System.Windows.Forms.Button FolderRefreshButton;
        private System.Windows.Forms.GroupBox FolderCreationGroupBox;
        private System.Windows.Forms.CheckBox DownloadScriptsCheckBox;
        private System.Windows.Forms.CheckBox CreateConfigCheckBox;
        private System.Windows.Forms.GroupBox RuntimeGroupBox;
        private System.Windows.Forms.CheckBox AutoRestartCheckBox;
        private System.Windows.Forms.CheckBox ClearCacheCheckBox;
        private System.Windows.Forms.GroupBox AutomatedRestartGroupBox;
        private System.Windows.Forms.CheckBox RestartEveryCheckBox;
        private System.Windows.Forms.CheckBox RestartAtCheckBox;
        private System.Windows.Forms.TextBox RestartEveryTextBox;
        private System.Windows.Forms.TextBox RestartAtTextBox;
        private System.Windows.Forms.Button RestartEveryButton;
        private System.Windows.Forms.Button RestartAtButton;
        private System.Windows.Forms.TabPage ResourcesTab;
        private System.Windows.Forms.GroupBox InstallerListGroup;
        private System.Windows.Forms.GroupBox VersionListGroup;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.ListBox VersionsListBox;
        private System.Windows.Forms.ListBox InstallerListBox;
        private System.Windows.Forms.Button RefreshButton;
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
        private System.Windows.Forms.Button ResetSettingsButton;
        private System.Windows.Forms.Label BuildsLinLabel;
        private System.Windows.Forms.TextBox BuildsLinTextBox;
        private System.Windows.Forms.TabPage AboutTab;
        private System.Windows.Forms.RichTextBox AboutRichTextBox;
    }
}

