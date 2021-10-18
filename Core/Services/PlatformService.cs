using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Exceptions;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _repository;
        private readonly ITipService _tipService;
        public PlatformService(IPlatformRepository platformRepository, ITipService tipService)
        {
            _repository = platformRepository;
            _tipService = tipService;
        }
        
        public async Task<PlatformRead> Create(NewPlatform newPlatform)
        {
            var platform = newPlatform.ToPlatform();
            platform.Validate();
            var duplicatedPlatform = await _repository.GetPlatform(platform.Name);
            if (duplicatedPlatform != null)
            {
                throw new DuplicatedPlatformException(platform.Name);
            }
            
            await _repository.CreatePlatform(platform);
            return new PlatformRead(platform);
        }

        public async Task<IEnumerable<PlatformRead>> GetPlatforms()
        {
            var platforms = await _repository.GetPlatforms();
            return platforms.Select(platform => new PlatformRead(platform));
        }

        public async Task<PlatformRead> GetPlatform(Guid id)
        {
            var platform = await FindPlatform(id);
            return new PlatformRead(platform);
        }

        public async Task<TipRead> AddTipToPlatform(NewTip newTip)
        {
            await FindPlatform(newTip.PlatformId);
            return await _tipService.Create(newTip);
        }

        public async Task<IEnumerable<TipRead>> GetTipsByPlatform(Guid platformId)
        {
            await FindPlatform(platformId);
            return await _tipService.GetTipsByPlatform(platformId);
        }
        
        private async Task<Platform> FindPlatform(Guid id)
        {
            var platform = await _repository.GetPlatform(id);
            if (platform == null)
            {
                throw new NotFoundException("Platform", id);
            }
            return platform;
        }
    }
}