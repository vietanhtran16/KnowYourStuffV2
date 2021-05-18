using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;
using KnowYourStuffSqlConnector.DbModels;
using Microsoft.EntityFrameworkCore;

namespace KnowYourStuffSqlConnector
{
    public class SqlPlatformRepository : IPlatformRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public SqlPlatformRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Task<List<Platform>> GetPlatforms()
        {
            return _repositoryContext.Platforms.Select(platformDb => platformDb.ToPlatform()).ToListAsync();
        }

        public async Task<Platform> GetPlatform(Guid id)
        {
            var platformDbModel = await _repositoryContext.Platforms.Include(platformDb => platformDb.Tips).FirstOrDefaultAsync(platformDb => platformDb.Id == id);
            return platformDbModel?.ToPlatform();
        }

        public async Task<Platform> GetPlatform(string name)
        {
            var platformDbModel = await _repositoryContext.Platforms.FirstOrDefaultAsync(platformDb => platformDb.Name == name);
            return platformDbModel?.ToPlatform();
        }

        public async Task<IList<Tip>> GetTips(Guid platformId)
        {
            var tips = await _repositoryContext.Tips.Where(tip => tip.PlatformId == platformId).ToListAsync();
            return tips.Select(tip => new Tip(tip.Id, tip.Description, tip.Snippet, tip.PlatformId)).ToList();
        }

        public async Task Save(Platform platform)
        {
            foreach (var evnt in platform.Events)
            {
                switch (evnt)
                {
                    case TipCreatedEvent tipCreatedEvent:
                        await Handle(tipCreatedEvent);
                        break;
                    case PlatformCreatedEvent platformCreatedEvent:
                        await Handle(platformCreatedEvent);
                        break;
                }
            }
            await _repositoryContext.SaveChangesAsync();
        }
        
        private async Task Handle(TipCreatedEvent tipCreatedEvent)
        {
            var platform =
                await _repositoryContext.Platforms.FirstOrDefaultAsync(item =>
                    item.Id == tipCreatedEvent.PlatformId);
            var newTip = new TipDbModel()
            {
                Id = tipCreatedEvent.Id,
                Description = tipCreatedEvent.Description,
                Snippet = tipCreatedEvent.Snippet,
                PlatformId = tipCreatedEvent.PlatformId
            };
            _repositoryContext.Entry(newTip).State = EntityState.Added;
            platform.Tips.Add(newTip);
        }
        
        private async Task Handle(PlatformCreatedEvent newPlatform)
        {
            await _repositoryContext.Platforms.AddAsync(new PlatformDbModel() { Id = newPlatform.Id, Name = newPlatform.Name, Description = newPlatform.Description });
        }
    }
}