using LambentLight.Extensions;
using LambentLight.Managers.DataFolders;
using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LambentLight.WebApi.Routes
{
    /// <summary>
    /// Routes for managing the Data Folders.
    /// </summary>
    public class DataFolders : NancyModule
    {
        #region Constructor

        public DataFolders()
        {
            // Add the routes that we need
            Get("/datafolders", param => DataFolderGet());
            Post("/datafolders", param => DataFolderPost());
            Get("/datafolders/{folder}/installed", param => Installed(FindFolder(param)));
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

        public Response DataFolderGet()
        {
            // If the request is not authenticated, return
            if (!Tools.IsAuthCorrect(Request, out Response error))
            {
                return error;
            }

            // Make a list with the names of the data folders
            List<string> names = new List<string>();
            foreach (DataFolder folder in DataFolderManager.Folders)
            {
                names.Add(folder.Name);
            }

            // And return it
            Response list = JsonConvert.SerializeObject(names);
            list.ContentType = "application/json";
            list.StatusCode = HttpStatusCode.OK;
            return list;
        }
        public Response DataFolderPost()
        {
            // If the request is not authenticated, return
            if (!Tools.IsAuthCorrect(Request, out Response error))
            {
                return error;
            }

            // Just update the list of data folders
            DataFolderManager.Refresh();
            // And the respective UI element
            Program.Form.Invoke(new Action(() => Program.Form.DataFolderComboBox.Fill(DataFolderManager.Folders, true)));

            // And return a 204
            Response list = new Response
            {
                ContentType = "application/json",
                StatusCode = HttpStatusCode.NoContent
            };
            return list;
        }

        public Response Installed(DataFolder folder)
        {
            // If the request is not authenticated, return
            if (!Tools.IsAuthCorrect(Request, out Response error))
            {
                return error;
            }

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
