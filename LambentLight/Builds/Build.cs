using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

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

        /// <summary>
        /// Downloads the build, even if is already present.
        /// </summary>
        public async Task<bool> Download()
        {
            // Download the file
            FormProgress download = FormProgress.Download(DownloadURL, tempPath, $"{Name}.zip");
            download.ShowDialog();

            // If we failed, return
            if (!download.Completed)
            {
                return false;
            }

            // If the folder with the build exists, delete it
            if (Directory.Exists(Folder))
            {
                Directory.Delete(Folder, true);
            }
            // And create it again
            Directory.CreateDirectory(Folder);

            // Once everything is ready, start the extraction
            FormProgress extraction = FormProgress.Extract(Path.Combine(tempPath, $"{Name}.zip"), Folder);
            extraction.ShowDialog();

            // If we failed, say so and return;
            if (!extraction.Completed)
            {
                return false;
            }
            // Otherwise, show sucess
            return true;
        }
        /// <summary>
        /// Returns the Name or Identifier of the build.
        /// </summary>
        public override string ToString() => Name;
    }
}
