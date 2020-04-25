using Serilog;
using System;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class FormLanding : Form
    {
        public FormLanding()
        {
            InitializeComponent();
        }

        private void FormLanding_Shown(object sender, EventArgs e)
        {
            Log.Debug("Landing Form was shown to the user");
            new FormInit().ShowDialog();
        }
    }
}
