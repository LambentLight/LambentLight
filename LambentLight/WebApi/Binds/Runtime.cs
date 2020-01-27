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
}
