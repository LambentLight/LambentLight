using System.Text.RegularExpressions;

namespace ServerManager
{
    /// <summary>
    /// RegEx expressions.
    /// </summary>
    public static class Expressions
    {
        /// <summary>
        /// Expression used to match the RCON Password.
        /// </summary>
        public static Regex RCONPassword = new Regex("rcon_password\\s*[\\s\"']([a-zA-Z0-9]*)[\\s\"']");
        /// <summary>
        /// Expression used to match the UDP port.
        /// </summary>
        public static Regex PortUDP = new Regex("endpoint_add_udp\\s*[\\s\"'][0-9]*.[0-9]*.[0-9]*.[0-9]*:([0-9]*)[\\s\"']");
    }
}
