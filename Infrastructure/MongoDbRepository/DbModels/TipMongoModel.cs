using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.MongoDbRepository.DbModels
{
    public class TipMongoModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid PlatformId { get; set; }
        public string Description { get; set; }
        public string Snippet { get; set; }
    }
}