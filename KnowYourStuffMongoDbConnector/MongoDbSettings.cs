namespace KnowYourStuffWebApi
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string PlatformsCollectionName { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
    
    public interface IMongoDbSettings
    {
        string PlatformsCollectionName { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string DatabaseName { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
}