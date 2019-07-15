using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LambentLight
{
    public static class Extensions
    {
        /// <summary>
        /// Appends a line into the TextBox.
        /// </summary>
        /// <param name="Line">The text to add at the end.</param>
        public static void AppendLine(this TextBoxBase Box, string Line)
        {
            Box.AppendText(Line);
            Box.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Cheks if the current process is running.
        /// </summary>
        /// <returns>True if the process is running, false otherwise.</returns>
        public static bool IsRunning(this Process Check)
        {
            try
            {
                Process.GetProcessById(Check.Id);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
    }
}
