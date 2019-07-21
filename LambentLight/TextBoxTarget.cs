using NLog;
using NLog.Targets;
using System;
using System.Windows.Forms;

namespace LambentLight
{
    [Target("TextBox")]
    public class TextBoxTarget : TargetWithContext
    {
        /// <summary>
        /// The TextBox that is going to be used as the output.
        /// </summary>
        public TextBox Box { get; set; }

        /// <summary>
        /// Appends the help message into the TextBox.
        /// </summary>
        /// <param name="LogEvent">The log information.</param>
        protected override void Write(LogEventInfo LogEvent)
        {
            Box.Text += Layout.Render(LogEvent) + Environment.NewLine;
        }
    }
}
