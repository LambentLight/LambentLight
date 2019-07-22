using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambentLight
{
    /// <summary>
    /// Identifies the type of a resource.
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// A simple script.
        /// </summary>
        Script = 0,
        /// <summary>
        /// A completely different gamemode.
        /// </summary>
        GameMode = 1,
        /// <summary>
        /// A new loading screen.
        /// </summary>
        LoadingScreen = 2
    }

    /// <summary>
    /// The type of compression used for the 
    /// </summary>
    public enum CompressionType
    {
        /// <summary>
        /// The classic ZIP file.
        /// </summary>
        Zip = 0,
        /// <summary>
        /// 7zip or Seven ZIP.
        /// </summary>
        SevenZip = 1,
        /// <summary>
        /// RAR from WinRAR.
        /// </summary>
        Rar = 2
    }

    /// <summary>
    /// Class that contains the informatioon of a specific downloadable resource.
    /// </summary>
    public class Resource
    {
    }

    /// <summary>
    /// Class that manages the resources of the installer.
    /// </summary>
    public static class ResourceManager
    {
        /// <summary>
        /// All of the resources that are available for installing.
        /// </summary>
        public static List<Resource> Resources = new List<Resource>();
    }
}
