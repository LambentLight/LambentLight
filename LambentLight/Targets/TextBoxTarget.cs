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
            // If there is no form, return
            if (Program.Form == null)
            {
                return;
            }

            // If the form does not has a handle
            if (!Program.Form.IsHandleCreated)
            {
                // Get the handle with or without invoking
                if (Program.Form.InvokeRequired)
                {
                    Program.Form.Invoke(new Action(() => { IntPtr pointer = Program.Form.Handle; }));
                }
                else
                {
                    // Get the handle to make sure that is available
                    IntPtr pointer = Program.Form.Handle;
                }
            }

            // And add the text via Invoke
            Program.Form.Invoke(new Action(() => Program.Form.ConsoleTextBox.AppendText(Layout.Render(LogEvent) + Environment.NewLine)));
        }
    }
}
