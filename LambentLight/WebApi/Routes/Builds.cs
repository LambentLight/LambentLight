using LambentLight.Managers.Builds;
using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Get("/build", param => Build());
        }

        #endregion

        #region Routes

        public Response Build()
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

        #endregion
    }
}
