namespace LambentLight
{
    partial class FormFolderConfig
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
            this.OneSyncGroupBox = new System.Windows.Forms.GroupBox();
            this.OneSyncInfCheckBox = new System.Windows.Forms.CheckBox();
            this.OneSyncCheckBox = new System.Windows.Forms.CheckBox();
            this.GameGroupBox = new System.Windows.Forms.GroupBox();
            this.GameComboBox = new System.Windows.Forms.ComboBox();
            this.BuildsGroupBox = new System.Windows.Forms.GroupBox();
            this.BuildsComboBox = new System.Windows.Forms.ComboBox();
            this.BuildsInfoLabel = new System.Windows.Forms.Label();
            this.BuildsLatestCheckBox = new System.Windows.Forms.CheckBox();
            this.ConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfigTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.OneSyncGroupBox.SuspendLayout();
            this.GameGroupBox.SuspendLayout();
            this.BuildsGroupBox.SuspendLayout();
            this.ConfigGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OneSyncGroupBox
            // 
            this.OneSyncGroupBox.Controls.Add(this.OneSyncInfCheckBox);
            this.OneSyncGroupBox.Controls.Add(this.OneSyncCheckBox);
            this.OneSyncGroupBox.Location = new System.Drawing.Point(12, 68);
            this.OneSyncGroupBox.Name = "OneSyncGroupBox";
            this.OneSyncGroupBox.Size = new System.Drawing.Size(300, 65);
            this.OneSyncGroupBox.TabIndex = 0;
            this.OneSyncGroupBox.TabStop = false;
            this.OneSyncGroupBox.Text = "OneSync";
            // 
            // OneSyncInfCheckBox
            // 
            this.OneSyncInfCheckBox.AutoSize = true;
            this.OneSyncInfCheckBox.Location = new System.Drawing.Point(6, 42);
            this.OneSyncInfCheckBox.Name = "OneSyncInfCheckBox";
            this.OneSyncInfCheckBox.Size = new System.Drawing.Size(139, 17);
            this.OneSyncInfCheckBox.TabIndex = 1;
            this.OneSyncInfCheckBox.Text = "Enable OneSync Infinity";
            this.OneSyncInfCheckBox.UseVisualStyleBackColor = true;
            // 
            // OneSyncCheckBox
            // 
            this.OneSyncCheckBox.AutoSize = true;
            this.OneSyncCheckBox.Location = new System.Drawing.Point(6, 19);
            this.OneSyncCheckBox.Name = "OneSyncCheckBox";
            this.OneSyncCheckBox.Size = new System.Drawing.Size(106, 17);
            this.OneSyncCheckBox.TabIndex = 0;
            this.OneSyncCheckBox.Text = "Enable OneSync";
            this.OneSyncCheckBox.UseVisualStyleBackColor = true;
            this.OneSyncCheckBox.CheckedChanged += new System.EventHandler(this.OneSyncCheckBox_CheckedChanged);
            // 
            // GameGroupBox
            // 
            this.GameGroupBox.Controls.Add(this.GameComboBox);
            this.GameGroupBox.Location = new System.Drawing.Point(12, 12);
            this.GameGroupBox.Name = "GameGroupBox";
            this.GameGroupBox.Size = new System.Drawing.Size(300, 50);
            this.GameGroupBox.TabIndex = 1;
            this.GameGroupBox.TabStop = false;
            this.GameGroupBox.Text = "Game";
            // 
            // GameComboBox
            // 
            this.GameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameComboBox.FormattingEnabled = true;
            this.GameComboBox.Location = new System.Drawing.Point(6, 19);
            this.GameComboBox.Name = "GameComboBox";
            this.GameComboBox.Size = new System.Drawing.Size(288, 21);
            this.GameComboBox.TabIndex = 0;
            // 
            // BuildsGroupBox
            // 
            this.BuildsGroupBox.Controls.Add(this.BuildsComboBox);
            this.BuildsGroupBox.Controls.Add(this.BuildsInfoLabel);
            this.BuildsGroupBox.Controls.Add(this.BuildsLatestCheckBox);
            this.BuildsGroupBox.Location = new System.Drawing.Point(318, 12);
            this.BuildsGroupBox.Name = "BuildsGroupBox";
            this.BuildsGroupBox.Size = new System.Drawing.Size(300, 85);
            this.BuildsGroupBox.TabIndex = 2;
            this.BuildsGroupBox.TabStop = false;
            this.BuildsGroupBox.Text = "Builds";
            // 
            // BuildsComboBox
            // 
            this.BuildsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildsComboBox.FormattingEnabled = true;
            this.BuildsComboBox.Location = new System.Drawing.Point(6, 55);
            this.BuildsComboBox.Name = "BuildsComboBox";
            this.BuildsComboBox.Size = new System.Drawing.Size(288, 21);
            this.BuildsComboBox.TabIndex = 2;
            // 
            // BuildsInfoLabel
            // 
            this.BuildsInfoLabel.AutoSize = true;
            this.BuildsInfoLabel.Location = new System.Drawing.Point(6, 39);
            this.BuildsInfoLabel.Name = "BuildsInfoLabel";
            this.BuildsInfoLabel.Size = new System.Drawing.Size(138, 13);
            this.BuildsInfoLabel.TabIndex = 1;
            this.BuildsInfoLabel.Text = "Or use a specific CFX Build:";
            // 
            // BuildsLatestCheckBox
            // 
            this.BuildsLatestCheckBox.AutoSize = true;
            this.BuildsLatestCheckBox.Location = new System.Drawing.Point(6, 19);
            this.BuildsLatestCheckBox.Name = "BuildsLatestCheckBox";
            this.BuildsLatestCheckBox.Size = new System.Drawing.Size(178, 17);
            this.BuildsLatestCheckBox.TabIndex = 0;
            this.BuildsLatestCheckBox.Text = "Always use the Latest CFX Build";
            this.BuildsLatestCheckBox.UseVisualStyleBackColor = true;
            this.BuildsLatestCheckBox.CheckedChanged += new System.EventHandler(this.BuildsLatestCheckBox_CheckedChanged);
            // 
            // ConfigGroupBox
            // 
            this.ConfigGroupBox.Controls.Add(this.ConfigTextBox);
            this.ConfigGroupBox.Location = new System.Drawing.Point(318, 103);
            this.ConfigGroupBox.Name = "ConfigGroupBox";
            this.ConfigGroupBox.Size = new System.Drawing.Size(300, 50);
            this.ConfigGroupBox.TabIndex = 3;
            this.ConfigGroupBox.TabStop = false;
            this.ConfigGroupBox.Text = "Default Configuration File";
            // 
            // ConfigTextBox
            // 
            this.ConfigTextBox.Location = new System.Drawing.Point(6, 19);
            this.ConfigTextBox.Name = "ConfigTextBox";
            this.ConfigTextBox.Size = new System.Drawing.Size(288, 20);
            this.ConfigTextBox.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(543, 159);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AcceptButton.Location = new System.Drawing.Point(462, 159);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 5;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // FormFolderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 189);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfigGroupBox);
            this.Controls.Add(this.BuildsGroupBox);
            this.Controls.Add(this.GameGroupBox);
            this.Controls.Add(this.OneSyncGroupBox);
            this.Name = "FormFolderConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Folder Configuration";
            this.OneSyncGroupBox.ResumeLayout(false);
            this.OneSyncGroupBox.PerformLayout();
            this.GameGroupBox.ResumeLayout(false);
            this.BuildsGroupBox.ResumeLayout(false);
            this.BuildsGroupBox.PerformLayout();
            this.ConfigGroupBox.ResumeLayout(false);
            this.ConfigGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox OneSyncGroupBox;
        private System.Windows.Forms.CheckBox OneSyncInfCheckBox;
        private System.Windows.Forms.CheckBox OneSyncCheckBox;
        private System.Windows.Forms.GroupBox GameGroupBox;
        private System.Windows.Forms.ComboBox GameComboBox;
        private System.Windows.Forms.GroupBox BuildsGroupBox;
        private System.Windows.Forms.CheckBox BuildsLatestCheckBox;
        private System.Windows.Forms.Label BuildsInfoLabel;
        private System.Windows.Forms.ComboBox BuildsComboBox;
        private System.Windows.Forms.GroupBox ConfigGroupBox;
        private System.Windows.Forms.TextBox ConfigTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AcceptButton;
    }
}