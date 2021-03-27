using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.DataAccess
{
    public class InMemoryPlatformRepo : IPlatformRepository
    {
        public async Task<Platform> CreatePlatform(Platform newPlatform)
        {
            return newPlatform;
        }
    }
}