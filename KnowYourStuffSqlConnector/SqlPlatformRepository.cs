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
        public async Task<Platform> CreatePlatform(Platform newPlatform)
        {
            await _repositoryContext.Platforms.AddAsync(new PlatformDbModel() { Id = newPlatform.Id, Name = newPlatform.Name, Description = newPlatform.Description });
            await _repositoryContext.SaveChangesAsync();
            return newPlatform;
        }

        public Task<List<Platform>> GetPlatforms()
        {
            return _repositoryContext.Platforms.Select(platformDb => platformDb.ToPlatform()).ToListAsync();
        }

        public Task<Platform> GetPlatform(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}