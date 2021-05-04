using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;
using KnowYourStuffMongoDbConnector.DbModels;
using MongoDB.Driver;

namespace KnowYourStuffMongoDbConnector.DataAccess
{
    public class MongoTipRepository : ITipRepository
    {
        private readonly IMongoCollection<TipMongoModel> _tips;
        public MongoTipRepository(MongoDbSettings dbSettings)
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

        public async Task<List<Tip>> GetTipsByPlatform(Guid id)
        {
            var filter = Builders<TipMongoModel>.Filter.Eq(nameof(TipMongoModel.PlatformId), id);
            var tips = await _tips.FindAsync(filter);
            return tips.ToList().Select(tip => new Tip(tip.Id, tip.Description, tip.Snippet, tip.PlatformId)).ToList();
        }
    }
}