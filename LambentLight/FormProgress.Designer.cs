namespace LambentLight
{
    partial class FormProgress
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
            this.InitProgressBar = new System.Windows.Forms.ProgressBar();
            this.LabelInit = new System.Windows.Forms.Label();
            this.LabelTask = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InitProgressBar
            // 
            this.InitProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InitProgressBar.Location = new System.Drawing.Point(12, 56);
            this.InitProgressBar.Maximum = 2;
            this.InitProgressBar.Name = "InitProgressBar";
            this.InitProgressBar.Size = new System.Drawing.Size(285, 23);
            this.InitProgressBar.Step = 1;
            this.InitProgressBar.TabIndex = 0;
            // 
            // LabelInit
            // 
            this.LabelInit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelInit.Location = new System.Drawing.Point(12, 9);
            this.LabelInit.Name = "LabelInit";
            this.LabelInit.Size = new System.Drawing.Size(285, 16);
            this.LabelInit.TabIndex = 1;
            this.LabelInit.Text = "Please wait...";
            this.LabelInit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTask
            // 
            this.LabelTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelTask.Location = new System.Drawing.Point(12, 25);
            this.LabelTask.Name = "LabelTask";
            this.LabelTask.Size = new System.Drawing.Size(285, 16);
            this.LabelTask.TabIndex = 2;
            this.LabelTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 91);
            this.Controls.Add(this.LabelTask);
            this.Controls.Add(this.LabelInit);
            this.Controls.Add(this.InitProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInit_FormClosing);
            this.Shown += new System.EventHandler(this.FormInit_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar InitProgressBar;
        private System.Windows.Forms.Label LabelInit;
        private System.Windows.Forms.Label LabelTask;
    }
}