using LambentLight.Managers.Builds;
using LambentLight.Managers.DataFolders;
using LambentLight.Managers.Runtime;
using Nancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LambentLight.WebApi.Routes
{
    /// <summary>
    /// Class that saves the Basic Information of LambentLight.
    /// </summary>
    public class BasicInfo
    {
        [JsonProperty("version")]
        public string Version => Program.Version;
        [JsonProperty("is_running")]
        public bool IsRunning => RuntimeManager.IsServerRunning;
        [JsonProperty("build")]
        public Build Build => RuntimeManager.Build;
        [JsonProperty("folder")]
        public DataFolder Folder => RuntimeManager.Folder;
    }

    /// <summary>
    /// Single Endpoint that shows the basics of the app.
    /// </summary>
    public class Basics : NancyModule
    {
        #region Constructor

        public Basics()
        {
            // Add the routes that we need
            Get("/", _ => BasicsGet());
        }

        #endregion

        #region Routes

        public Response BasicsGet()
        {
            // If the request is not authenticated, return
            if (!Tools.IsAuthCorrect(Request, out Response error))
            {
                return error;
            }

            // And return it
            Response list = JsonConvert.SerializeObject(new BasicInfo());
            list.ContentType = "application/json";
            list.StatusCode = HttpStatusCode.OK;
            return list;
        }

        #endregion
    }
}
