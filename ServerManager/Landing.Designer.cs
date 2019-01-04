namespace ServerManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Landing));
            this.BuildSelector = new System.Windows.Forms.GroupBox();
            this.RefreshBuilds = new System.Windows.Forms.Button();
            this.BuildList = new System.Windows.Forms.ComboBox();
            this.ServerData = new System.Windows.Forms.GroupBox();
            this.RefreshData = new System.Windows.Forms.Button();
            this.DataList = new System.Windows.Forms.ComboBox();
            this.Console = new System.Windows.Forms.GroupBox();
            this.GeneralProgress = new System.Windows.Forms.ProgressBar();
            this.ServerInput = new System.Windows.Forms.TextBox();
            this.ServerOutput = new System.Windows.Forms.TextBox();
            this.TopBar = new System.Windows.Forms.MenuStrip();
            this.StartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.StopServer = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateServerData = new System.Windows.Forms.ToolStripMenuItem();
            this.FiveMLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadClient = new System.Net.WebClient();
            this.AutoRestart = new System.Windows.Forms.Timer(this.components);
            this.EditServerConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildSelector.SuspendLayout();
            this.ServerData.SuspendLayout();
            this.Console.SuspendLayout();
            this.TopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildSelector
            // 
            this.BuildSelector.Controls.Add(this.RefreshBuilds);
            this.BuildSelector.Controls.Add(this.BuildList);
            this.BuildSelector.Location = new System.Drawing.Point(12, 27);
            this.BuildSelector.Name = "BuildSelector";
            this.BuildSelector.Size = new System.Drawing.Size(380, 50);
            this.BuildSelector.TabIndex = 0;
            this.BuildSelector.TabStop = false;
            this.BuildSelector.Text = "Build Selector";
            // 
            // RefreshBuilds
            // 
            this.RefreshBuilds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshBuilds.Location = new System.Drawing.Point(296, 18);
            this.RefreshBuilds.Name = "RefreshBuilds";
            this.RefreshBuilds.Size = new System.Drawing.Size(75, 23);
            this.RefreshBuilds.TabIndex = 2;
            this.RefreshBuilds.Text = "Refresh List";
            this.RefreshBuilds.UseVisualStyleBackColor = true;
            this.RefreshBuilds.Click += new System.EventHandler(this.RefreshBuilds_Click);
            // 
            // BuildList
            // 
            this.BuildList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildList.FormattingEnabled = true;
            this.BuildList.Location = new System.Drawing.Point(6, 19);
            this.BuildList.Name = "BuildList";
            this.BuildList.Size = new System.Drawing.Size(284, 21);
            this.BuildList.TabIndex = 0;
            this.BuildList.SelectedIndexChanged += new System.EventHandler(this.BuildList_SelectedIndexChanged);
            // 
            // ServerData
            // 
            this.ServerData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerData.Controls.Add(this.RefreshData);
            this.ServerData.Controls.Add(this.DataList);
            this.ServerData.Location = new System.Drawing.Point(408, 27);
            this.ServerData.Name = "ServerData";
            this.ServerData.Size = new System.Drawing.Size(380, 50);
            this.ServerData.TabIndex = 1;
            this.ServerData.TabStop = false;
            this.ServerData.Text = "Server Data";
            // 
            // RefreshData
            // 
            this.RefreshData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshData.Location = new System.Drawing.Point(299, 18);
            this.RefreshData.Name = "RefreshData";
            this.RefreshData.Size = new System.Drawing.Size(75, 23);
            this.RefreshData.TabIndex = 3;
            this.RefreshData.Text = "Refresh List";
            this.RefreshData.UseVisualStyleBackColor = true;
            this.RefreshData.Click += new System.EventHandler(this.RefreshData_Click);
            // 
            // DataList
            // 
            this.DataList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataList.FormattingEnabled = true;
            this.DataList.Location = new System.Drawing.Point(6, 19);
            this.DataList.Name = "DataList";
            this.DataList.Size = new System.Drawing.Size(287, 21);
            this.DataList.TabIndex = 0;
            this.DataList.SelectedIndexChanged += new System.EventHandler(this.DataList_SelectedIndexChanged);
            // 
            // Console
            // 
            this.Console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Console.Controls.Add(this.GeneralProgress);
            this.Console.Controls.Add(this.ServerInput);
            this.Console.Controls.Add(this.ServerOutput);
            this.Console.Location = new System.Drawing.Point(12, 83);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(776, 355);
            this.Console.TabIndex = 2;
            this.Console.TabStop = false;
            this.Console.Text = "Console";
            // 
            // GeneralProgress
            // 
            this.GeneralProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralProgress.Location = new System.Drawing.Point(6, 300);
            this.GeneralProgress.Name = "GeneralProgress";
            this.GeneralProgress.Size = new System.Drawing.Size(764, 23);
            this.GeneralProgress.TabIndex = 2;
            // 
            // ServerInput
            // 
            this.ServerInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerInput.Location = new System.Drawing.Point(6, 329);
            this.ServerInput.Name = "ServerInput";
            this.ServerInput.Size = new System.Drawing.Size(764, 20);
            this.ServerInput.TabIndex = 1;
            this.ServerInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerInput_KeyDown);
            // 
            // ServerOutput
            // 
            this.ServerOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerOutput.Location = new System.Drawing.Point(6, 19);
            this.ServerOutput.Multiline = true;
            this.ServerOutput.Name = "ServerOutput";
            this.ServerOutput.ReadOnly = true;
            this.ServerOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ServerOutput.Size = new System.Drawing.Size(764, 275);
            this.ServerOutput.TabIndex = 0;
            // 
            // TopBar
            // 
            this.TopBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartServer,
            this.StopServer,
            this.CreateServerData,
            this.EditServerConfig,
            this.FiveMLicense,
            this.OpenSettings});
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(800, 24);
            this.TopBar.TabIndex = 3;
            this.TopBar.Text = "menuStrip1";
            // 
            // StartServer
            // 
            this.StartServer.Name = "StartServer";
            this.StartServer.Size = new System.Drawing.Size(78, 20);
            this.StartServer.Text = "Start Server";
            this.StartServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // StopServer
            // 
            this.StopServer.Name = "StopServer";
            this.StopServer.Size = new System.Drawing.Size(78, 20);
            this.StopServer.Text = "Stop Server";
            this.StopServer.Click += new System.EventHandler(this.StopServer_Click);
            // 
            // CreateServerData
            // 
            this.CreateServerData.Name = "CreateServerData";
            this.CreateServerData.Size = new System.Drawing.Size(115, 20);
            this.CreateServerData.Text = "Create Server Data";
            this.CreateServerData.Click += new System.EventHandler(this.CreateServerData_Click);
            // 
            // FiveMLicense
            // 
            this.FiveMLicense.Name = "FiveMLicense";
            this.FiveMLicense.Size = new System.Drawing.Size(143, 20);
            this.FiveMLicense.Text = "Generate FiveM License";
            this.FiveMLicense.Click += new System.EventHandler(this.FiveMLicense_Click);
            // 
            // OpenSettings
            // 
            this.OpenSettings.Name = "OpenSettings";
            this.OpenSettings.Size = new System.Drawing.Size(61, 20);
            this.OpenSettings.Text = "Settings";
            this.OpenSettings.Click += new System.EventHandler(this.OpenSettings_Click);
            // 
            // DownloadClient
            // 
            this.DownloadClient.BaseAddress = "";
            this.DownloadClient.CachePolicy = null;
            this.DownloadClient.Credentials = null;
            this.DownloadClient.Encoding = ((System.Text.Encoding)(resources.GetObject("DownloadClient.Encoding")));
            this.DownloadClient.Headers = ((System.Net.WebHeaderCollection)(resources.GetObject("DownloadClient.Headers")));
            this.DownloadClient.QueryString = ((System.Collections.Specialized.NameValueCollection)(resources.GetObject("DownloadClient.QueryString")));
            this.DownloadClient.UseDefaultCredentials = false;
            this.DownloadClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(this.DownloadClient_DownloadProgressChanged);
            // 
            // AutoRestart
            // 
            this.AutoRestart.Enabled = true;
            this.AutoRestart.Interval = 500;
            this.AutoRestart.Tick += new System.EventHandler(this.AutoRestart_Tick);
            // 
            // EditServerConfig
            // 
            this.EditServerConfig.Name = "EditServerConfig";
            this.EditServerConfig.Size = new System.Drawing.Size(151, 20);
            this.EditServerConfig.Text = "Edit Server Configuration";
            this.EditServerConfig.Click += new System.EventHandler(this.EditServerConfig_Click);
            // 
            // Landing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.ServerData);
            this.Controls.Add(this.BuildSelector);
            this.Controls.Add(this.TopBar);
            this.MainMenuStrip = this.TopBar;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Landing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Landing_FormClosing);
            this.BuildSelector.ResumeLayout(false);
            this.ServerData.ResumeLayout(false);
            this.Console.ResumeLayout(false);
            this.Console.PerformLayout();
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox BuildSelector;
        private System.Windows.Forms.ComboBox BuildList;
        private System.Windows.Forms.GroupBox ServerData;
        private System.Windows.Forms.Button RefreshBuilds;
        private System.Windows.Forms.Button RefreshData;
        private System.Windows.Forms.ComboBox DataList;
        private System.Windows.Forms.GroupBox Console;
        private System.Windows.Forms.TextBox ServerInput;
        private System.Windows.Forms.TextBox ServerOutput;
        private System.Windows.Forms.MenuStrip TopBar;
        private System.Windows.Forms.ToolStripMenuItem OpenSettings;
        private System.Windows.Forms.ToolStripMenuItem StartServer;
        private System.Net.WebClient DownloadClient;
        private System.Windows.Forms.ProgressBar GeneralProgress;
        private System.Windows.Forms.ToolStripMenuItem CreateServerData;
        private System.Windows.Forms.ToolStripMenuItem StopServer;
        private System.Windows.Forms.Timer AutoRestart;
        private System.Windows.Forms.ToolStripMenuItem FiveMLicense;
        private System.Windows.Forms.ToolStripMenuItem EditServerConfig;
    }
}

