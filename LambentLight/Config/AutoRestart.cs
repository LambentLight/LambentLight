using Newtonsoft.Json;
using System;

namespace LambentLight.Config
{
    /// <summary>
    /// The configuration of the Auto Restart system.
    /// </summary>
    public class AutoRestart
    {
        [JsonProperty("cron_enabled")]
        public bool Cron { get; set; } = false;
        [JsonProperty("cron_time")]
        public TimeSpan CronTime { get; set; } = TimeSpan.Zero;
        [JsonProperty("daily_enabled")]
        public bool Daily { get; set; } = false;
        [JsonProperty("daily_time")]
        public TimeSpan DailyTime { get; set; } = TimeSpan.Zero;
    }
}
