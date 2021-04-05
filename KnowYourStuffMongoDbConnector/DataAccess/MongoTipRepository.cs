using System.Threading.Tasks;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;
using KnowYourStuffMongoDbConnector.DbModels;
using KnowYourStuffWebApi;
using MongoDB.Driver;

namespace KnowYourStuffMongoDbConnector.DataAccess
{
    public class MongoTipRepository : ITipRepository
    {
        private readonly IMongoCollection<PlatformMongoModel> _platforms;
        public MongoTipRepository(IMongoDbSettings dbSettings)
        {
            var connectionString = $"mongodb://{dbSettings.User}:{dbSettings.Password}@{dbSettings.Host}:{dbSettings.Port}";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _platforms = database.GetCollection<PlatformMongoModel>(dbSettings.PlatformsCollectionName);
        }
        
        public async Task<Tip> Create(Tip newTip)
        {
            var filter = Builders<PlatformMongoModel>.Filter.Eq("_id", newTip.PlatformId);
            var addTipToPlatform = Builders<PlatformMongoModel>.Update.Push<TipMongoModel>("Tips", new TipMongoModel() { Id = newTip.Id, Description = newTip.Description, Snippet = newTip.Snippet});
            await _platforms.UpdateOneAsync(filter, addTipToPlatform);
            return newTip;
        }
    }
}