
namespace LambentLight.GUI
{
    partial class FormResources
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResources));
            this.ResourcesGroupBox = new System.Windows.Forms.GroupBox();
            this.ResourcesListBox = new System.Windows.Forms.ListBox();
            this.ResourcesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResourcesGroupBox
            // 
            this.ResourcesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ResourcesGroupBox.Controls.Add(this.ResourcesListBox);
            this.ResourcesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ResourcesGroupBox.Name = "ResourcesGroupBox";
            this.ResourcesGroupBox.Size = new System.Drawing.Size(200, 426);
            this.ResourcesGroupBox.TabIndex = 0;
            this.ResourcesGroupBox.TabStop = false;
            this.ResourcesGroupBox.Text = "Resources";
            // 
            // ResourcesListBox
            // 
            this.ResourcesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourcesListBox.FormattingEnabled = true;
            this.ResourcesListBox.Location = new System.Drawing.Point(6, 19);
            this.ResourcesListBox.Name = "ResourcesListBox";
            this.ResourcesListBox.Size = new System.Drawing.Size(188, 394);
            this.ResourcesListBox.TabIndex = 0;
            // 
            // FormResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResourcesGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormResources";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resources of";
            this.Load += new System.EventHandler(this.FormResources_Load);
            this.ResourcesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ResourcesGroupBox;
        private System.Windows.Forms.ListBox ResourcesListBox;
    }
}