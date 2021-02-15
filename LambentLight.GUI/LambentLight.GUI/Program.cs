using System;
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

            // Show the login window
            FormLogin login = new FormLogin();
            login.ShowDialog();

            // If everything went well, exit with code 0
            return 0;
        }
    }
}
