using System;
using KnowYourStuffCore.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.MongoDbRepository.DbModels
{
    [BsonIgnoreExtraElements]
    public class PlatformMongoModel
    {
        [BsonId]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public Platform ToPlatform()
        {
            return new Platform(Id, Name, Description);
        }
    }
}