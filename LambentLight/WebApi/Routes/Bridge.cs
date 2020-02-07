using LambentLight.Managers.Runtime;
using Nancy;
using Newtonsoft.Json;
using NLog;
using System.Collections.Generic;

namespace LambentLight.WebApi.Routes
{
    /// <summary>
    /// Endpoints for receiving calls from LambentLight Bridge.
    /// </summary>
    public class Bridge : NancyModule
    {
        #region Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor

        public Bridge()
        {
            // Just add the endpoints
            Post("/bridge/available", _ => AvailablePost());
            Post("/bridge/serverempty", _ => EmptyPost());
        }

        #endregion

        #region Routes

        public Response AvailablePost()
        {
            // If the request is not authenticated, return
            if (!Tools.IsAuthCorrect(Request, out Response error))
            {
                return error;
            }

            // If the server is not running, return a 409 Conflict
            if (!RuntimeManager.IsServerRunning)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "The server is not running." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            // Save that the bridge is available
            RuntimeManager.IsBridgeAvailable = true;

            // And return a 204 No Content
            Response success = new Response
            {
                StatusCode = HttpStatusCode.NoContent
            };
            return success;
        }

        public Response EmptyPost()
        {
            // If the request is not authenticated, return
            if (!Tools.IsAuthCorrect(Request, out Response error))
            {
                return error;
            }

            // If the server is not running, return a 409 Conflict
            if (!RuntimeManager.IsShutdownInProgress)
            {
                Response response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "The server is not shutting down." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            // Save that the server is already empty
            RuntimeManager.IsServerEmpty = true;
            // And log it
            Logger.Info("Bridge says that the server is empty");

            // Otherwise, return a 204 No Content
            Response success = new Response
            {
                StatusCode = HttpStatusCode.NoContent
            };
            return success;
        }

        #endregion
    }
}
