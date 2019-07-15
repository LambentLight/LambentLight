namespace LambentLight
{
    partial class Downloader
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
            this.InfoStrip = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.ResourceSelector = new System.Windows.Forms.ListBox();
            this.InfoStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoStrip
            // 
            this.InfoStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.InfoStrip.Location = new System.Drawing.Point(0, 414);
            this.InfoStrip.Name = "InfoStrip";
            this.InfoStrip.Size = new System.Drawing.Size(334, 22);
            this.InfoStrip.TabIndex = 1;
            this.InfoStrip.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(171, 17);
            this.Status.Text = "Waiting for a resource to install";
            // 
            // ResourceSelector
            // 
            this.ResourceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourceSelector.FormattingEnabled = true;
            this.ResourceSelector.Location = new System.Drawing.Point(12, 12);
            this.ResourceSelector.Name = "ResourceSelector";
            this.ResourceSelector.Size = new System.Drawing.Size(310, 394);
            this.ResourceSelector.TabIndex = 2;
            this.ResourceSelector.DoubleClick += new System.EventHandler(this.ResourceSelector_DoubleClick);
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 436);
            this.Controls.Add(this.ResourceSelector);
            this.Controls.Add(this.InfoStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Downloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource Downloader";
            this.InfoStrip.ResumeLayout(false);
            this.InfoStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip InfoStrip;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.ListBox ResourceSelector;
    }
}