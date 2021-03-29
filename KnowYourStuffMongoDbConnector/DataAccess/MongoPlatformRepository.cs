using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;
using KnowYourStuffMongoDbConnector.DbModels;
using KnowYourStuffWebApi;
using MongoDB.Driver;

namespace KnowYourStuffMongoDbConnector.DataAccess
{
    public class MongoPlatformRepository : IPlatformRepository
    {
        private readonly IMongoCollection<PlatformMongoModel> _platforms;
        public MongoPlatformRepository(IMongoDbSettings dbSettings)
        {
            var connectionString = $"mongodb://{dbSettings.User}:{dbSettings.Password}@{dbSettings.Host}:{dbSettings.Port}";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _platforms = database.GetCollection<PlatformMongoModel>(dbSettings.PlatformsCollectionName);
        }
        public async Task<Platform> CreatePlatform(Platform newPlatform)
        {
             await _platforms.InsertOneAsync(new PlatformMongoModel()
                {Id = newPlatform.Id, Name = newPlatform.Name, Description = newPlatform.Description});
             return newPlatform;
        }

        public async Task<List<Platform>> GetPlatforms()
        {
            var platforms = await _platforms.Find(platform => true).ToListAsync();
            return platforms.Select(platform => new Platform(platform.Id, platform.Name, platform.Description)).ToList();
        }
    }
}