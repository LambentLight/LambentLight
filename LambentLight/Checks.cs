using System;

namespace LambentLight
{
    /// <summary>
    /// Class with OS checks.
    /// </summary>
    public static class Checks
    {
        /// <summary>
        /// If the program is running on Windows.
        /// </summary>
        public static readonly bool IsWindows = Environment.OSVersion.Platform == PlatformID.Win32NT;
        /// <summary>
        /// If the program is running on macOS.
        /// </summary>
        public static readonly bool IsMacOS = Environment.OSVersion.Platform == PlatformID.MacOSX;
        /// <summary>
        /// If the program is running on Linux.
        /// </summary>
        public static readonly bool IsLinux = Environment.OSVersion.Platform == PlatformID.Unix || (int)Environment.OSVersion.Platform == 128;
    }
}
