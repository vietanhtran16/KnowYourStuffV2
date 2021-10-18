using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;

namespace Infrastructure.InMemoryRepository
{
    public class InMemoryPlatformRepo : IPlatformRepository
    {
        private readonly IEnumerable<Platform> _platforms = new List<Platform>()
        {
            new Platform("node", "Javascript"),
            new Platform("docker", "Container"),
        };
        public Task<Platform> CreatePlatform(Platform newPlatform)
        {
            return Task.FromResult(newPlatform);
        }

        public Task<IEnumerable<Platform>> GetPlatforms()
        {
            return Task.FromResult(_platforms);
        }

        public Task<Platform> GetPlatform(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Platform> GetPlatform(string name)
        {
            throw new NotImplementedException();
        }
    }
}