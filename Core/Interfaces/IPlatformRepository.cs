using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Interfaces
{
    public interface IPlatformRepository
    {
        Task<Platform> CreatePlatform(Platform newPlatform);
        Task<List<Platform>> GetPlatforms();
        Task<Platform> GetPlatform(Guid id);
        Task<Platform> GetPlatform(string name);
        Task<IList<Tip>> GetTips(Guid platformId);
        Task Save(Platform platform);
    }
}