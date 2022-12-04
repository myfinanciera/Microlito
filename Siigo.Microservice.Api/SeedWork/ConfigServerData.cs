namespace Siigo.Microservice.Api.SeedWork
{
    public sealed class ConfigServerData
    {
        public string Data { get; set; }
        public Info Info { get; set; }
    }
    public sealed class Info
    {
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
