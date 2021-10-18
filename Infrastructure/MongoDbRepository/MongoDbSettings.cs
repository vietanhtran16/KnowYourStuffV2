namespace Infrastructure.MongoDbRepository
{
    public class MongoDbSettings
    {
        public string PlatformsCollectionName { get; set; }
        public string TipsCollectionName { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}