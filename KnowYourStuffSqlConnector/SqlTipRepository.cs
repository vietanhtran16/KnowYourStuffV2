using System;
using System.Collections.Generic;
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
            await _repositoryContext.Tips.AddAsync(new TipDbModel() { Id = newTip.Id, Description = newTip.Description, Snippet = newTip.Snippet, PlatformId = newTip.PlatformId});
            await _repositoryContext.SaveChangesAsync();
            return newTip;
        }

        public Task<List<Tip>> GetTipsByPlatform(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}