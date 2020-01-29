using LambentLight.Extensions;
using LambentLight.Managers.Builds;
using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambentLight.WebApi.Routes
{
    /// <summary>
    /// Routes for managing the CFX Builds.
    /// </summary>
    public class Builds : NancyModule
    {
        #region Constructor

        public Builds()
        {
            // Add the routes that we need
            Get("/builds", _ => BuildGet());
            Post("/builds", async _ => await BuildPost());
        }

        #endregion

        #region Routes

        public Response BuildGet()
        {
            // If the request is not authenticated, return
            if (!Tools.IsAuthCorrect(Request, out Response error))
            {
                return error;
            }

            // And return it
            Response list = JsonConvert.SerializeObject(BuildManager.Builds);
            list.ContentType = "application/json";
            list.StatusCode = HttpStatusCode.OK;
            return list;
        }
        public async Task<Response> BuildPost()
        {
            // If the request is not authenticated, return
            if (!Tools.IsAuthCorrect(Request, out Response error))
            {
                return error;
            }

            // Just update the list of builds
            await BuildManager.Refresh();
            // And the respective UI element
            Program.Form.Invoke(new Action(() => Program.Form.BuildsListBox.Fill(BuildManager.Builds, true)));

            // And return a 204
            Response list = new Response
            {
                StatusCode = HttpStatusCode.NoContent
            };
            return list;
        }

        #endregion
    }
}
