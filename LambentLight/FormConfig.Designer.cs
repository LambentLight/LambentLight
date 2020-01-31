namespace LambentLight
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.ConfigTabControl = new System.Windows.Forms.TabControl();
            this.AuthTabPage = new System.Windows.Forms.TabPage();
            this.ConnectionGroupBox = new System.Windows.Forms.GroupBox();
            this.ConnectionCheckBox = new System.Windows.Forms.CheckBox();
            this.ConnectionButton = new System.Windows.Forms.Button();
            this.ConnectionTextBox = new System.Windows.Forms.TextBox();
            this.SteamGroupBox = new System.Windows.Forms.GroupBox();
            this.SteamGenerateButton = new System.Windows.Forms.Button();
            this.SteamSaveButton = new System.Windows.Forms.Button();
            this.SteamVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.SteamTextBox = new System.Windows.Forms.TextBox();
            this.LicenseGroupBox = new System.Windows.Forms.GroupBox();
            this.LicenseGenerateButton = new System.Windows.Forms.Button();
            this.LicenseSaveButton = new System.Windows.Forms.Button();
            this.LicenseVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.LicenseTextBox = new System.Windows.Forms.TextBox();
            this.CFXServerTabPage = new System.Windows.Forms.TabPage();
            this.StartupGroupBox = new System.Windows.Forms.GroupBox();
            this.KickCheckBox = new System.Windows.Forms.CheckBox();
            this.WaitSaveButton = new System.Windows.Forms.Button();
            this.ClearCacheCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoRestartCheckBox = new System.Windows.Forms.CheckBox();
            this.WaitComboBox = new System.Windows.Forms.ComboBox();
            this.WaitCheckBox = new System.Windows.Forms.CheckBox();
            this.WaitTextBox = new System.Windows.Forms.TextBox();
            this.DataFolderTabPage = new System.Windows.Forms.TabPage();
            this.CreatorGroupBox = new System.Windows.Forms.GroupBox();
            this.CreateConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.DownloadScriptsCheckBox = new System.Windows.Forms.CheckBox();
            this.InstallerGroupBox = new System.Windows.Forms.GroupBox();
            this.ManuallyCheckBox = new System.Windows.Forms.CheckBox();
            this.RemoveFromConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyCheckBox = new System.Windows.Forms.CheckBox();
            this.AddToConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.ScheduleTabPage = new System.Windows.Forms.TabPage();
            this.AutomatedRestartGroupBox = new System.Windows.Forms.GroupBox();
            this.RestartAtButton = new System.Windows.Forms.Button();
            this.RestartEveryButton = new System.Windows.Forms.Button();
            this.RestartAtTextBox = new System.Windows.Forms.TextBox();
            this.RestartAtCheckBox = new System.Windows.Forms.CheckBox();
            this.RestartEveryTextBox = new System.Windows.Forms.TextBox();
            this.RestartEveryCheckBox = new System.Windows.Forms.CheckBox();
            this.ReposTabPage = new System.Windows.Forms.TabPage();
            this.ResourcesGroupBox = new System.Windows.Forms.GroupBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ResourcesListBox = new System.Windows.Forms.ListBox();
            this.BuildsGroupBox = new System.Windows.Forms.GroupBox();
            this.BuildsSaveButton = new System.Windows.Forms.Button();
            this.BuildsTextBox = new System.Windows.Forms.TextBox();
            this.WebAPITabPage = new System.Windows.Forms.TabPage();
            this.TokenGroupBox = new System.Windows.Forms.GroupBox();
            this.ShowTokenCheckBox = new System.Windows.Forms.CheckBox();
            this.TokenTextBox = new System.Windows.Forms.TextBox();
            this.TokenGenerateButton = new System.Windows.Forms.Button();
            this.TokenSaveButton = new System.Windows.Forms.Button();
            this.BasicsGroupBox = new System.Windows.Forms.GroupBox();
            this.BindToButton = new System.Windows.Forms.Button();
            this.BindToTextBox = new System.Windows.Forms.TextBox();
            this.EnableAPICheckBox = new System.Windows.Forms.CheckBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ResetSettingsButton = new System.Windows.Forms.Button();
            this.RunningGroupBox = new System.Windows.Forms.GroupBox();
            this.ShutdownGroupBox = new System.Windows.Forms.GroupBox();
            this.BindGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfigTabControl.SuspendLayout();
            this.AuthTabPage.SuspendLayout();
            this.ConnectionGroupBox.SuspendLayout();
            this.SteamGroupBox.SuspendLayout();
            this.LicenseGroupBox.SuspendLayout();
            this.CFXServerTabPage.SuspendLayout();
            this.StartupGroupBox.SuspendLayout();
            this.DataFolderTabPage.SuspendLayout();
            this.CreatorGroupBox.SuspendLayout();
            this.InstallerGroupBox.SuspendLayout();
            this.ScheduleTabPage.SuspendLayout();
            this.AutomatedRestartGroupBox.SuspendLayout();
            this.ReposTabPage.SuspendLayout();
            this.ResourcesGroupBox.SuspendLayout();
            this.BuildsGroupBox.SuspendLayout();
            this.WebAPITabPage.SuspendLayout();
            this.TokenGroupBox.SuspendLayout();
            this.BasicsGroupBox.SuspendLayout();
            this.RunningGroupBox.SuspendLayout();
            this.ShutdownGroupBox.SuspendLayout();
            this.BindGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigTabControl
            // 
            this.ConfigTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigTabControl.Controls.Add(this.CFXServerTabPage);
            this.ConfigTabControl.Controls.Add(this.AuthTabPage);
            this.ConfigTabControl.Controls.Add(this.DataFolderTabPage);
            this.ConfigTabControl.Controls.Add(this.ScheduleTabPage);
            this.ConfigTabControl.Controls.Add(this.ReposTabPage);
            this.ConfigTabControl.Controls.Add(this.WebAPITabPage);
            this.ConfigTabControl.Location = new System.Drawing.Point(0, 0);
            this.ConfigTabControl.Name = "ConfigTabControl";
            this.ConfigTabControl.SelectedIndex = 0;
            this.ConfigTabControl.Size = new System.Drawing.Size(609, 276);
            this.ConfigTabControl.TabIndex = 0;
            // 
            // AuthTabPage
            // 
            this.AuthTabPage.Controls.Add(this.ConnectionGroupBox);
            this.AuthTabPage.Controls.Add(this.SteamGroupBox);
            this.AuthTabPage.Controls.Add(this.LicenseGroupBox);
            this.AuthTabPage.Location = new System.Drawing.Point(4, 22);
            this.AuthTabPage.Name = "AuthTabPage";
            this.AuthTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AuthTabPage.Size = new System.Drawing.Size(601, 250);
            this.AuthTabPage.TabIndex = 0;
            this.AuthTabPage.Text = "Authentication";
            this.AuthTabPage.UseVisualStyleBackColor = true;
            // 
            // ConnectionGroupBox
            // 
            this.ConnectionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionGroupBox.Controls.Add(this.ConnectionCheckBox);
            this.ConnectionGroupBox.Controls.Add(this.ConnectionButton);
            this.ConnectionGroupBox.Controls.Add(this.ConnectionTextBox);
            this.ConnectionGroupBox.Location = new System.Drawing.Point(6, 167);
            this.ConnectionGroupBox.Name = "ConnectionGroupBox";
            this.ConnectionGroupBox.Size = new System.Drawing.Size(589, 75);
            this.ConnectionGroupBox.TabIndex = 8;
            this.ConnectionGroupBox.TabStop = false;
            this.ConnectionGroupBox.Text = "MySQL Connection URL";
            // 
            // ConnectionCheckBox
            // 
            this.ConnectionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConnectionCheckBox.AutoSize = true;
            this.ConnectionCheckBox.Location = new System.Drawing.Point(6, 49);
            this.ConnectionCheckBox.Name = "ConnectionCheckBox";
            this.ConnectionCheckBox.Size = new System.Drawing.Size(111, 17);
            this.ConnectionCheckBox.TabIndex = 2;
            this.ConnectionCheckBox.Text = "Make URL Visible";
            this.ConnectionCheckBox.UseVisualStyleBackColor = true;
            this.ConnectionCheckBox.CheckedChanged += new System.EventHandler(this.ConnectionCheckBox_CheckedChanged);
            // 
            // ConnectionButton
            // 
            this.ConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionButton.Enabled = false;
            this.ConnectionButton.Location = new System.Drawing.Point(507, 45);
            this.ConnectionButton.Name = "ConnectionButton";
            this.ConnectionButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectionButton.TabIndex = 1;
            this.ConnectionButton.Text = "Save";
            this.ConnectionButton.UseVisualStyleBackColor = true;
            this.ConnectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
            // 
            // ConnectionTextBox
            // 
            this.ConnectionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionTextBox.Enabled = false;
            this.ConnectionTextBox.Location = new System.Drawing.Point(6, 19);
            this.ConnectionTextBox.Name = "ConnectionTextBox";
            this.ConnectionTextBox.Size = new System.Drawing.Size(577, 20);
            this.ConnectionTextBox.TabIndex = 0;
            // 
            // SteamGroupBox
            // 
            this.SteamGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamGroupBox.Controls.Add(this.SteamGenerateButton);
            this.SteamGroupBox.Controls.Add(this.SteamSaveButton);
            this.SteamGroupBox.Controls.Add(this.SteamVisibleCheckBox);
            this.SteamGroupBox.Controls.Add(this.SteamTextBox);
            this.SteamGroupBox.Location = new System.Drawing.Point(6, 87);
            this.SteamGroupBox.Name = "SteamGroupBox";
            this.SteamGroupBox.Size = new System.Drawing.Size(589, 74);
            this.SteamGroupBox.TabIndex = 5;
            this.SteamGroupBox.TabStop = false;
            this.SteamGroupBox.Text = "Steam API Key";
            // 
            // SteamGenerateButton
            // 
            this.SteamGenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamGenerateButton.Location = new System.Drawing.Point(426, 45);
            this.SteamGenerateButton.Name = "SteamGenerateButton";
            this.SteamGenerateButton.Size = new System.Drawing.Size(75, 23);
            this.SteamGenerateButton.TabIndex = 4;
            this.SteamGenerateButton.Text = "Generate";
            this.SteamGenerateButton.UseVisualStyleBackColor = true;
            this.SteamGenerateButton.Click += new System.EventHandler(this.SteamGenerateButton_Click);
            // 
            // SteamSaveButton
            // 
            this.SteamSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamSaveButton.Enabled = false;
            this.SteamSaveButton.Location = new System.Drawing.Point(507, 45);
            this.SteamSaveButton.Name = "SteamSaveButton";
            this.SteamSaveButton.Size = new System.Drawing.Size(75, 23);
            this.SteamSaveButton.TabIndex = 3;
            this.SteamSaveButton.Text = "Save";
            this.SteamSaveButton.UseVisualStyleBackColor = true;
            this.SteamSaveButton.Click += new System.EventHandler(this.SaveSteamButton_Click);
            // 
            // SteamVisibleCheckBox
            // 
            this.SteamVisibleCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SteamVisibleCheckBox.AutoSize = true;
            this.SteamVisibleCheckBox.Location = new System.Drawing.Point(6, 49);
            this.SteamVisibleCheckBox.Name = "SteamVisibleCheckBox";
            this.SteamVisibleCheckBox.Size = new System.Drawing.Size(107, 17);
            this.SteamVisibleCheckBox.TabIndex = 2;
            this.SteamVisibleCheckBox.Text = "Make Key Visible";
            this.SteamVisibleCheckBox.UseVisualStyleBackColor = true;
            this.SteamVisibleCheckBox.CheckedChanged += new System.EventHandler(this.SteamVisibleCheckBox_CheckedChanged);
            // 
            // SteamTextBox
            // 
            this.SteamTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamTextBox.Enabled = false;
            this.SteamTextBox.Location = new System.Drawing.Point(6, 19);
            this.SteamTextBox.Name = "SteamTextBox";
            this.SteamTextBox.Size = new System.Drawing.Size(577, 20);
            this.SteamTextBox.TabIndex = 0;
            // 
            // LicenseGroupBox
            // 
            this.LicenseGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseGroupBox.Controls.Add(this.LicenseGenerateButton);
            this.LicenseGroupBox.Controls.Add(this.LicenseSaveButton);
            this.LicenseGroupBox.Controls.Add(this.LicenseVisibleCheckBox);
            this.LicenseGroupBox.Controls.Add(this.LicenseTextBox);
            this.LicenseGroupBox.Location = new System.Drawing.Point(6, 6);
            this.LicenseGroupBox.Name = "LicenseGroupBox";
            this.LicenseGroupBox.Size = new System.Drawing.Size(589, 74);
            this.LicenseGroupBox.TabIndex = 2;
            this.LicenseGroupBox.TabStop = false;
            this.LicenseGroupBox.Text = "CFX License";
            // 
            // LicenseGenerateButton
            // 
            this.LicenseGenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseGenerateButton.Location = new System.Drawing.Point(427, 45);
            this.LicenseGenerateButton.Name = "LicenseGenerateButton";
            this.LicenseGenerateButton.Size = new System.Drawing.Size(75, 23);
            this.LicenseGenerateButton.TabIndex = 3;
            this.LicenseGenerateButton.Text = "Generate";
            this.LicenseGenerateButton.UseVisualStyleBackColor = true;
            this.LicenseGenerateButton.Click += new System.EventHandler(this.LicenseGenerateButton_Click);
            // 
            // LicenseSaveButton
            // 
            this.LicenseSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseSaveButton.Enabled = false;
            this.LicenseSaveButton.Location = new System.Drawing.Point(508, 45);
            this.LicenseSaveButton.Name = "LicenseSaveButton";
            this.LicenseSaveButton.Size = new System.Drawing.Size(75, 23);
            this.LicenseSaveButton.TabIndex = 2;
            this.LicenseSaveButton.Text = "Save";
            this.LicenseSaveButton.UseVisualStyleBackColor = true;
            this.LicenseSaveButton.Click += new System.EventHandler(this.LicenseSaveButton_Click);
            // 
            // LicenseVisibleCheckBox
            // 
            this.LicenseVisibleCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LicenseVisibleCheckBox.AutoSize = true;
            this.LicenseVisibleCheckBox.Location = new System.Drawing.Point(6, 49);
            this.LicenseVisibleCheckBox.Name = "LicenseVisibleCheckBox";
            this.LicenseVisibleCheckBox.Size = new System.Drawing.Size(126, 17);
            this.LicenseVisibleCheckBox.TabIndex = 1;
            this.LicenseVisibleCheckBox.Text = "Make License Visible";
            this.LicenseVisibleCheckBox.UseVisualStyleBackColor = true;
            this.LicenseVisibleCheckBox.CheckedChanged += new System.EventHandler(this.LicenseVisibleCheckBox_CheckedChanged);
            // 
            // LicenseTextBox
            // 
            this.LicenseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseTextBox.Enabled = false;
            this.LicenseTextBox.Location = new System.Drawing.Point(6, 19);
            this.LicenseTextBox.Name = "LicenseTextBox";
            this.LicenseTextBox.Size = new System.Drawing.Size(577, 20);
            this.LicenseTextBox.TabIndex = 0;
            // 
            // CFXServerTabPage
            // 
            this.CFXServerTabPage.Controls.Add(this.ShutdownGroupBox);
            this.CFXServerTabPage.Controls.Add(this.RunningGroupBox);
            this.CFXServerTabPage.Controls.Add(this.StartupGroupBox);
            this.CFXServerTabPage.Location = new System.Drawing.Point(4, 22);
            this.CFXServerTabPage.Name = "CFXServerTabPage";
            this.CFXServerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CFXServerTabPage.Size = new System.Drawing.Size(601, 250);
            this.CFXServerTabPage.TabIndex = 3;
            this.CFXServerTabPage.Text = "CFX Server";
            this.CFXServerTabPage.UseVisualStyleBackColor = true;
            // 
            // StartupGroupBox
            // 
            this.StartupGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartupGroupBox.Controls.Add(this.ClearCacheCheckBox);
            this.StartupGroupBox.Location = new System.Drawing.Point(6, 6);
            this.StartupGroupBox.Name = "StartupGroupBox";
            this.StartupGroupBox.Size = new System.Drawing.Size(589, 42);
            this.StartupGroupBox.TabIndex = 5;
            this.StartupGroupBox.TabStop = false;
            this.StartupGroupBox.Text = "Startup";
            // 
            // KickCheckBox
            // 
            this.KickCheckBox.AutoSize = true;
            this.KickCheckBox.Location = new System.Drawing.Point(6, 42);
            this.KickCheckBox.Name = "KickCheckBox";
            this.KickCheckBox.Size = new System.Drawing.Size(220, 17);
            this.KickCheckBox.TabIndex = 4;
            this.KickCheckBox.Text = "Kick everyone before stopping the server";
            this.KickCheckBox.UseVisualStyleBackColor = true;
            this.KickCheckBox.CheckedChanged += new System.EventHandler(this.KickCheckBox_CheckedChanged);
            // 
            // WaitSaveButton
            // 
            this.WaitSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WaitSaveButton.Location = new System.Drawing.Point(508, 15);
            this.WaitSaveButton.Name = "WaitSaveButton";
            this.WaitSaveButton.Size = new System.Drawing.Size(75, 23);
            this.WaitSaveButton.TabIndex = 5;
            this.WaitSaveButton.Text = "Save";
            this.WaitSaveButton.UseVisualStyleBackColor = true;
            this.WaitSaveButton.Click += new System.EventHandler(this.WaitSaveButton_Click);
            // 
            // ClearCacheCheckBox
            // 
            this.ClearCacheCheckBox.AutoSize = true;
            this.ClearCacheCheckBox.Location = new System.Drawing.Point(6, 19);
            this.ClearCacheCheckBox.Name = "ClearCacheCheckBox";
            this.ClearCacheCheckBox.Size = new System.Drawing.Size(328, 17);
            this.ClearCacheCheckBox.TabIndex = 1;
            this.ClearCacheCheckBox.Text = "Remove the Server Cache if is present before starting the server";
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
            // WaitComboBox
            // 
            this.WaitComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WaitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WaitComboBox.FormattingEnabled = true;
            this.WaitComboBox.Location = new System.Drawing.Point(370, 16);
            this.WaitComboBox.Name = "WaitComboBox";
            this.WaitComboBox.Size = new System.Drawing.Size(136, 21);
            this.WaitComboBox.TabIndex = 2;
            // 
            // WaitCheckBox
            // 
            this.WaitCheckBox.AutoSize = true;
            this.WaitCheckBox.Location = new System.Drawing.Point(6, 19);
            this.WaitCheckBox.Name = "WaitCheckBox";
            this.WaitCheckBox.Size = new System.Drawing.Size(232, 17);
            this.WaitCheckBox.TabIndex = 3;
            this.WaitCheckBox.Text = "Warn the users before closing the server for";
            this.WaitCheckBox.UseVisualStyleBackColor = true;
            this.WaitCheckBox.CheckedChanged += new System.EventHandler(this.WaitCheckBox_CheckedChanged);
            // 
            // WaitTextBox
            // 
            this.WaitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WaitTextBox.Location = new System.Drawing.Point(235, 17);
            this.WaitTextBox.Name = "WaitTextBox";
            this.WaitTextBox.Size = new System.Drawing.Size(129, 20);
            this.WaitTextBox.TabIndex = 0;
            // 
            // DataFolderTabPage
            // 
            this.DataFolderTabPage.Controls.Add(this.CreatorGroupBox);
            this.DataFolderTabPage.Controls.Add(this.InstallerGroupBox);
            this.DataFolderTabPage.Location = new System.Drawing.Point(4, 22);
            this.DataFolderTabPage.Name = "DataFolderTabPage";
            this.DataFolderTabPage.Size = new System.Drawing.Size(601, 250);
            this.DataFolderTabPage.TabIndex = 4;
            this.DataFolderTabPage.Text = "Data Folders";
            this.DataFolderTabPage.UseVisualStyleBackColor = true;
            // 
            // CreatorGroupBox
            // 
            this.CreatorGroupBox.Controls.Add(this.CreateConfigCheckBox);
            this.CreatorGroupBox.Controls.Add(this.DownloadScriptsCheckBox);
            this.CreatorGroupBox.Location = new System.Drawing.Point(6, 3);
            this.CreatorGroupBox.Name = "CreatorGroupBox";
            this.CreatorGroupBox.Size = new System.Drawing.Size(589, 66);
            this.CreatorGroupBox.TabIndex = 4;
            this.CreatorGroupBox.TabStop = false;
            this.CreatorGroupBox.Text = "Creator";
            // 
            // CreateConfigCheckBox
            // 
            this.CreateConfigCheckBox.AutoSize = true;
            this.CreateConfigCheckBox.Location = new System.Drawing.Point(6, 42);
            this.CreateConfigCheckBox.Name = "CreateConfigCheckBox";
            this.CreateConfigCheckBox.Size = new System.Drawing.Size(246, 17);
            this.CreateConfigCheckBox.TabIndex = 1;
            this.CreateConfigCheckBox.Text = "Generate configuration after creating the folder";
            this.CreateConfigCheckBox.UseVisualStyleBackColor = true;
            this.CreateConfigCheckBox.CheckedChanged += new System.EventHandler(this.CreateConfigCheckBox_CheckedChanged);
            // 
            // DownloadScriptsCheckBox
            // 
            this.DownloadScriptsCheckBox.AutoSize = true;
            this.DownloadScriptsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.DownloadScriptsCheckBox.Name = "DownloadScriptsCheckBox";
            this.DownloadScriptsCheckBox.Size = new System.Drawing.Size(243, 17);
            this.DownloadScriptsCheckBox.TabIndex = 0;
            this.DownloadScriptsCheckBox.Text = "Download required scripts for the server to run";
            this.DownloadScriptsCheckBox.UseVisualStyleBackColor = true;
            this.DownloadScriptsCheckBox.CheckedChanged += new System.EventHandler(this.DownloadScriptsCheckBox_CheckedChanged);
            // 
            // InstallerGroupBox
            // 
            this.InstallerGroupBox.Controls.Add(this.ManuallyCheckBox);
            this.InstallerGroupBox.Controls.Add(this.RemoveFromConfigCheckBox);
            this.InstallerGroupBox.Controls.Add(this.ApplyCheckBox);
            this.InstallerGroupBox.Controls.Add(this.AddToConfigCheckBox);
            this.InstallerGroupBox.Location = new System.Drawing.Point(6, 75);
            this.InstallerGroupBox.Name = "InstallerGroupBox";
            this.InstallerGroupBox.Size = new System.Drawing.Size(589, 109);
            this.InstallerGroupBox.TabIndex = 0;
            this.InstallerGroupBox.TabStop = false;
            this.InstallerGroupBox.Text = "Resource Installer";
            // 
            // ManuallyCheckBox
            // 
            this.ManuallyCheckBox.AutoSize = true;
            this.ManuallyCheckBox.Location = new System.Drawing.Point(6, 88);
            this.ManuallyCheckBox.Name = "ManuallyCheckBox";
            this.ManuallyCheckBox.Size = new System.Drawing.Size(174, 17);
            this.ManuallyCheckBox.TabIndex = 1;
            this.ManuallyCheckBox.Text = "Manually approve every .sql file";
            this.ManuallyCheckBox.UseVisualStyleBackColor = true;
            this.ManuallyCheckBox.CheckedChanged += new System.EventHandler(this.ManuallyCheckBox_CheckedChanged);
            // 
            // RemoveFromConfigCheckBox
            // 
            this.RemoveFromConfigCheckBox.AutoSize = true;
            this.RemoveFromConfigCheckBox.Location = new System.Drawing.Point(6, 42);
            this.RemoveFromConfigCheckBox.Name = "RemoveFromConfigCheckBox";
            this.RemoveFromConfigCheckBox.Size = new System.Drawing.Size(230, 17);
            this.RemoveFromConfigCheckBox.TabIndex = 5;
            this.RemoveFromConfigCheckBox.Text = "Remove \"start {resource}\" after uninstalling";
            this.RemoveFromConfigCheckBox.UseVisualStyleBackColor = true;
            this.RemoveFromConfigCheckBox.CheckedChanged += new System.EventHandler(this.RemoveFromConfigCheckBox_CheckedChanged);
            // 
            // ApplyCheckBox
            // 
            this.ApplyCheckBox.AutoSize = true;
            this.ApplyCheckBox.Location = new System.Drawing.Point(6, 65);
            this.ApplyCheckBox.Name = "ApplyCheckBox";
            this.ApplyCheckBox.Size = new System.Drawing.Size(341, 17);
            this.ApplyCheckBox.TabIndex = 0;
            this.ApplyCheckBox.Text = "Apply .sql files into the MySQL database when installing Resources";
            this.ApplyCheckBox.UseVisualStyleBackColor = true;
            this.ApplyCheckBox.CheckedChanged += new System.EventHandler(this.ApplyCheckBox_CheckedChanged);
            // 
            // AddToConfigCheckBox
            // 
            this.AddToConfigCheckBox.AutoSize = true;
            this.AddToConfigCheckBox.Location = new System.Drawing.Point(6, 19);
            this.AddToConfigCheckBox.Name = "AddToConfigCheckBox";
            this.AddToConfigCheckBox.Size = new System.Drawing.Size(197, 17);
            this.AddToConfigCheckBox.TabIndex = 4;
            this.AddToConfigCheckBox.Text = "Add \"start {resource}\" after installing";
            this.AddToConfigCheckBox.UseVisualStyleBackColor = true;
            this.AddToConfigCheckBox.CheckedChanged += new System.EventHandler(this.AddToConfigCheckBox_CheckedChanged);
            // 
            // ScheduleTabPage
            // 
            this.ScheduleTabPage.Controls.Add(this.AutomatedRestartGroupBox);
            this.ScheduleTabPage.Location = new System.Drawing.Point(4, 22);
            this.ScheduleTabPage.Name = "ScheduleTabPage";
            this.ScheduleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ScheduleTabPage.Size = new System.Drawing.Size(601, 250);
            this.ScheduleTabPage.TabIndex = 2;
            this.ScheduleTabPage.Text = "Schedule";
            this.ScheduleTabPage.UseVisualStyleBackColor = true;
            // 
            // AutomatedRestartGroupBox
            // 
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartAtButton);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartEveryButton);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartAtTextBox);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartAtCheckBox);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartEveryTextBox);
            this.AutomatedRestartGroupBox.Controls.Add(this.RestartEveryCheckBox);
            this.AutomatedRestartGroupBox.Location = new System.Drawing.Point(6, 6);
            this.AutomatedRestartGroupBox.Name = "AutomatedRestartGroupBox";
            this.AutomatedRestartGroupBox.Size = new System.Drawing.Size(589, 75);
            this.AutomatedRestartGroupBox.TabIndex = 5;
            this.AutomatedRestartGroupBox.TabStop = false;
            this.AutomatedRestartGroupBox.Text = "Automated Restarts";
            // 
            // RestartAtButton
            // 
            this.RestartAtButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestartAtButton.Location = new System.Drawing.Point(508, 42);
            this.RestartAtButton.Name = "RestartAtButton";
            this.RestartAtButton.Size = new System.Drawing.Size(75, 23);
            this.RestartAtButton.TabIndex = 5;
            this.RestartAtButton.Text = "Save";
            this.RestartAtButton.UseVisualStyleBackColor = true;
            this.RestartAtButton.Click += new System.EventHandler(this.RestartAtButton_Click);
            // 
            // RestartEveryButton
            // 
            this.RestartEveryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestartEveryButton.Location = new System.Drawing.Point(508, 15);
            this.RestartEveryButton.Name = "RestartEveryButton";
            this.RestartEveryButton.Size = new System.Drawing.Size(75, 23);
            this.RestartEveryButton.TabIndex = 4;
            this.RestartEveryButton.Text = "Save";
            this.RestartEveryButton.UseVisualStyleBackColor = true;
            this.RestartEveryButton.Click += new System.EventHandler(this.RestartEveryButton_Click);
            // 
            // RestartAtTextBox
            // 
            this.RestartAtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestartAtTextBox.Location = new System.Drawing.Point(402, 42);
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
            this.RestartEveryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestartEveryTextBox.Location = new System.Drawing.Point(402, 17);
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
            // ReposTabPage
            // 
            this.ReposTabPage.Controls.Add(this.ResourcesGroupBox);
            this.ReposTabPage.Controls.Add(this.BuildsGroupBox);
            this.ReposTabPage.Location = new System.Drawing.Point(4, 22);
            this.ReposTabPage.Name = "ReposTabPage";
            this.ReposTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReposTabPage.Size = new System.Drawing.Size(601, 250);
            this.ReposTabPage.TabIndex = 1;
            this.ReposTabPage.Text = "Repositories";
            this.ReposTabPage.UseVisualStyleBackColor = true;
            // 
            // ResourcesGroupBox
            // 
            this.ResourcesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourcesGroupBox.Controls.Add(this.AddButton);
            this.ResourcesGroupBox.Controls.Add(this.RemoveButton);
            this.ResourcesGroupBox.Controls.Add(this.ResourcesListBox);
            this.ResourcesGroupBox.Location = new System.Drawing.Point(6, 83);
            this.ResourcesGroupBox.Name = "ResourcesGroupBox";
            this.ResourcesGroupBox.Size = new System.Drawing.Size(589, 161);
            this.ResourcesGroupBox.TabIndex = 3;
            this.ResourcesGroupBox.TabStop = false;
            this.ResourcesGroupBox.Text = "Resources";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(427, 132);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Location = new System.Drawing.Point(508, 132);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ResourcesListBox
            // 
            this.ResourcesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourcesListBox.FormattingEnabled = true;
            this.ResourcesListBox.Location = new System.Drawing.Point(6, 19);
            this.ResourcesListBox.Name = "ResourcesListBox";
            this.ResourcesListBox.Size = new System.Drawing.Size(577, 108);
            this.ResourcesListBox.TabIndex = 0;
            // 
            // BuildsGroupBox
            // 
            this.BuildsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsGroupBox.Controls.Add(this.BuildsSaveButton);
            this.BuildsGroupBox.Controls.Add(this.BuildsTextBox);
            this.BuildsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.BuildsGroupBox.Name = "BuildsGroupBox";
            this.BuildsGroupBox.Size = new System.Drawing.Size(589, 71);
            this.BuildsGroupBox.TabIndex = 2;
            this.BuildsGroupBox.TabStop = false;
            this.BuildsGroupBox.Text = "Builds";
            // 
            // BuildsSaveButton
            // 
            this.BuildsSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsSaveButton.Location = new System.Drawing.Point(508, 42);
            this.BuildsSaveButton.Name = "BuildsSaveButton";
            this.BuildsSaveButton.Size = new System.Drawing.Size(75, 23);
            this.BuildsSaveButton.TabIndex = 4;
            this.BuildsSaveButton.Text = "Save";
            this.BuildsSaveButton.UseVisualStyleBackColor = true;
            this.BuildsSaveButton.Click += new System.EventHandler(this.SaveAPIsButton_Click);
            // 
            // BuildsTextBox
            // 
            this.BuildsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsTextBox.Location = new System.Drawing.Point(6, 19);
            this.BuildsTextBox.Name = "BuildsTextBox";
            this.BuildsTextBox.Size = new System.Drawing.Size(577, 20);
            this.BuildsTextBox.TabIndex = 1;
            // 
            // WebAPITabPage
            // 
            this.WebAPITabPage.Controls.Add(this.BindGroupBox);
            this.WebAPITabPage.Controls.Add(this.TokenGroupBox);
            this.WebAPITabPage.Controls.Add(this.BasicsGroupBox);
            this.WebAPITabPage.Location = new System.Drawing.Point(4, 22);
            this.WebAPITabPage.Name = "WebAPITabPage";
            this.WebAPITabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WebAPITabPage.Size = new System.Drawing.Size(601, 250);
            this.WebAPITabPage.TabIndex = 5;
            this.WebAPITabPage.Text = "Web API";
            this.WebAPITabPage.UseVisualStyleBackColor = true;
            // 
            // TokenGroupBox
            // 
            this.TokenGroupBox.Controls.Add(this.ShowTokenCheckBox);
            this.TokenGroupBox.Controls.Add(this.TokenTextBox);
            this.TokenGroupBox.Controls.Add(this.TokenGenerateButton);
            this.TokenGroupBox.Controls.Add(this.TokenSaveButton);
            this.TokenGroupBox.Location = new System.Drawing.Point(6, 110);
            this.TokenGroupBox.Name = "TokenGroupBox";
            this.TokenGroupBox.Size = new System.Drawing.Size(589, 75);
            this.TokenGroupBox.TabIndex = 2;
            this.TokenGroupBox.TabStop = false;
            this.TokenGroupBox.Text = "Token";
            // 
            // ShowTokenCheckBox
            // 
            this.ShowTokenCheckBox.AutoSize = true;
            this.ShowTokenCheckBox.Location = new System.Drawing.Point(6, 49);
            this.ShowTokenCheckBox.Name = "ShowTokenCheckBox";
            this.ShowTokenCheckBox.Size = new System.Drawing.Size(115, 17);
            this.ShowTokenCheckBox.TabIndex = 3;
            this.ShowTokenCheckBox.Text = "Make token visible";
            this.ShowTokenCheckBox.UseVisualStyleBackColor = true;
            this.ShowTokenCheckBox.CheckedChanged += new System.EventHandler(this.ShowTokenCheckBox_CheckedChanged);
            // 
            // TokenTextBox
            // 
            this.TokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenTextBox.Enabled = false;
            this.TokenTextBox.Location = new System.Drawing.Point(6, 19);
            this.TokenTextBox.Name = "TokenTextBox";
            this.TokenTextBox.Size = new System.Drawing.Size(577, 20);
            this.TokenTextBox.TabIndex = 2;
            // 
            // TokenGenerateButton
            // 
            this.TokenGenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenGenerateButton.Enabled = false;
            this.TokenGenerateButton.Location = new System.Drawing.Point(428, 45);
            this.TokenGenerateButton.Name = "TokenGenerateButton";
            this.TokenGenerateButton.Size = new System.Drawing.Size(75, 23);
            this.TokenGenerateButton.TabIndex = 1;
            this.TokenGenerateButton.Text = "Generate";
            this.TokenGenerateButton.UseVisualStyleBackColor = true;
            this.TokenGenerateButton.Click += new System.EventHandler(this.TokenGenerateButton_Click);
            // 
            // TokenSaveButton
            // 
            this.TokenSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenSaveButton.Enabled = false;
            this.TokenSaveButton.Location = new System.Drawing.Point(508, 45);
            this.TokenSaveButton.Name = "TokenSaveButton";
            this.TokenSaveButton.Size = new System.Drawing.Size(75, 23);
            this.TokenSaveButton.TabIndex = 0;
            this.TokenSaveButton.Text = "Save";
            this.TokenSaveButton.UseVisualStyleBackColor = true;
            this.TokenSaveButton.Click += new System.EventHandler(this.TokenSaveButton_Click);
            // 
            // BasicsGroupBox
            // 
            this.BasicsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BasicsGroupBox.Controls.Add(this.EnableAPICheckBox);
            this.BasicsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.BasicsGroupBox.Name = "BasicsGroupBox";
            this.BasicsGroupBox.Size = new System.Drawing.Size(589, 45);
            this.BasicsGroupBox.TabIndex = 1;
            this.BasicsGroupBox.TabStop = false;
            this.BasicsGroupBox.Text = "Basics";
            // 
            // BindToButton
            // 
            this.BindToButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BindToButton.Location = new System.Drawing.Point(508, 17);
            this.BindToButton.Name = "BindToButton";
            this.BindToButton.Size = new System.Drawing.Size(75, 23);
            this.BindToButton.TabIndex = 2;
            this.BindToButton.Text = "Save";
            this.BindToButton.UseVisualStyleBackColor = true;
            this.BindToButton.Click += new System.EventHandler(this.BindToButton_Click);
            // 
            // BindToTextBox
            // 
            this.BindToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BindToTextBox.Location = new System.Drawing.Point(6, 19);
            this.BindToTextBox.Name = "BindToTextBox";
            this.BindToTextBox.Size = new System.Drawing.Size(496, 20);
            this.BindToTextBox.TabIndex = 1;
            // 
            // EnableAPICheckBox
            // 
            this.EnableAPICheckBox.AutoSize = true;
            this.EnableAPICheckBox.Location = new System.Drawing.Point(6, 19);
            this.EnableAPICheckBox.Name = "EnableAPICheckBox";
            this.EnableAPICheckBox.Size = new System.Drawing.Size(272, 17);
            this.EnableAPICheckBox.TabIndex = 0;
            this.EnableAPICheckBox.Text = "Enable Web API (Required for LambentLight Bridge)";
            this.EnableAPICheckBox.UseVisualStyleBackColor = true;
            this.EnableAPICheckBox.CheckedChanged += new System.EventHandler(this.EnableAPICheckBox_CheckedChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(522, 282);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ResetSettingsButton
            // 
            this.ResetSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetSettingsButton.Location = new System.Drawing.Point(12, 282);
            this.ResetSettingsButton.Name = "ResetSettingsButton";
            this.ResetSettingsButton.Size = new System.Drawing.Size(504, 23);
            this.ResetSettingsButton.TabIndex = 6;
            this.ResetSettingsButton.Text = "Reset Settings to their Default Values";
            this.ResetSettingsButton.UseVisualStyleBackColor = true;
            this.ResetSettingsButton.Click += new System.EventHandler(this.ResetSettingsButton_Click);
            // 
            // RunningGroupBox
            // 
            this.RunningGroupBox.Controls.Add(this.AutoRestartCheckBox);
            this.RunningGroupBox.Location = new System.Drawing.Point(6, 54);
            this.RunningGroupBox.Name = "RunningGroupBox";
            this.RunningGroupBox.Size = new System.Drawing.Size(589, 44);
            this.RunningGroupBox.TabIndex = 6;
            this.RunningGroupBox.TabStop = false;
            this.RunningGroupBox.Text = "While is Running";
            // 
            // ShutdownGroupBox
            // 
            this.ShutdownGroupBox.Controls.Add(this.WaitSaveButton);
            this.ShutdownGroupBox.Controls.Add(this.WaitTextBox);
            this.ShutdownGroupBox.Controls.Add(this.WaitComboBox);
            this.ShutdownGroupBox.Controls.Add(this.KickCheckBox);
            this.ShutdownGroupBox.Controls.Add(this.WaitCheckBox);
            this.ShutdownGroupBox.Location = new System.Drawing.Point(6, 104);
            this.ShutdownGroupBox.Name = "ShutdownGroupBox";
            this.ShutdownGroupBox.Size = new System.Drawing.Size(589, 69);
            this.ShutdownGroupBox.TabIndex = 7;
            this.ShutdownGroupBox.TabStop = false;
            this.ShutdownGroupBox.Text = "Shutdown";
            // 
            // BindGroupBox
            // 
            this.BindGroupBox.Controls.Add(this.BindToTextBox);
            this.BindGroupBox.Controls.Add(this.BindToButton);
            this.BindGroupBox.Location = new System.Drawing.Point(6, 57);
            this.BindGroupBox.Name = "BindGroupBox";
            this.BindGroupBox.Size = new System.Drawing.Size(589, 47);
            this.BindGroupBox.TabIndex = 3;
            this.BindGroupBox.TabStop = false;
            this.BindGroupBox.Text = "Bind To";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 317);
            this.Controls.Add(this.ResetSettingsButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ConfigTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " LambentLight Settings";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ConfigTabControl.ResumeLayout(false);
            this.AuthTabPage.ResumeLayout(false);
            this.ConnectionGroupBox.ResumeLayout(false);
            this.ConnectionGroupBox.PerformLayout();
            this.SteamGroupBox.ResumeLayout(false);
            this.SteamGroupBox.PerformLayout();
            this.LicenseGroupBox.ResumeLayout(false);
            this.LicenseGroupBox.PerformLayout();
            this.CFXServerTabPage.ResumeLayout(false);
            this.StartupGroupBox.ResumeLayout(false);
            this.StartupGroupBox.PerformLayout();
            this.DataFolderTabPage.ResumeLayout(false);
            this.CreatorGroupBox.ResumeLayout(false);
            this.CreatorGroupBox.PerformLayout();
            this.InstallerGroupBox.ResumeLayout(false);
            this.InstallerGroupBox.PerformLayout();
            this.ScheduleTabPage.ResumeLayout(false);
            this.AutomatedRestartGroupBox.ResumeLayout(false);
            this.AutomatedRestartGroupBox.PerformLayout();
            this.ReposTabPage.ResumeLayout(false);
            this.ResourcesGroupBox.ResumeLayout(false);
            this.BuildsGroupBox.ResumeLayout(false);
            this.BuildsGroupBox.PerformLayout();
            this.WebAPITabPage.ResumeLayout(false);
            this.TokenGroupBox.ResumeLayout(false);
            this.TokenGroupBox.PerformLayout();
            this.BasicsGroupBox.ResumeLayout(false);
            this.BasicsGroupBox.PerformLayout();
            this.RunningGroupBox.ResumeLayout(false);
            this.RunningGroupBox.PerformLayout();
            this.ShutdownGroupBox.ResumeLayout(false);
            this.ShutdownGroupBox.PerformLayout();
            this.BindGroupBox.ResumeLayout(false);
            this.BindGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConfigTabControl;
        private System.Windows.Forms.TabPage AuthTabPage;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox LicenseGroupBox;
        private System.Windows.Forms.Button LicenseGenerateButton;
        private System.Windows.Forms.Button LicenseSaveButton;
        private System.Windows.Forms.CheckBox LicenseVisibleCheckBox;
        private System.Windows.Forms.TextBox LicenseTextBox;
        private System.Windows.Forms.TabPage ReposTabPage;
        private System.Windows.Forms.GroupBox BuildsGroupBox;
        private System.Windows.Forms.Button BuildsSaveButton;
        private System.Windows.Forms.TextBox BuildsTextBox;
        private System.Windows.Forms.TabPage ScheduleTabPage;
        private System.Windows.Forms.GroupBox AutomatedRestartGroupBox;
        private System.Windows.Forms.Button RestartAtButton;
        private System.Windows.Forms.Button RestartEveryButton;
        private System.Windows.Forms.TextBox RestartAtTextBox;
        private System.Windows.Forms.CheckBox RestartAtCheckBox;
        private System.Windows.Forms.TextBox RestartEveryTextBox;
        private System.Windows.Forms.CheckBox RestartEveryCheckBox;
        private System.Windows.Forms.Button ResetSettingsButton;
        private System.Windows.Forms.GroupBox SteamGroupBox;
        private System.Windows.Forms.TextBox SteamTextBox;
        private System.Windows.Forms.CheckBox SteamVisibleCheckBox;
        private System.Windows.Forms.Button SteamSaveButton;
        private System.Windows.Forms.Button SteamGenerateButton;
        private System.Windows.Forms.GroupBox ResourcesGroupBox;
        private System.Windows.Forms.ListBox ResourcesListBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.TabPage CFXServerTabPage;
        private System.Windows.Forms.TabPage DataFolderTabPage;
        private System.Windows.Forms.GroupBox InstallerGroupBox;
        private System.Windows.Forms.CheckBox RemoveFromConfigCheckBox;
        private System.Windows.Forms.CheckBox AddToConfigCheckBox;
        private System.Windows.Forms.GroupBox CreatorGroupBox;
        private System.Windows.Forms.CheckBox CreateConfigCheckBox;
        private System.Windows.Forms.CheckBox DownloadScriptsCheckBox;
        private System.Windows.Forms.GroupBox ConnectionGroupBox;
        private System.Windows.Forms.CheckBox ConnectionCheckBox;
        private System.Windows.Forms.Button ConnectionButton;
        private System.Windows.Forms.TextBox ConnectionTextBox;
        private System.Windows.Forms.CheckBox ManuallyCheckBox;
        private System.Windows.Forms.CheckBox ApplyCheckBox;
        private System.Windows.Forms.GroupBox StartupGroupBox;
        private System.Windows.Forms.CheckBox ClearCacheCheckBox;
        private System.Windows.Forms.CheckBox AutoRestartCheckBox;
        private System.Windows.Forms.Button WaitSaveButton;
        private System.Windows.Forms.CheckBox KickCheckBox;
        private System.Windows.Forms.CheckBox WaitCheckBox;
        private System.Windows.Forms.ComboBox WaitComboBox;
        private System.Windows.Forms.TextBox WaitTextBox;
        private System.Windows.Forms.TabPage WebAPITabPage;
        private System.Windows.Forms.GroupBox BasicsGroupBox;
        private System.Windows.Forms.CheckBox EnableAPICheckBox;
        private System.Windows.Forms.Button BindToButton;
        private System.Windows.Forms.TextBox BindToTextBox;
        private System.Windows.Forms.GroupBox TokenGroupBox;
        private System.Windows.Forms.TextBox TokenTextBox;
        private System.Windows.Forms.Button TokenGenerateButton;
        private System.Windows.Forms.Button TokenSaveButton;
        private System.Windows.Forms.CheckBox ShowTokenCheckBox;
        private System.Windows.Forms.GroupBox RunningGroupBox;
        private System.Windows.Forms.GroupBox ShutdownGroupBox;
        private System.Windows.Forms.GroupBox BindGroupBox;
    }
}