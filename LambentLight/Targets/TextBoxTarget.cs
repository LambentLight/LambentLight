using NLog;
using NLog.Targets;
using System;

namespace LambentLight.Targets
{
    [Target("TextBox")]
    public class TextBoxTarget : TargetWithContext
    {
        /// <summary>
        /// Appends the help message into the TextBox.
        /// </summary>
        /// <param name="LogEvent">The log information.</param>
        protected override void Write(LogEventInfo LogEvent)
        {
            Program.Form.Invoke(new Action(() => Program.Form.LogsTextBox.AppendText(Layout.Render(LogEvent) + Environment.NewLine)));
        }
    }
}
