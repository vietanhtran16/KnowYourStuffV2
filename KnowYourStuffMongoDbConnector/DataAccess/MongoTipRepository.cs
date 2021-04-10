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
        private readonly IMongoCollection<TipMongoModel> _tips;
        public MongoTipRepository(IMongoDbSettings dbSettings)
        {
            var connectionString = $"mongodb://{dbSettings.User}:{dbSettings.Password}@{dbSettings.Host}:{dbSettings.Port}";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _tips = database.GetCollection<TipMongoModel>(dbSettings.TipsCollectionName);
        }
        
        public async Task<Tip> Create(Tip newTip)
        {
            await _tips.InsertOneAsync(new TipMongoModel()
            {
                Id = newTip.Id, PlatformId = newTip.PlatformId, Description = newTip.Description,
                Snippet = newTip.Snippet
            });
            return newTip;
        }
    }
}