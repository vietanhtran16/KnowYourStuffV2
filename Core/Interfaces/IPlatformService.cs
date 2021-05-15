using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;

namespace KnowYourStuffCore.Interfaces
{
    public interface IPlatformService
    {
        Task<PlatformRead> Create(NewPlatform newPlatform);
        Task<List<PlatformRead>> GetPlatforms();
        Task<PlatformRead> GetPlatform(Guid id);
        Task<TipRead> AddTipToPlatform(NewTip newTip);
        Task<IList<TipRead>> GetTipsByPlatform(Guid platformId);
    }
}