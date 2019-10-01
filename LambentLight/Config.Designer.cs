namespace LambentLight
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.ConfigTabControl = new System.Windows.Forms.TabControl();
            this.BasicTabPage = new System.Windows.Forms.TabPage();
            this.SteamGroupBox = new System.Windows.Forms.GroupBox();
            this.SteamSaveButton = new System.Windows.Forms.Button();
            this.SteamVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.SteamTextBox = new System.Windows.Forms.TextBox();
            this.RuntimeGroupBox = new System.Windows.Forms.GroupBox();
            this.ClearCacheCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoRestartCheckBox = new System.Windows.Forms.CheckBox();
            this.FolderCreationGroupBox = new System.Windows.Forms.GroupBox();
            this.RemoveFromConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.AddToConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.CreateConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.DownloadScriptsCheckBox = new System.Windows.Forms.CheckBox();
            this.LicenseGroupBox = new System.Windows.Forms.GroupBox();
            this.LicenseGenerateButton = new System.Windows.Forms.Button();
            this.LicenseSaveButton = new System.Windows.Forms.Button();
            this.LicenseVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.LicenseTextBox = new System.Windows.Forms.TextBox();
            this.ScheduleTabPage = new System.Windows.Forms.TabPage();
            this.AutomatedRestartGroupBox = new System.Windows.Forms.GroupBox();
            this.RestartAtButton = new System.Windows.Forms.Button();
            this.RestartEveryButton = new System.Windows.Forms.Button();
            this.RestartAtTextBox = new System.Windows.Forms.TextBox();
            this.RestartAtCheckBox = new System.Windows.Forms.CheckBox();
            this.RestartEveryTextBox = new System.Windows.Forms.TextBox();
            this.RestartEveryCheckBox = new System.Windows.Forms.CheckBox();
            this.APITabPage = new System.Windows.Forms.TabPage();
            this.APIsGroupBox = new System.Windows.Forms.GroupBox();
            this.BuildsLinTextBox = new System.Windows.Forms.TextBox();
            this.BuildsLinLabel = new System.Windows.Forms.Label();
            this.SaveAPIsButton = new System.Windows.Forms.Button();
            this.BuildsWinTextBox = new System.Windows.Forms.TextBox();
            this.BuildsWinLabel = new System.Windows.Forms.Label();
            this.ResourcesTextBox = new System.Windows.Forms.TextBox();
            this.ResourcesLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ResetSettingsButton = new System.Windows.Forms.Button();
            this.ConfigTabControl.SuspendLayout();
            this.BasicTabPage.SuspendLayout();
            this.SteamGroupBox.SuspendLayout();
            this.RuntimeGroupBox.SuspendLayout();
            this.FolderCreationGroupBox.SuspendLayout();
            this.LicenseGroupBox.SuspendLayout();
            this.ScheduleTabPage.SuspendLayout();
            this.AutomatedRestartGroupBox.SuspendLayout();
            this.APITabPage.SuspendLayout();
            this.APIsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigTabControl
            // 
            this.ConfigTabControl.Controls.Add(this.BasicTabPage);
            this.ConfigTabControl.Controls.Add(this.ScheduleTabPage);
            this.ConfigTabControl.Controls.Add(this.APITabPage);
            this.ConfigTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConfigTabControl.Location = new System.Drawing.Point(0, 0);
            this.ConfigTabControl.Name = "ConfigTabControl";
            this.ConfigTabControl.SelectedIndex = 0;
            this.ConfigTabControl.Size = new System.Drawing.Size(384, 420);
            this.ConfigTabControl.TabIndex = 0;
            // 
            // BasicTabPage
            // 
            this.BasicTabPage.Controls.Add(this.SteamGroupBox);
            this.BasicTabPage.Controls.Add(this.RuntimeGroupBox);
            this.BasicTabPage.Controls.Add(this.FolderCreationGroupBox);
            this.BasicTabPage.Controls.Add(this.LicenseGroupBox);
            this.BasicTabPage.Location = new System.Drawing.Point(4, 22);
            this.BasicTabPage.Name = "BasicTabPage";
            this.BasicTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BasicTabPage.Size = new System.Drawing.Size(376, 394);
            this.BasicTabPage.TabIndex = 0;
            this.BasicTabPage.Text = "Basic";
            this.BasicTabPage.UseVisualStyleBackColor = true;
            // 
            // SteamGroupBox
            // 
            this.SteamGroupBox.Controls.Add(this.SteamSaveButton);
            this.SteamGroupBox.Controls.Add(this.SteamVisibleCheckBox);
            this.SteamGroupBox.Controls.Add(this.SteamTextBox);
            this.SteamGroupBox.Location = new System.Drawing.Point(6, 87);
            this.SteamGroupBox.Name = "SteamGroupBox";
            this.SteamGroupBox.Size = new System.Drawing.Size(364, 74);
            this.SteamGroupBox.TabIndex = 5;
            this.SteamGroupBox.TabStop = false;
            this.SteamGroupBox.Text = "Steam Web API Key";
            // 
            // SteamSaveButton
            // 
            this.SteamSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamSaveButton.Enabled = false;
            this.SteamSaveButton.Location = new System.Drawing.Point(282, 45);
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
            this.SteamVisibleCheckBox.Size = new System.Drawing.Size(127, 17);
            this.SteamVisibleCheckBox.TabIndex = 2;
            this.SteamVisibleCheckBox.Text = "Make API Key Visible";
            this.SteamVisibleCheckBox.UseVisualStyleBackColor = true;
            this.SteamVisibleCheckBox.CheckedChanged += new System.EventHandler(this.VisibleCheckBox2_CheckedChanged);
            // 
            // SteamTextBox
            // 
            this.SteamTextBox.Enabled = false;
            this.SteamTextBox.Location = new System.Drawing.Point(6, 19);
            this.SteamTextBox.Name = "SteamTextBox";
            this.SteamTextBox.Size = new System.Drawing.Size(351, 20);
            this.SteamTextBox.TabIndex = 0;
            // 
            // RuntimeGroupBox
            // 
            this.RuntimeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RuntimeGroupBox.Controls.Add(this.ClearCacheCheckBox);
            this.RuntimeGroupBox.Controls.Add(this.AutoRestartCheckBox);
            this.RuntimeGroupBox.Location = new System.Drawing.Point(8, 287);
            this.RuntimeGroupBox.Name = "RuntimeGroupBox";
            this.RuntimeGroupBox.Size = new System.Drawing.Size(364, 66);
            this.RuntimeGroupBox.TabIndex = 4;
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
            this.FolderCreationGroupBox.Controls.Add(this.RemoveFromConfigCheckBox);
            this.FolderCreationGroupBox.Controls.Add(this.AddToConfigCheckBox);
            this.FolderCreationGroupBox.Controls.Add(this.CreateConfigCheckBox);
            this.FolderCreationGroupBox.Controls.Add(this.DownloadScriptsCheckBox);
            this.FolderCreationGroupBox.Location = new System.Drawing.Point(6, 167);
            this.FolderCreationGroupBox.Name = "FolderCreationGroupBox";
            this.FolderCreationGroupBox.Size = new System.Drawing.Size(364, 114);
            this.FolderCreationGroupBox.TabIndex = 3;
            this.FolderCreationGroupBox.TabStop = false;
            this.FolderCreationGroupBox.Text = "Data Folders and Resources";
            // 
            // RemoveFromConfigCheckBox
            // 
            this.RemoveFromConfigCheckBox.AutoSize = true;
            this.RemoveFromConfigCheckBox.Location = new System.Drawing.Point(6, 88);
            this.RemoveFromConfigCheckBox.Name = "RemoveFromConfigCheckBox";
            this.RemoveFromConfigCheckBox.Size = new System.Drawing.Size(324, 17);
            this.RemoveFromConfigCheckBox.TabIndex = 3;
            this.RemoveFromConfigCheckBox.Text = "After uninstalling the Resource, remove it from the configuration";
            this.RemoveFromConfigCheckBox.UseVisualStyleBackColor = true;
            this.RemoveFromConfigCheckBox.CheckedChanged += new System.EventHandler(this.RemoveFromConfigCheckBox_CheckedChanged);
            // 
            // AddToConfigCheckBox
            // 
            this.AddToConfigCheckBox.AutoSize = true;
            this.AddToConfigCheckBox.Location = new System.Drawing.Point(6, 65);
            this.AddToConfigCheckBox.Name = "AddToConfigCheckBox";
            this.AddToConfigCheckBox.Size = new System.Drawing.Size(319, 17);
            this.AddToConfigCheckBox.TabIndex = 2;
            this.AddToConfigCheckBox.Text = "Set the Installed Resource to auto start in the configuration file";
            this.AddToConfigCheckBox.UseVisualStyleBackColor = true;
            this.AddToConfigCheckBox.CheckedChanged += new System.EventHandler(this.AddToConfigCheckBox_CheckedChanged);
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
            // LicenseGroupBox
            // 
            this.LicenseGroupBox.Controls.Add(this.LicenseGenerateButton);
            this.LicenseGroupBox.Controls.Add(this.LicenseSaveButton);
            this.LicenseGroupBox.Controls.Add(this.LicenseVisibleCheckBox);
            this.LicenseGroupBox.Controls.Add(this.LicenseTextBox);
            this.LicenseGroupBox.Location = new System.Drawing.Point(6, 6);
            this.LicenseGroupBox.Name = "LicenseGroupBox";
            this.LicenseGroupBox.Size = new System.Drawing.Size(364, 74);
            this.LicenseGroupBox.TabIndex = 2;
            this.LicenseGroupBox.TabStop = false;
            this.LicenseGroupBox.Text = "FiveM License";
            // 
            // LicenseGenerateButton
            // 
            this.LicenseGenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseGenerateButton.Location = new System.Drawing.Point(202, 45);
            this.LicenseGenerateButton.Name = "LicenseGenerateButton";
            this.LicenseGenerateButton.Size = new System.Drawing.Size(75, 23);
            this.LicenseGenerateButton.TabIndex = 3;
            this.LicenseGenerateButton.Text = "Generate";
            this.LicenseGenerateButton.UseVisualStyleBackColor = true;
            this.LicenseGenerateButton.Click += new System.EventHandler(this.GenerateLicenseButton_Click);
            // 
            // LicenseSaveButton
            // 
            this.LicenseSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseSaveButton.Enabled = false;
            this.LicenseSaveButton.Location = new System.Drawing.Point(283, 45);
            this.LicenseSaveButton.Name = "LicenseSaveButton";
            this.LicenseSaveButton.Size = new System.Drawing.Size(75, 23);
            this.LicenseSaveButton.TabIndex = 2;
            this.LicenseSaveButton.Text = "Save";
            this.LicenseSaveButton.UseVisualStyleBackColor = true;
            this.LicenseSaveButton.Click += new System.EventHandler(this.SaveLicenseButton_Click);
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
            this.LicenseVisibleCheckBox.CheckedChanged += new System.EventHandler(this.VisibleCheckBox_CheckedChanged);
            // 
            // LicenseTextBox
            // 
            this.LicenseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseTextBox.Enabled = false;
            this.LicenseTextBox.Location = new System.Drawing.Point(6, 19);
            this.LicenseTextBox.Name = "LicenseTextBox";
            this.LicenseTextBox.Size = new System.Drawing.Size(352, 20);
            this.LicenseTextBox.TabIndex = 0;
            // 
            // ScheduleTabPage
            // 
            this.ScheduleTabPage.Controls.Add(this.AutomatedRestartGroupBox);
            this.ScheduleTabPage.Location = new System.Drawing.Point(4, 22);
            this.ScheduleTabPage.Name = "ScheduleTabPage";
            this.ScheduleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ScheduleTabPage.Size = new System.Drawing.Size(376, 394);
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
            this.AutomatedRestartGroupBox.Size = new System.Drawing.Size(364, 75);
            this.AutomatedRestartGroupBox.TabIndex = 5;
            this.AutomatedRestartGroupBox.TabStop = false;
            this.AutomatedRestartGroupBox.Text = "Automated Restarts";
            // 
            // RestartAtButton
            // 
            this.RestartAtButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestartAtButton.Location = new System.Drawing.Point(283, 42);
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
            this.RestartEveryButton.Location = new System.Drawing.Point(283, 15);
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
            this.RestartAtTextBox.Location = new System.Drawing.Point(177, 42);
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
            this.RestartEveryTextBox.Location = new System.Drawing.Point(177, 17);
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
            // 
            // APITabPage
            // 
            this.APITabPage.Controls.Add(this.APIsGroupBox);
            this.APITabPage.Location = new System.Drawing.Point(4, 22);
            this.APITabPage.Name = "APITabPage";
            this.APITabPage.Padding = new System.Windows.Forms.Padding(3);
            this.APITabPage.Size = new System.Drawing.Size(376, 394);
            this.APITabPage.TabIndex = 1;
            this.APITabPage.Text = "APIs";
            this.APITabPage.UseVisualStyleBackColor = true;
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
            this.APIsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.APIsGroupBox.Name = "APIsGroupBox";
            this.APIsGroupBox.Size = new System.Drawing.Size(364, 165);
            this.APIsGroupBox.TabIndex = 2;
            this.APIsGroupBox.TabStop = false;
            this.APIsGroupBox.Text = "URLs";
            // 
            // BuildsLinTextBox
            // 
            this.BuildsLinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsLinTextBox.Location = new System.Drawing.Point(6, 110);
            this.BuildsLinTextBox.Name = "BuildsLinTextBox";
            this.BuildsLinTextBox.Size = new System.Drawing.Size(352, 20);
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
            this.SaveAPIsButton.Location = new System.Drawing.Point(283, 137);
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
            this.BuildsWinTextBox.Size = new System.Drawing.Size(352, 20);
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
            this.ResourcesTextBox.Size = new System.Drawing.Size(352, 20);
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
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(297, 426);
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
            this.ResetSettingsButton.Location = new System.Drawing.Point(12, 426);
            this.ResetSettingsButton.Name = "ResetSettingsButton";
            this.ResetSettingsButton.Size = new System.Drawing.Size(279, 23);
            this.ResetSettingsButton.TabIndex = 6;
            this.ResetSettingsButton.Text = "Reset Settings to their Default Values";
            this.ResetSettingsButton.UseVisualStyleBackColor = true;
            this.ResetSettingsButton.Click += new System.EventHandler(this.ResetSettingsButton_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.ResetSettingsButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ConfigTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ConfigTabControl.ResumeLayout(false);
            this.BasicTabPage.ResumeLayout(false);
            this.SteamGroupBox.ResumeLayout(false);
            this.SteamGroupBox.PerformLayout();
            this.RuntimeGroupBox.ResumeLayout(false);
            this.RuntimeGroupBox.PerformLayout();
            this.FolderCreationGroupBox.ResumeLayout(false);
            this.FolderCreationGroupBox.PerformLayout();
            this.LicenseGroupBox.ResumeLayout(false);
            this.LicenseGroupBox.PerformLayout();
            this.ScheduleTabPage.ResumeLayout(false);
            this.AutomatedRestartGroupBox.ResumeLayout(false);
            this.AutomatedRestartGroupBox.PerformLayout();
            this.APITabPage.ResumeLayout(false);
            this.APIsGroupBox.ResumeLayout(false);
            this.APIsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConfigTabControl;
        private System.Windows.Forms.TabPage BasicTabPage;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox LicenseGroupBox;
        private System.Windows.Forms.Button LicenseGenerateButton;
        private System.Windows.Forms.Button LicenseSaveButton;
        private System.Windows.Forms.CheckBox LicenseVisibleCheckBox;
        private System.Windows.Forms.TextBox LicenseTextBox;
        private System.Windows.Forms.TabPage APITabPage;
        private System.Windows.Forms.GroupBox APIsGroupBox;
        private System.Windows.Forms.TextBox BuildsLinTextBox;
        private System.Windows.Forms.Label BuildsLinLabel;
        private System.Windows.Forms.Button SaveAPIsButton;
        private System.Windows.Forms.TextBox BuildsWinTextBox;
        private System.Windows.Forms.Label BuildsWinLabel;
        private System.Windows.Forms.TextBox ResourcesTextBox;
        private System.Windows.Forms.Label ResourcesLabel;
        private System.Windows.Forms.GroupBox FolderCreationGroupBox;
        private System.Windows.Forms.CheckBox RemoveFromConfigCheckBox;
        private System.Windows.Forms.CheckBox AddToConfigCheckBox;
        private System.Windows.Forms.CheckBox CreateConfigCheckBox;
        private System.Windows.Forms.CheckBox DownloadScriptsCheckBox;
        private System.Windows.Forms.GroupBox RuntimeGroupBox;
        private System.Windows.Forms.CheckBox ClearCacheCheckBox;
        private System.Windows.Forms.CheckBox AutoRestartCheckBox;
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
    }
}