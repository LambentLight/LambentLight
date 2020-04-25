namespace LambentLight
{
    partial class FormLanding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLanding));
            this.ManagerToolStrip = new System.Windows.Forms.ToolStrip();
            this.StartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.StopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RestartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SettingsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ConsoleTabPage = new System.Windows.Forms.TabPage();
            this.ServerConsoleControl = new ConsoleControl.ConsoleControl();
            this.ManagerToolStrip.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.ConsoleTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManagerToolStrip
            // 
            this.ManagerToolStrip.AutoSize = false;
            this.ManagerToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.ManagerToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ManagerToolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.ManagerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripButton,
            this.StopToolStripButton,
            this.RestartToolStripButton,
            this.SettingsToolStripButton});
            this.ManagerToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ManagerToolStrip.Name = "ManagerToolStrip";
            this.ManagerToolStrip.Padding = new System.Windows.Forms.Padding(2);
            this.ManagerToolStrip.Size = new System.Drawing.Size(37, 450);
            this.ManagerToolStrip.TabIndex = 0;
            // 
            // StartToolStripButton
            // 
            this.StartToolStripButton.AutoSize = false;
            this.StartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StartToolStripButton.Image")));
            this.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartToolStripButton.Name = "StartToolStripButton";
            this.StartToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.StartToolStripButton.Size = new System.Drawing.Size(33, 33);
            this.StartToolStripButton.Text = "toolStripButton1";
            // 
            // StopToolStripButton
            // 
            this.StopToolStripButton.AutoSize = false;
            this.StopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StopToolStripButton.Image")));
            this.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopToolStripButton.Name = "StopToolStripButton";
            this.StopToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.StopToolStripButton.Size = new System.Drawing.Size(33, 33);
            this.StopToolStripButton.Text = "toolStripButton2";
            // 
            // RestartToolStripButton
            // 
            this.RestartToolStripButton.AutoSize = false;
            this.RestartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RestartToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RestartToolStripButton.Image")));
            this.RestartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RestartToolStripButton.Name = "RestartToolStripButton";
            this.RestartToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.RestartToolStripButton.Size = new System.Drawing.Size(33, 33);
            this.RestartToolStripButton.Text = "toolStripButton3";
            // 
            // SettingsToolStripButton
            // 
            this.SettingsToolStripButton.AutoSize = false;
            this.SettingsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsToolStripButton.Image")));
            this.SettingsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsToolStripButton.Name = "SettingsToolStripButton";
            this.SettingsToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.SettingsToolStripButton.Size = new System.Drawing.Size(33, 33);
            this.SettingsToolStripButton.Text = "toolStripButton4";
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.ConsoleTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(40, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(748, 426);
            this.MainTabControl.TabIndex = 1;
            // 
            // ConsoleTabPage
            // 
            this.ConsoleTabPage.Controls.Add(this.ServerConsoleControl);
            this.ConsoleTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConsoleTabPage.Name = "ConsoleTabPage";
            this.ConsoleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConsoleTabPage.Size = new System.Drawing.Size(740, 400);
            this.ConsoleTabPage.TabIndex = 0;
            this.ConsoleTabPage.Text = "Console";
            this.ConsoleTabPage.UseVisualStyleBackColor = true;
            // 
            // ServerConsoleControl
            // 
            this.ServerConsoleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerConsoleControl.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerConsoleControl.IsInputEnabled = true;
            this.ServerConsoleControl.Location = new System.Drawing.Point(3, 3);
            this.ServerConsoleControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ServerConsoleControl.Name = "ServerConsoleControl";
            this.ServerConsoleControl.SendKeyboardCommandsToProcess = false;
            this.ServerConsoleControl.ShowDiagnostics = false;
            this.ServerConsoleControl.Size = new System.Drawing.Size(734, 394);
            this.ServerConsoleControl.TabIndex = 0;
            // 
            // FormLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.ManagerToolStrip);
            this.Name = "FormLanding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LambentLight";
            this.Shown += new System.EventHandler(this.FormLanding_Shown);
            this.ManagerToolStrip.ResumeLayout(false);
            this.ManagerToolStrip.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.ConsoleTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip ManagerToolStrip;
        private System.Windows.Forms.ToolStripButton StartToolStripButton;
        private System.Windows.Forms.ToolStripButton StopToolStripButton;
        private System.Windows.Forms.ToolStripButton RestartToolStripButton;
        private System.Windows.Forms.ToolStripButton SettingsToolStripButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ConsoleTabPage;
        private ConsoleControl.ConsoleControl ServerConsoleControl;
    }
}