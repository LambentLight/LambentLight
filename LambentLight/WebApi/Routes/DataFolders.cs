using LambentLight.Managers.DataFolders;
using Nancy;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            Get("/datafolder/{folder}/installed", param => Installed(FindFolder(param)));
        }

        #endregion

        #region Tools

        public DataFolder FindFolder(dynamic param)
        {
            // Iterate over the data folders
            foreach (DataFolder dataFolder in DataFolderManager.Folders)
            {
                // If the names match
                if (dataFolder.Name == param.folder)
                {
                    // Return it
                    return dataFolder;
                }
            }

            // If we got here, the folder was not found so return null
            return null;
        }

        #endregion

        #region Routes

        public Response Installed(DataFolder folder)
        {
            // If there is no data folder, return a 404
            if (folder == null)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "No data folder was found." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
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
