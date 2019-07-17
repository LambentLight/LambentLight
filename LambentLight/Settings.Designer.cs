namespace LambentLight
{
    partial class Settings
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
            this.LicenseInput = new System.Windows.Forms.GroupBox();
            this.License = new System.Windows.Forms.TextBox();
            this.Running = new System.Windows.Forms.GroupBox();
            this.DownloadScripts = new System.Windows.Forms.CheckBox();
            this.ClearCache = new System.Windows.Forms.CheckBox();
            this.AutoRestart = new System.Windows.Forms.CheckBox();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.ResourceAPI = new System.Windows.Forms.GroupBox();
            this.ResourceDownload = new System.Windows.Forms.TextBox();
            this.ScriptDLOptions = new System.Windows.Forms.GroupBox();
            this.ShowConfigOpt = new System.Windows.Forms.CheckBox();
            this.Scheduled = new System.Windows.Forms.GroupBox();
            this.ScheduledTime = new System.Windows.Forms.TextBox();
            this.Time = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.Label();
            this.ScheduledMode = new System.Windows.Forms.ComboBox();
            this.ScheduledRestarts = new System.Windows.Forms.CheckBox();
            this.BuildsGroup = new System.Windows.Forms.GroupBox();
            this.BuildsBox = new System.Windows.Forms.TextBox();
            this.LicenseInput.SuspendLayout();
            this.Running.SuspendLayout();
            this.ResourceAPI.SuspendLayout();
            this.ScriptDLOptions.SuspendLayout();
            this.Scheduled.SuspendLayout();
            this.BuildsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // LicenseInput
            // 
            this.LicenseInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseInput.Controls.Add(this.License);
            this.LicenseInput.Location = new System.Drawing.Point(12, 12);
            this.LicenseInput.Name = "LicenseInput";
            this.LicenseInput.Size = new System.Drawing.Size(310, 50);
            this.LicenseInput.TabIndex = 0;
            this.LicenseInput.TabStop = false;
            this.LicenseInput.Text = "FiveM License";
            // 
            // License
            // 
            this.License.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.License.Location = new System.Drawing.Point(6, 19);
            this.License.Name = "License";
            this.License.Size = new System.Drawing.Size(298, 20);
            this.License.TabIndex = 0;
            // 
            // Running
            // 
            this.Running.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Running.Controls.Add(this.DownloadScripts);
            this.Running.Controls.Add(this.ClearCache);
            this.Running.Controls.Add(this.AutoRestart);
            this.Running.Location = new System.Drawing.Point(12, 180);
            this.Running.Name = "Running";
            this.Running.Size = new System.Drawing.Size(310, 87);
            this.Running.TabIndex = 1;
            this.Running.TabStop = false;
            this.Running.Text = "Running Options";
            // 
            // DownloadScripts
            // 
            this.DownloadScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadScripts.AutoSize = true;
            this.DownloadScripts.Location = new System.Drawing.Point(6, 65);
            this.DownloadScripts.Name = "DownloadScripts";
            this.DownloadScripts.Size = new System.Drawing.Size(295, 17);
            this.DownloadScripts.TabIndex = 2;
            this.DownloadScripts.Text = "Download vanilla scripts when creating a new data folder";
            this.DownloadScripts.UseVisualStyleBackColor = true;
            // 
            // ClearCache
            // 
            this.ClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearCache.AutoSize = true;
            this.ClearCache.Location = new System.Drawing.Point(6, 42);
            this.ClearCache.Name = "ClearCache";
            this.ClearCache.Size = new System.Drawing.Size(223, 17);
            this.ClearCache.TabIndex = 1;
            this.ClearCache.Text = "Clear the cache prior to starting the server";
            this.ClearCache.UseVisualStyleBackColor = true;
            // 
            // AutoRestart
            // 
            this.AutoRestart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoRestart.AutoSize = true;
            this.AutoRestart.Location = new System.Drawing.Point(6, 19);
            this.AutoRestart.Name = "AutoRestart";
            this.AutoRestart.Size = new System.Drawing.Size(179, 17);
            this.AutoRestart.TabIndex = 0;
            this.AutoRestart.Text = "Auto Restart the server on crash";
            this.AutoRestart.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Location = new System.Drawing.Point(166, 430);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.Location = new System.Drawing.Point(247, 430);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ResourceAPI
            // 
            this.ResourceAPI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourceAPI.Controls.Add(this.ResourceDownload);
            this.ResourceAPI.Location = new System.Drawing.Point(12, 68);
            this.ResourceAPI.Name = "ResourceAPI";
            this.ResourceAPI.Size = new System.Drawing.Size(310, 50);
            this.ResourceAPI.TabIndex = 1;
            this.ResourceAPI.TabStop = false;
            this.ResourceAPI.Text = "Resource API";
            // 
            // ResourceDownload
            // 
            this.ResourceDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourceDownload.Location = new System.Drawing.Point(6, 19);
            this.ResourceDownload.Name = "ResourceDownload";
            this.ResourceDownload.Size = new System.Drawing.Size(298, 20);
            this.ResourceDownload.TabIndex = 0;
            // 
            // ScriptDLOptions
            // 
            this.ScriptDLOptions.Controls.Add(this.ShowConfigOpt);
            this.ScriptDLOptions.Location = new System.Drawing.Point(12, 273);
            this.ScriptDLOptions.Name = "ScriptDLOptions";
            this.ScriptDLOptions.Size = new System.Drawing.Size(310, 40);
            this.ScriptDLOptions.TabIndex = 4;
            this.ScriptDLOptions.TabStop = false;
            this.ScriptDLOptions.Text = "Script Download Options";
            // 
            // ShowConfigOpt
            // 
            this.ShowConfigOpt.AutoSize = true;
            this.ShowConfigOpt.Location = new System.Drawing.Point(6, 19);
            this.ShowConfigOpt.Name = "ShowConfigOpt";
            this.ShowConfigOpt.Size = new System.Drawing.Size(268, 17);
            this.ShowConfigOpt.TabIndex = 0;
            this.ShowConfigOpt.Text = "After downloading, show config option for auto start";
            this.ShowConfigOpt.UseVisualStyleBackColor = true;
            // 
            // Scheduled
            // 
            this.Scheduled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Scheduled.Controls.Add(this.ScheduledTime);
            this.Scheduled.Controls.Add(this.Time);
            this.Scheduled.Controls.Add(this.Mode);
            this.Scheduled.Controls.Add(this.ScheduledMode);
            this.Scheduled.Controls.Add(this.ScheduledRestarts);
            this.Scheduled.Location = new System.Drawing.Point(12, 319);
            this.Scheduled.Name = "Scheduled";
            this.Scheduled.Size = new System.Drawing.Size(310, 104);
            this.Scheduled.TabIndex = 5;
            this.Scheduled.TabStop = false;
            this.Scheduled.Text = "Scheduled Server Restarts";
            // 
            // ScheduledTime
            // 
            this.ScheduledTime.Location = new System.Drawing.Point(47, 69);
            this.ScheduledTime.Name = "ScheduledTime";
            this.ScheduledTime.Size = new System.Drawing.Size(257, 20);
            this.ScheduledTime.TabIndex = 5;
            // 
            // Time
            // 
            this.Time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(3, 72);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(30, 13);
            this.Time.TabIndex = 4;
            this.Time.Text = "Time";
            // 
            // Mode
            // 
            this.Mode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Mode.AutoSize = true;
            this.Mode.Location = new System.Drawing.Point(3, 45);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(34, 13);
            this.Mode.TabIndex = 3;
            this.Mode.Text = "Mode";
            // 
            // ScheduledMode
            // 
            this.ScheduledMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScheduledMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScheduledMode.FormattingEnabled = true;
            this.ScheduledMode.Items.AddRange(new object[] {
            "Every few minutes/hours/days",
            "Selected time every day"});
            this.ScheduledMode.Location = new System.Drawing.Point(47, 42);
            this.ScheduledMode.Name = "ScheduledMode";
            this.ScheduledMode.Size = new System.Drawing.Size(257, 21);
            this.ScheduledMode.TabIndex = 2;
            // 
            // ScheduledRestarts
            // 
            this.ScheduledRestarts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScheduledRestarts.AutoSize = true;
            this.ScheduledRestarts.Location = new System.Drawing.Point(6, 19);
            this.ScheduledRestarts.Name = "ScheduledRestarts";
            this.ScheduledRestarts.Size = new System.Drawing.Size(189, 17);
            this.ScheduledRestarts.TabIndex = 0;
            this.ScheduledRestarts.Text = "Enable Scheduled Server Restarts";
            this.ScheduledRestarts.UseVisualStyleBackColor = true;
            this.ScheduledRestarts.CheckedChanged += new System.EventHandler(this.ScheduledRestarts_CheckedChanged);
            // 
            // BuildsGroup
            // 
            this.BuildsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsGroup.Controls.Add(this.BuildsBox);
            this.BuildsGroup.Location = new System.Drawing.Point(12, 124);
            this.BuildsGroup.Name = "BuildsGroup";
            this.BuildsGroup.Size = new System.Drawing.Size(310, 50);
            this.BuildsGroup.TabIndex = 2;
            this.BuildsGroup.TabStop = false;
            this.BuildsGroup.Text = "Builds API";
            // 
            // BuildsBox
            // 
            this.BuildsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildsBox.Location = new System.Drawing.Point(6, 19);
            this.BuildsBox.Name = "BuildsBox";
            this.BuildsBox.Size = new System.Drawing.Size(298, 20);
            this.BuildsBox.TabIndex = 0;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 460);
            this.Controls.Add(this.BuildsGroup);
            this.Controls.Add(this.Scheduled);
            this.Controls.Add(this.ScriptDLOptions);
            this.Controls.Add(this.ResourceAPI);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Running);
            this.Controls.Add(this.LicenseInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.LicenseInput.ResumeLayout(false);
            this.LicenseInput.PerformLayout();
            this.Running.ResumeLayout(false);
            this.Running.PerformLayout();
            this.ResourceAPI.ResumeLayout(false);
            this.ResourceAPI.PerformLayout();
            this.ScriptDLOptions.ResumeLayout(false);
            this.ScriptDLOptions.PerformLayout();
            this.Scheduled.ResumeLayout(false);
            this.Scheduled.PerformLayout();
            this.BuildsGroup.ResumeLayout(false);
            this.BuildsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LicenseInput;
        private System.Windows.Forms.TextBox License;
        private System.Windows.Forms.GroupBox Running;
        private System.Windows.Forms.CheckBox AutoRestart;
        private System.Windows.Forms.CheckBox DownloadScripts;
        private System.Windows.Forms.CheckBox ClearCache;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.GroupBox ResourceAPI;
        private System.Windows.Forms.TextBox ResourceDownload;
        private System.Windows.Forms.GroupBox ScriptDLOptions;
        private System.Windows.Forms.CheckBox ShowConfigOpt;
        private System.Windows.Forms.GroupBox Scheduled;
        private System.Windows.Forms.CheckBox ScheduledRestarts;
        private System.Windows.Forms.Label Mode;
        private System.Windows.Forms.ComboBox ScheduledMode;
        private System.Windows.Forms.TextBox ScheduledTime;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.GroupBox BuildsGroup;
        private System.Windows.Forms.TextBox BuildsBox;
    }
}