using LambentLight.GUI.API;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LambentLight.GUI
{
    /// <summary>
    /// Manages the resources of a specific data folder.
    /// </summary>
    public partial class FormResources : Form
    {
        #region Fields

        private readonly DataFolder folder;

        #endregion

        #region Constructor

        public FormResources(DataFolder folder)
        {
            InitializeComponent();
            this.folder = folder;
            Text = Text + " " + folder.Name;
        }

        #endregion

        #region Events

        private async void FormResources_Load(object sender, EventArgs e)
        {
            ResourcesListBox.Items.Clear();
            foreach (InstalledResource resource in await folder.GetResources())
            {
                ResourcesListBox.Items.Add(resource);
            }
            if (ResourcesListBox.Items.Count > 0)
            {
                ResourcesListBox.SelectedIndex = 0;
            }
        }

        #endregion
    }
}
