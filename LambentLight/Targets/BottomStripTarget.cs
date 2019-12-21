using NLog;
using NLog.Targets;
using System;

namespace LambentLight.Targets
{
    [Target("BottomStrip")]
    public class BottomStripTarget : TargetWithContext
    {
        /// <summary>
        /// Sets the text of the label to our logging message.
        /// </summary>
        /// <param name="LogEvent">The log information.</param>
        protected override void Write(LogEventInfo LogEvent)
        {
            // If there is no form, return
            if (Program.Form == null)
            {
                return;
            }

            // Get the handle to make sure that is available
            IntPtr pointer = Program.Form.Handle;
            // And change the text via Invoke
            Program.Form.Invoke(new Action(() => Program.Form.BottomToolStripStatusLabel.Text = Layout.Render(LogEvent)));
        }
    }
}
