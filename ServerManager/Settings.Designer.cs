namespace ServerManager
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
            this.LicenseInput.SuspendLayout();
            this.Running.SuspendLayout();
            this.ResourceAPI.SuspendLayout();
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
            this.Running.Location = new System.Drawing.Point(12, 124);
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
            this.Save.Location = new System.Drawing.Point(166, 221);
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
            this.Cancel.Location = new System.Drawing.Point(247, 221);
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 251);
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
    }
}