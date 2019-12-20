using Newtonsoft.Json;
using System;

namespace LambentLight.Builds
{
    /// <summary>
    /// A JSON converter for reading CFX builds from a list of Identifiers.
    /// </summary>
    public class BuildConverter : JsonConverter<Build>
    {
        public override Build ReadJson(JsonReader reader, Type objectType, Build existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Get the identifier as a string
            string value = (string)reader.Value;
            // Create the build object with the identifier
            Build build = new Build(value);
            // And return it
            return build;
        }

        public override void WriteJson(JsonWriter writer, Build value, JsonSerializer serializer)
        {
            // We are only going to read, so disable the writing by raising an exception
            throw new NotImplementedException();
        }
    }
}
