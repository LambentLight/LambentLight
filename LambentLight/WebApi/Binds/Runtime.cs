namespace LambentLight.WebApi.Binds
{
    /// <summary>
    /// Information sent when trying to start the build.
    /// </summary>
    public class Start
    {
        public string Build { get; set; }
        public string Folder { get; set; }
    }

    /// <summary>
    /// Information send when trying to execute a command.
    /// </summary>
    public class Commands
    {
        public string Command { get; set; }
    }
}
