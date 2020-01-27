using LambentLight.Managers.DataFolders;
using LambentLight.Managers.Runtime;
using Nancy;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambentLight.WebApi.Routes
{
    /// <summary>
    /// Rroutes for starting 
    /// </summary>
    public class DataFolders : NancyModule
    {
        #region Constructor

        public DataFolders()
        {
            // Add the routes that we need
            Get("/datafolder/installed", _ => Installed());
            Get("/datafolder/{folder}/installed", param => Installed(param));
        }

        #endregion

        #region Routes

        public Response Installed(dynamic param = null)
        {
            // If there are no parameters and the server is not running, return a 409
            if (param == null && !RuntimeManager.IsServerRunning)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "The CFX Server is not running." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            // Create a place to store the data folder
            DataFolder folder = null;
            // If we don't have parameters, use the data folder of the server that is running
            if (param == null)
            {
                folder = RuntimeManager.Folder;
            }
            // Otherwise
            else
            {
                // Iterate over the data folders
                foreach (DataFolder dataFolder in DataFolderManager.Folders)
                {
                    // If the names match
                    if (dataFolder.Name == param.folder)
                    {
                        // Save it and break the iterator
                        folder = dataFolder;
                        break;
                    }
                }

                // If we finished the iterator and no file matches, return a 404
                if (folder == null)
                {
                    Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", $"No data folder with the name of '{param.folder}' could be found." } });
                    response.ContentType = "application/json";
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
            }

            // If is running, make a list with just the names of the resources
            List<string> installed = new List<string>();
            foreach (InstalledResource resource in folder.Resources)
            {
                installed.Add(resource.Name);
            }

            // And return the list of resources
            Response list = JsonConvert.SerializeObject(installed);
            list.ContentType = "application/json";
            list.StatusCode = HttpStatusCode.OK;
            return list;
        }
        
        #endregion
    }
}
