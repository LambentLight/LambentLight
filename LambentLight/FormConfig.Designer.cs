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
            this.ConfigTabControl = new System.Windows.Forms.TabControl();
            this.AuthTabPage = new System.Windows.Forms.TabPage();
            this.CFXGroupBox = new System.Windows.Forms.GroupBox();
            this.CFXVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.CFXTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SteamGroupBox = new System.Windows.Forms.GroupBox();
            this.SteamTextBox = new System.Windows.Forms.TextBox();
            this.SteamVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.ConfigTabControl.SuspendLayout();
            this.AuthTabPage.SuspendLayout();
            this.CFXGroupBox.SuspendLayout();
            this.SteamGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigTabControl
            // 
            this.ConfigTabControl.Controls.Add(this.AuthTabPage);
            this.ConfigTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConfigTabControl.Location = new System.Drawing.Point(0, 0);
            this.ConfigTabControl.Name = "ConfigTabControl";
            this.ConfigTabControl.SelectedIndex = 0;
            this.ConfigTabControl.Size = new System.Drawing.Size(509, 295);
            this.ConfigTabControl.TabIndex = 0;
            // 
            // AuthTabPage
            // 
            this.AuthTabPage.Controls.Add(this.SteamGroupBox);
            this.AuthTabPage.Controls.Add(this.CFXGroupBox);
            this.AuthTabPage.Location = new System.Drawing.Point(4, 22);
            this.AuthTabPage.Name = "AuthTabPage";
            this.AuthTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AuthTabPage.Size = new System.Drawing.Size(501, 269);
            this.AuthTabPage.TabIndex = 0;
            this.AuthTabPage.Text = "Authentication";
            this.AuthTabPage.UseVisualStyleBackColor = true;
            // 
            // CFXGroupBox
            // 
            this.CFXGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CFXGroupBox.Controls.Add(this.CFXVisibleCheckBox);
            this.CFXGroupBox.Controls.Add(this.CFXTextBox);
            this.CFXGroupBox.Location = new System.Drawing.Point(6, 6);
            this.CFXGroupBox.Name = "CFXGroupBox";
            this.CFXGroupBox.Size = new System.Drawing.Size(489, 70);
            this.CFXGroupBox.TabIndex = 0;
            this.CFXGroupBox.TabStop = false;
            this.CFXGroupBox.Text = "CFX License";
            // 
            // CFXVisibleCheckBox
            // 
            this.CFXVisibleCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CFXVisibleCheckBox.AutoSize = true;
            this.CFXVisibleCheckBox.Location = new System.Drawing.Point(6, 47);
            this.CFXVisibleCheckBox.Name = "CFXVisibleCheckBox";
            this.CFXVisibleCheckBox.Size = new System.Drawing.Size(56, 17);
            this.CFXVisibleCheckBox.TabIndex = 2;
            this.CFXVisibleCheckBox.Text = "Visible";
            this.CFXVisibleCheckBox.UseVisualStyleBackColor = true;
            this.CFXVisibleCheckBox.CheckedChanged += new System.EventHandler(this.CFXVisibleCheckBox_CheckedChanged);
            // 
            // CFXTextBox
            // 
            this.CFXTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CFXTextBox.Location = new System.Drawing.Point(6, 19);
            this.CFXTextBox.Name = "CFXTextBox";
            this.CFXTextBox.Size = new System.Drawing.Size(477, 20);
            this.CFXTextBox.TabIndex = 0;
            this.CFXTextBox.UseSystemPasswordChar = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(341, 301);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(422, 301);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SteamGroupBox
            // 
            this.SteamGroupBox.Controls.Add(this.SteamVisibleCheckBox);
            this.SteamGroupBox.Controls.Add(this.SteamTextBox);
            this.SteamGroupBox.Location = new System.Drawing.Point(6, 82);
            this.SteamGroupBox.Name = "SteamGroupBox";
            this.SteamGroupBox.Size = new System.Drawing.Size(489, 70);
            this.SteamGroupBox.TabIndex = 1;
            this.SteamGroupBox.TabStop = false;
            this.SteamGroupBox.Text = "Steam Key";
            // 
            // SteamTextBox
            // 
            this.SteamTextBox.Location = new System.Drawing.Point(6, 19);
            this.SteamTextBox.Name = "SteamTextBox";
            this.SteamTextBox.Size = new System.Drawing.Size(477, 20);
            this.SteamTextBox.TabIndex = 0;
            this.SteamTextBox.UseSystemPasswordChar = true;
            // 
            // SteamVisibleCheckBox
            // 
            this.SteamVisibleCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SteamVisibleCheckBox.AutoSize = true;
            this.SteamVisibleCheckBox.Location = new System.Drawing.Point(6, 47);
            this.SteamVisibleCheckBox.Name = "SteamVisibleCheckBox";
            this.SteamVisibleCheckBox.Size = new System.Drawing.Size(56, 17);
            this.SteamVisibleCheckBox.TabIndex = 1;
            this.SteamVisibleCheckBox.Text = "Visible";
            this.SteamVisibleCheckBox.UseVisualStyleBackColor = true;
            this.SteamVisibleCheckBox.CheckedChanged += new System.EventHandler(this.SteamVisibleCheckBox_CheckedChanged);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 336);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ConfigTabControl);
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LambentLight Configuration";
            this.ConfigTabControl.ResumeLayout(false);
            this.AuthTabPage.ResumeLayout(false);
            this.CFXGroupBox.ResumeLayout(false);
            this.CFXGroupBox.PerformLayout();
            this.SteamGroupBox.ResumeLayout(false);
            this.SteamGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConfigTabControl;
        private System.Windows.Forms.TabPage AuthTabPage;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox CFXGroupBox;
        private System.Windows.Forms.TextBox CFXTextBox;
        private System.Windows.Forms.CheckBox CFXVisibleCheckBox;
        private System.Windows.Forms.GroupBox SteamGroupBox;
        private System.Windows.Forms.CheckBox SteamVisibleCheckBox;
        private System.Windows.Forms.TextBox SteamTextBox;
    }
}