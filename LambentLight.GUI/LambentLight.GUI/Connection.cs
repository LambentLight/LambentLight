using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LambentLight.GUI
{
    /// <summary>
    /// Represents the last connection information of a user.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// If the connection should be automatically made on startup.
        /// This skips the Login form.
        /// </summary>
        [JsonProperty("auto")]
        public bool AutoConnect { get; set; }
        /// <summary>
        /// If LambentLight should remember the connection information.
        /// </summary>
        [JsonProperty("remember")]
        public bool Remember { get; set; }
        /// <summary>
        /// The host used for the last connection.
        /// </summary>
        [JsonProperty("host")]
        public byte[] Host { get; set; }
        /// <summary>
        /// Same as Host, but as bytes.
        /// </summary>
        [JsonIgnore]
        public string HostString
        {
            get => Encoding.UTF8.GetString(Host);
            set => Host = Encoding.UTF8.GetBytes(value);
        }
        /// <summary>
        /// The Token used for Authentication.
        /// </summary>
        [JsonProperty("token")]
        public byte[] Token { get; set; }
        /// <summary>
        /// Same as Token, but as bytes.
        /// </summary>
        [JsonIgnore]
        public string TokenString
        {
            get => Encoding.UTF8.GetString(Token);
            set => Token = Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// Writes the connection information to a file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        public void WriteToFile(string file)
        {
            // Get the values as protected byte arrays
            byte[] protectedHost = ProtectedData.Protect(Host, null, DataProtectionScope.CurrentUser);
            byte[] protectedToken = ProtectedData.Protect(Token, null, DataProtectionScope.CurrentUser);

            // And write them to the file
            Connection connection = new Connection()
            {
                AutoConnect = AutoConnect,
                Remember = Remember,
                Host = protectedHost,
                Token = protectedToken
            };
            string json = JsonConvert.SerializeObject(connection);
            File.WriteAllText(file, json);
        }

        /// <summary>
        /// Creates the Connection information from a generic dictionary.
        /// </summary>
        /// <param name="dict">The dictionary to load from.</param>
        /// <returns>A Connection with the values ready to use.</returns>
        public static Connection FromFile(string file)
        {
            // Get the contents of the file
            string contents = File.ReadAllText(file);
            Connection protectedConnection = JsonConvert.DeserializeObject<Connection>(contents);
            // Unprotect the information
            byte[] host = ProtectedData.Unprotect(protectedConnection.Host, null, DataProtectionScope.CurrentUser);
            byte[] token = ProtectedData.Unprotect(protectedConnection.Token, null, DataProtectionScope.CurrentUser);
            // Finally, return the Connection object with the information
            return new Connection()
            {
                AutoConnect = protectedConnection.AutoConnect,
                Remember = protectedConnection.Remember,
                Host = host,
                Token = token
            };
        }
    }
}
