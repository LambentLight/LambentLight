
namespace LambentLight.GUI
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.IPGroupBox = new System.Windows.Forms.GroupBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.TokenGroupBox = new System.Windows.Forms.GroupBox();
            this.TokenTextBox = new System.Windows.Forms.TextBox();
            this.RememberCheckBox = new System.Windows.Forms.CheckBox();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.AutoCheckBox = new System.Windows.Forms.CheckBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.IPGroupBox.SuspendLayout();
            this.TokenGroupBox.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPGroupBox
            // 
            this.IPGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IPGroupBox.Controls.Add(this.IPTextBox);
            this.IPGroupBox.Location = new System.Drawing.Point(12, 12);
            this.IPGroupBox.Name = "IPGroupBox";
            this.IPGroupBox.Size = new System.Drawing.Size(327, 50);
            this.IPGroupBox.TabIndex = 0;
            this.IPGroupBox.TabStop = false;
            this.IPGroupBox.Text = "IP";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IPTextBox.Location = new System.Drawing.Point(6, 19);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(315, 20);
            this.IPTextBox.TabIndex = 0;
            // 
            // TokenGroupBox
            // 
            this.TokenGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenGroupBox.Controls.Add(this.TokenTextBox);
            this.TokenGroupBox.Location = new System.Drawing.Point(12, 68);
            this.TokenGroupBox.Name = "TokenGroupBox";
            this.TokenGroupBox.Size = new System.Drawing.Size(327, 50);
            this.TokenGroupBox.TabIndex = 1;
            this.TokenGroupBox.TabStop = false;
            this.TokenGroupBox.Text = "Token";
            // 
            // TokenTextBox
            // 
            this.TokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenTextBox.Location = new System.Drawing.Point(6, 19);
            this.TokenTextBox.Name = "TokenTextBox";
            this.TokenTextBox.Size = new System.Drawing.Size(315, 20);
            this.TokenTextBox.TabIndex = 0;
            // 
            // RememberCheckBox
            // 
            this.RememberCheckBox.AutoSize = true;
            this.RememberCheckBox.Location = new System.Drawing.Point(6, 19);
            this.RememberCheckBox.Name = "RememberCheckBox";
            this.RememberCheckBox.Size = new System.Drawing.Size(148, 17);
            this.RememberCheckBox.TabIndex = 2;
            this.RememberCheckBox.Text = "Remember details for later";
            this.RememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsGroupBox.Controls.Add(this.AutoCheckBox);
            this.OptionsGroupBox.Controls.Add(this.RememberCheckBox);
            this.OptionsGroupBox.Location = new System.Drawing.Point(12, 124);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(327, 67);
            this.OptionsGroupBox.TabIndex = 3;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Connection Options";
            // 
            // AutoCheckBox
            // 
            this.AutoCheckBox.AutoSize = true;
            this.AutoCheckBox.Location = new System.Drawing.Point(6, 42);
            this.AutoCheckBox.Name = "AutoCheckBox";
            this.AutoCheckBox.Size = new System.Drawing.Size(310, 17);
            this.AutoCheckBox.TabIndex = 3;
            this.AutoCheckBox.Text = "Automatically connect next time that the program is oppened";
            this.AutoCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectButton.Location = new System.Drawing.Point(12, 200);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(327, 23);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 235);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.TokenGroupBox);
            this.Controls.Add(this.IPGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.IPGroupBox.ResumeLayout(false);
            this.IPGroupBox.PerformLayout();
            this.TokenGroupBox.ResumeLayout(false);
            this.TokenGroupBox.PerformLayout();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox IPGroupBox;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.GroupBox TokenGroupBox;
        private System.Windows.Forms.TextBox TokenTextBox;
        private System.Windows.Forms.CheckBox RememberCheckBox;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.CheckBox AutoCheckBox;
        private System.Windows.Forms.Button ConnectButton;
    }
}