﻿using LambentLight.Extensions;
using LambentLight.Managers.Builds;
using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
            Get("/build", _ => BuildGet());
            Post("/build", _ => BuildPost());
        }

        #endregion

        #region Routes

        public Response BuildGet()
        {
            // Make a dictionary with the IDs of the builds and if is installed or not
            Dictionary<string, bool> names = new Dictionary<string, bool>();
            foreach (Build folder in BuildManager.Builds)
            {
                names.Add(folder.ID, folder.IsExecutablePresent);
            }

            // And return it
            Response list = JsonConvert.SerializeObject(names);
            list.ContentType = "application/json";
            list.StatusCode = HttpStatusCode.OK;
            return list;
        }
        public Response BuildPost()
        {
            // Just update the list of builds
            BuildManager.Refresh();
            // And the respective UI element
            Program.Form.Invoke(new Action(() => Program.Form.BuildsListBox.Fill(BuildManager.Builds, true)));

            // And return a 204
            Response list = new Response
            {
                ContentType = "application/json",
                StatusCode = HttpStatusCode.NoContent
            };
            return list;
        }

        #endregion
    }
}