using LambentLight.GUI.Api;
using System;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class FormManager : Form
    {
        #region Field

        private readonly Client client = null;

        #endregion

        #region Constructor

        public FormManager(string host, string token)
        {
            InitializeComponent();

            Text = Text + " " + host;
            client = new Client(host, token);
        }

        #endregion

        #region Events

        private async void FormManager_Load(object sender, EventArgs e)
        {
            foreach (DataFolder folder in await client.GetDataFolders())
            {
                DataFolderComboBox.Items.Add(folder);
            }
            if (DataFolderComboBox.Items.Count > 0)
            {
                DataFolderComboBox.SelectedIndex = 0;
            }
        }

        #endregion
    }
}
