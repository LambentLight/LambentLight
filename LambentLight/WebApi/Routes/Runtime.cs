using LambentLight.Managers.Builds;
using LambentLight.Managers.DataFolders;
using LambentLight.Managers.Runtime;
using LambentLight.WebApi.Binds;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambentLight.WebApi.Routes
{
    /// <summary>
    /// Routes for Starting, Stopping and Restarting the CFX Server.
    /// </summary>
    public class Runtime : NancyModule
    {
        #region Constructor

        public Runtime()
        {
            // Add the routes that we need
            Post("/start", async _ => await Start());
            Post("/restart", async _ => await Restart());
            Post("/stop", async _ => await Stop());
        }

        #endregion

        #region Routes

        public async Task<Response> Start()
        {
            // If the server is already running, return 409
            if (RuntimeManager.IsServerRunning)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "The CFX Server is already running." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            // Update the list of data folder
            Start data = this.Bind<Start>();

            // If the build was not specified, return 400
            if (string.IsNullOrWhiteSpace(data.Build))
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "You need to specify a CFX build to use." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            // If no data folder was specified, return 400
            if (string.IsNullOrWhiteSpace(data.Folder))
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "You need to specify a Data Folder to use." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            // Create a place to store the build
            Build foundBuild = null;
            // Iterate over the existing buiilds
            foreach (Build build in BuildManager.Builds)
            {
                // If the IDs match
                if (build.ID == data.Build)
                {
                    // Save the builds
                    foundBuild = build;
                    // And break the iterator
                    break;
                }
            }

            // If no build was found, return 404
            if (foundBuild == null)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", $"No Build with the ID of {data.Build} was found." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            // Then repeat the process but with the data folders
            DataFolder foundFolder = null;
            foreach (DataFolder folder in DataFolderManager.Folders)
            {
                if (folder.Name == data.Folder)
                {
                    foundFolder = folder;
                    break;
                }
            }

            // If no data folder was found, return a 404
            if (foundFolder == null)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", $"No Data Folder called '{data.Folder}' was found." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            // If we got here, just start the server
            await RuntimeManager.Start(foundBuild, foundFolder);
            // And lock the UI elements
            Program.Form.Invoke(new Action(() => Program.Form.Locked = true));

            // And return a 200
            Response success = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", $"The server has been started with Build {data.Build} and Data Folder '{data.Folder}'." } });
            success.ContentType = "application/json";
            success.StatusCode = HttpStatusCode.OK;
            return success;
        }

        public async Task<Response> Restart()
        {
            // If the server is not running, return a 409
            if (!RuntimeManager.IsServerRunning)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "The CFX Server is not running." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            // Otherwise, restart the server
            await RuntimeManager.Restart();

            // And return a 200
            Response success = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", $"The server was restarted." } });
            success.ContentType = "application/json";
            success.StatusCode = HttpStatusCode.OK;
            return success;
        }

        public async Task<Response> Stop()
        {
            // If the server is not running, return a 409
            if (!RuntimeManager.IsServerRunning)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "The CFX Server is not running." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            // Otherwise, stop the server
            await RuntimeManager.Stop();
            // Unlock the UI elements
            Program.Form.Invoke(new Action(() => Program.Form.Locked = false));

            // And return a 200
            Response success = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", $"The server was stopped." } });
            success.ContentType = "application/json";
            success.StatusCode = HttpStatusCode.OK;
            return success;
        }

        #endregion
    }
}
