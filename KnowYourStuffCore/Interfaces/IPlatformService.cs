using System.Collections.Generic;
using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;

namespace KnowYourStuffCore.Interfaces
{
    public interface IPlatformService
    {
        Task<PlatformRead> Create(NewPlatform newPlatform);
        Task<List<PlatformRead>> GetPlatforms();
    }
}