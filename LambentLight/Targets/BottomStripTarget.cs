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
            Program.Form.Invoke(new Action(() => Program.Form.BottomStripLabel.Text = Layout.Render(LogEvent)));
        }
    }
}
