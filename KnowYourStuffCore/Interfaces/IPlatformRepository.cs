using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Interfaces
{
    public interface IPlatformRepository
    {
        Task<Platform> CreatePlatform(Platform newPlatform);
    }
}