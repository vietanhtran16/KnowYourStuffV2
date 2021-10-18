using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.MsSqlDbRepository.DbModels;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MsSqlDbRepository
{
    public class SqlTipRepository : ITipRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public SqlTipRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<Tip> Create(Tip newTip)
        {
            await _repositoryContext.Tips.AddAsync(new TipDbModel() { Id = newTip.Id, Description = newTip.Description, Snippet = newTip.Snippet, PlatformId = newTip.PlatformId});
            await _repositoryContext.SaveChangesAsync();
            return newTip;
        }

        public async Task<IEnumerable<Tip>> GetTipsByPlatform(Guid id)
        {
            var tips = await _repositoryContext.Tips.Where(tip => tip.PlatformId == id).ToListAsync();
            return tips.Select(tip => new Tip(tip.Id, tip.Description, tip.Snippet, tip.PlatformId));
        }
    }
}