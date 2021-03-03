using System;
using System.IO;
using System.Windows.Forms;

namespace LambentLight.GUI
{
    /// <summary>
    /// Entry Point of the Application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main function executed when the application is started.
        /// </summary>
        /// <returns>The exit code of the application.</returns>
        [STAThread]
        public static int Main()
        {
            // Use the Windows theme and switch to GDI+
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Connection connection = null;

            // If the file with the last connection is present, load it and try to use it
            string last = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LambentLight", "LastConnection.json");
            if (File.Exists(last))
            {
                connection = Connection.FromFile(last);
            }

            // Time to show the Login window
            FormLogin login = new FormLogin();
            // if the connection exists, load the information
            if (connection != null)
            {
                login.AutoCheckBox.Checked = connection.AutoConnect;
                login.IPTextBox.Text = connection.HostString;
                login.TokenTextBox.Text = connection.TokenString;
            }
            // If the connection does not exists or is set to not auto connect
            if (Control.ModifierKeys == Keys.Shift || connection == null || (connection != null && !connection.AutoConnect))
            {
                // Open the window and exit if it was closed without pressing Connect
                if (login.ShowDialog() != DialogResult.OK)
                {
                    return 2;
                }
                // Otherwise, create a connection with the field information
                connection = new Connection()
                {
                    AutoConnect = login.AutoCheckBox.Checked,
                    Remember = login.RememberCheckBox.Checked,
                    HostString = login.IPTextBox.Text,
                    TokenString = login.TokenTextBox.Text
                };
            }

            // If the user enabled the option to remember the info, save it
            if (connection.Remember)
            {
                if (!File.Exists(last))  // Because Microsoft
                {
                    Directory.CreateDirectory(last);
                    Directory.Delete(last);
                }
                connection.WriteToFile(last);
            }
            // Otherwise, delete it if is present
            else if (!connection.Remember && File.Exists(last))
            {
                File.Delete(last);
            }

            // Otherwise, open the manager with the connection
            FormManager manager = new FormManager(connection.HostString, connection.TokenString);
            manager.ShowDialog();

            // If everything went well, exit with code 0
            return 0;
        }
    }
}
