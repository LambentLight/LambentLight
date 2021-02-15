using Flurl.Http;
using System.Threading.Tasks;

namespace LambentLight.GUI.Api
{
    /// <summary>
    /// Main Client for managing the LambentLight Server.
    /// </summary>
    public class Client
    {
        #region Fields

        private readonly FlurlClient client = new FlurlClient();

        #endregion

        #region Constructor

        public Client(string host, string token)
        {
            client.BaseUrl = $"http://{host}";
            client.Headers.AddOrReplace("Authorization", $"Bearer {token}");
            client.Headers.AddOrReplace("User-Agent", "LambentLight GUI (+https://github.com/LambentLight)");
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the server instance is valid or not.
        /// </summary>
        /// <returns><see langword="true"/> if is valid, <see langword="false"/> otherwise.</returns>
        public async Task<bool> IsValid()
        {
            try
            {
                ServerInfo info = await client.Request("/").GetJsonAsync<ServerInfo>();
                if (info.ProgramName == "LambentLight")
                {
                    return true;
                }
                return false;
            }
            catch (FlurlHttpException)  // Unable to connect to the remote server
            {
                return false;
            }
        }

        #endregion
    }
}
