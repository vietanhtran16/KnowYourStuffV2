using System.Threading.Tasks;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;
using KnowYourStuffSqlConnector.DbModels;

namespace KnowYourStuffSqlConnector
{
    public class SqlPlatformRepository : IPlatformRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public SqlPlatformRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<Platform> CreatePlatform(Platform newPlatform)
        {
            await _repositoryContext.Platforms.AddAsync(new PlatformDbModel() { Id = newPlatform.Id, Name = newPlatform.Name, Description = newPlatform.Description });
            await _repositoryContext.SaveChangesAsync();
            return newPlatform;
        }
    }
}