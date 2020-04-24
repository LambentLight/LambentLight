using System;
using System.Windows.Forms;

namespace LambentLight
{
    /// <summary>
    /// Class that stores the basics of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The Landing Screen for the program.
        /// </summary>
        public static FormLanding Landing { get; private set; } = null;

        /// <summary>
        /// Main Entry Point of the application.
        /// </summary>
        /// <returns>The exit code of the app.</returns>
        [STAThread]
        public static int Main()
        {
            // Enable the Vista+ visual styles and GDI+
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Create the forms
            Landing = new FormLanding();
            // And run the app with the default form
            Application.Run(Landing);
            return 0;
        }
    }
}
