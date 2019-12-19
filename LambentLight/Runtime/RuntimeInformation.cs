using LambentLight.Managers;
using System.Diagnostics;

namespace LambentLight.Runtime
{
    /// <summary>
    /// Class for storing some values for the launch of the server.
    /// </summary>
    public class RuntimeInformation
    {
        /// <summary>
        /// The FiveM build used to launch the process.
        /// </summary>
        public Build Build { get; set; }
        /// <summary>
        /// The Data Folder with the server information.
        /// </summary>
        public DataFolder Folder { get; set; }
        /// <summary>
        /// The server process.
        /// </summary>
        public Process Process { get; set; }
    }
}
