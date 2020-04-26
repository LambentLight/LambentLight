using Newtonsoft.Json;
using System.IO;

namespace LambentLight.Builds
{
    /// <summary>
    /// The Target Operating System for a build.
    /// </summary>
    public enum TargetOS
    {
        Windows = 0,
        Linux = 1
    }

    /// <summary>
    /// Object that stores the information of a build.
    /// </summary>
    public class Build
    {
        /// <summary>
        /// Temporary location for the download of files.
        /// </summary>
        private readonly string tempPath = Path.Combine(Path.GetTempPath(), "LambentLight");

        /// <summary>
        /// The name or identifier of the build.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The Download URL of the build.
        /// </summary>
        [JsonProperty("download")]
        public string DownloadURL { get; set; }
        /// <summary>
        /// Target Operating System for the build.
        /// </summary>
        [JsonProperty("target")]
        public TargetOS Target { get; set; }
        /// <summary>
        /// The location of the build in the drive.
        /// </summary>
        [JsonIgnore]
        public string Folder => Path.Combine("builds", "windows", Name);
        /// <summary>
        /// Path of the executable of the Build.
        /// </summary>
        [JsonIgnore]
        public string Executable => Path.Combine(Folder, "FXServer.exe");
        /// <summary>
        /// If this build is installed or not.
        /// </summary>
        [JsonIgnore]
        public bool IsInstalled => File.Exists(Executable);
    }
}
