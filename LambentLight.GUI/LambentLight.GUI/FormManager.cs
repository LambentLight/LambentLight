using LambentLight.GUI.API;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambentLight.GUI
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

        #region Tools

        private async Task UpdateFolders()
        {
            await client.UpdateFolders();
            DataFolderComboBox.Items.Clear();
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

        #region Events - Loading

        private async void FormManager_Load(object sender, EventArgs e)
        {
            await UpdateFolders();
        }

        #endregion

        #region Events - Data Folder

        private void DataFolderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool check = DataFolderComboBox.SelectedItem != null;
            DataFolderBrowseButton.Enabled = check;
            DataFolderDeleteButton.Enabled = check;
        }

        private void DataFolderBrowseButton_Click(object sender, EventArgs e)
        {
            new FormResources((DataFolder)DataFolderComboBox.SelectedItem).ShowDialog();
        }

        private async void DataFolderDeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to remove the Data Folder?\nEVERYTHING WILL BE LOST!", "Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await ((DataFolder)DataFolderComboBox.SelectedItem).Delete();
                await UpdateFolders();
            }
        }

        #endregion
    }
}
