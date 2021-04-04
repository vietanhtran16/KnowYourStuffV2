using System.Threading.Tasks;
using KnowYourStuffCore.Exceptions;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;
using KnowYourStuffSqlConnector.DbModels;
using Microsoft.EntityFrameworkCore;

namespace KnowYourStuffSqlConnector
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
            var matchPlatform = await _repositoryContext.Platforms.FirstOrDefaultAsync(platform => platform.Id == newTip.PlatformId);
            if (matchPlatform == null)
            {
                throw new NotFoundException();
            }

            await _repositoryContext.Tips.AddAsync(new TipDbModel() { Id = newTip.Id, Description = newTip.Description, Snippet = newTip.Snippet, PlatformId = newTip.PlatformId});
            await _repositoryContext.SaveChangesAsync();
            return newTip;
        }
    }
}