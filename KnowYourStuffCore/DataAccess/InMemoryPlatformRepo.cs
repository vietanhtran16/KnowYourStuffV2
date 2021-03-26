using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Interfaces;

namespace KnowYourStuffCore.DataAccess
{
    public class InMemoryPlatformRepo : IPlatformRepository
    {
        public Platform CreatePlatform(Platform newPlatform)
        {
            return newPlatform;
        }
    }
}