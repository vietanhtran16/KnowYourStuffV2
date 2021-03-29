using System;
using MongoDB.Bson.Serialization.Attributes;

namespace KnowYourStuffMongoDbConnector.DbModels
{
    public class PlatformMongoModel
    {
        [BsonId]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}