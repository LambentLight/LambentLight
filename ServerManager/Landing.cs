using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ServerManager
{
    public partial class Landing : Form
    {
        public Landing()
        {
            // Initialize the UI
            InitializeComponent();
            // And refresh the list of server builds
            RefreshServerBuilds();
        }

        private void RefreshServerBuilds()
        {
            // Clear the list of items
            BuildList.Items.Clear();
            // Create a new web parser
            HtmlWeb Web = new HtmlWeb();
            // Get the document from the FiveM build list
            HtmlAgilityPack.HtmlDocument Doc = Web.Load("https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/");
            // Create a list of versions from the links without the "/" at the end
            List<string> Versions = Doc.DocumentNode.SelectNodes("//a").Select(X => X.InnerText.TrimEnd('/')).ToList();

            // Iterate over the versions that we got without the "Previous Directory" button or "Revoked" folder
            foreach (string Version in Versions.Where(X => X != ".." && X != "revoked"))
            {
                // And add that version into the ComboBox
                BuildList.Items.Add(Version);
            }

            // Finally, restore the last build used
            RestoreLastBuildUsed();
        }

        private void RestoreLastBuildUsed()
        {
            // If the last used build is not null or a white space and the item exists
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastBuild) && BuildList.FindStringExact(Properties.Settings.Default.LastBuild) != -1)
            {
                // Get the number of the index and set it as selected
                BuildList.SelectedIndex = BuildList.FindStringExact(Properties.Settings.Default.LastBuild);
            }
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            // Create an instance of the Settings window
            Settings SettingsWindow = new Settings();
            // And show it as a dialog (so the user is unable to launch a server)
            SettingsWindow.ShowDialog();
        }

        private void RefreshBuilds_Click(object sender, EventArgs e)
        {
            // Self explanatory
            RefreshServerBuilds();
        }

        private void BuildList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Store the last used server build if is not empty or a whitespace
            if (!string.IsNullOrWhiteSpace(BuildList.SelectedItem.ToString()))
            {
                Properties.Settings.Default.LastBuild = BuildList.SelectedItem.ToString();
            }
        }
    }
}
