using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.MongoDbRepository.DbModels;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;
using MongoDB.Driver;

namespace Infrastructure.MongoDbRepository.DataAccess
{
    public class MongoPlatformRepository : IPlatformRepository
    {
        private readonly IMongoCollection<PlatformMongoModel> _platforms;
        public MongoPlatformRepository(MongoDbSettings dbSettings)
        {
            var connectionString = $"mongodb://{dbSettings.User}:{dbSettings.Password}@{dbSettings.Host}:{dbSettings.Port}";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _platforms = database.GetCollection<PlatformMongoModel>("Platforms");
        }
        public async Task<Platform> CreatePlatform(Platform newPlatform)
        {
             await _platforms.InsertOneAsync(new PlatformMongoModel()
                {Id = newPlatform.Id, Name = newPlatform.Name, Description = newPlatform.Description});
             return newPlatform;
        }

        public async Task<IEnumerable<Platform>> GetPlatforms()
        {
            var platforms = await _platforms.Find(platform => true).ToListAsync();
            return platforms.Select(platform => new Platform(platform.Id, platform.Name, platform.Description));
        }

        public async Task<Platform> GetPlatform(Guid id)
        {
            var platform = await _platforms.Find(Builders<PlatformMongoModel>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return platform?.ToPlatform();
        }

        public async Task<Platform> GetPlatform(string name)
        {
            var platform = await _platforms.Find(Builders<PlatformMongoModel>.Filter.Eq(nameof(PlatformMongoModel.Name), name))
                .FirstOrDefaultAsync();
            return platform?.ToPlatform();
        }
    }
}