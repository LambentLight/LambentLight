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
            this.BuildSelector = new System.Windows.Forms.GroupBox();
            this.BuildList = new System.Windows.Forms.ComboBox();
            this.ServerData = new System.Windows.Forms.GroupBox();
            this.RefreshBuilds = new System.Windows.Forms.Button();
            this.DataList = new System.Windows.Forms.ComboBox();
            this.RefreshData = new System.Windows.Forms.Button();
            this.BuildSelector.SuspendLayout();
            this.ServerData.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildSelector
            // 
            this.BuildSelector.Controls.Add(this.RefreshBuilds);
            this.BuildSelector.Controls.Add(this.BuildList);
            this.BuildSelector.Location = new System.Drawing.Point(12, 12);
            this.BuildSelector.Name = "BuildSelector";
            this.BuildSelector.Size = new System.Drawing.Size(380, 50);
            this.BuildSelector.TabIndex = 0;
            this.BuildSelector.TabStop = false;
            this.BuildSelector.Text = "Build Selector";
            // 
            // BuildList
            // 
            this.BuildList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildList.FormattingEnabled = true;
            this.BuildList.Location = new System.Drawing.Point(6, 19);
            this.BuildList.Name = "BuildList";
            this.BuildList.Size = new System.Drawing.Size(284, 21);
            this.BuildList.TabIndex = 0;
            // 
            // ServerData
            // 
            this.ServerData.Controls.Add(this.RefreshData);
            this.ServerData.Controls.Add(this.DataList);
            this.ServerData.Location = new System.Drawing.Point(408, 12);
            this.ServerData.Name = "ServerData";
            this.ServerData.Size = new System.Drawing.Size(380, 50);
            this.ServerData.TabIndex = 1;
            this.ServerData.TabStop = false;
            this.ServerData.Text = "Server Data";
            // 
            // RefreshBuilds
            // 
            this.RefreshBuilds.Location = new System.Drawing.Point(296, 18);
            this.RefreshBuilds.Name = "RefreshBuilds";
            this.RefreshBuilds.Size = new System.Drawing.Size(75, 23);
            this.RefreshBuilds.TabIndex = 2;
            this.RefreshBuilds.Text = "Refresh List";
            this.RefreshBuilds.UseVisualStyleBackColor = true;
            // 
            // DataList
            // 
            this.DataList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataList.FormattingEnabled = true;
            this.DataList.Location = new System.Drawing.Point(6, 19);
            this.DataList.Name = "DataList";
            this.DataList.Size = new System.Drawing.Size(287, 21);
            this.DataList.TabIndex = 0;
            // 
            // RefreshData
            // 
            this.RefreshData.Location = new System.Drawing.Point(299, 18);
            this.RefreshData.Name = "RefreshData";
            this.RefreshData.Size = new System.Drawing.Size(75, 23);
            this.RefreshData.TabIndex = 3;
            this.RefreshData.Text = "Refresh List";
            this.RefreshData.UseVisualStyleBackColor = true;
            // 
            // Landing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ServerData);
            this.Controls.Add(this.BuildSelector);
            this.Name = "Landing";
            this.Text = "ServerManager";
            this.BuildSelector.ResumeLayout(false);
            this.ServerData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox BuildSelector;
        private System.Windows.Forms.ComboBox BuildList;
        private System.Windows.Forms.GroupBox ServerData;
        private System.Windows.Forms.Button RefreshBuilds;
        private System.Windows.Forms.Button RefreshData;
        private System.Windows.Forms.ComboBox DataList;
    }
}

