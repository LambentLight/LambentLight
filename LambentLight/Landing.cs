using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class Landing : Form
    {
        public Landing()
        {
            InitializeComponent();
            LoggingConfiguration NewConfig = new LoggingConfiguration();
            NewConfig.AddRule(LogLevel.Info, LogLevel.Fatal, new TextBoxTarget() { Box = LogBox, Layout = "[${date}] [${level}] [${logger}] ${message}" });
            LogManager.Configuration = NewConfig;
            BuildManager.Fill(BuildsBox);
            DataFolderManager.Fill(DataBox);
        }

        private async void StartItem_Click(object sender, EventArgs e)
        {
            await ServerManager.Start((Build)BuildsBox.SelectedItem, (DataFolder)DataBox.SelectedItem);
        }
    }
}
