using Nancy;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LambentLight.WebApi
{
    /// <summary>
    /// Classes for dealing with the Web API.
    /// </summary>
    public static class Tools
    {
        public static bool IsAuthCorrect(Request request, out Response response)
        {
            // If there is no token, always say that is correct
            if (string.IsNullOrWhiteSpace(Program.Config.API.Token))
            {
                response = null;
                return true;
            }

            // If there is no Authorization header, set the correct response and return
            if (string.IsNullOrWhiteSpace(request.Headers.Authorization))
            {
                response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "You need to specify a bearer token. See PLACEHOLDER for more information." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Unauthorized;
                return false;
            }

            // If the Authorization does not starts with bearer and a space, set the correct response and return
            if (!request.Headers.Authorization.ToLowerInvariant().StartsWith("bearer "))
            {
                response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "You need to specify a bearer token. See PLACEHOLDER for more information." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Unauthorized;
                return false;
            }

            // Otherwise, split it and get the token
            string token = request.Headers.Authorization.Split(' ')[1];
            // If the token does not matches, set the correct response and return
            if (token != Program.Config.API.Token)
            {
                response = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "message", "The token is not valid. See PLACEHOLDER for more information." } });
                response.ContentType = "application/json";
                response.StatusCode = HttpStatusCode.Unauthorized;
                return false;
            }

            // If it does, return true and set the response to null
            response = null;
            return true;
        }
    }
}
