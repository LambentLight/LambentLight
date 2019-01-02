using System;
using System.Windows.Forms;

namespace ServerManager
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
    }
}
