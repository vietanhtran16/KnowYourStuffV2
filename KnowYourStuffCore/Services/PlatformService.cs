using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Exceptions;
using KnowYourStuffCore.Interfaces;

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

        public async Task<List<PlatformRead>> GetPlatforms()
        {
            var platforms = await _repository.GetPlatforms();
            return platforms.Select(platform => new PlatformRead(platform)).ToList();
        }

        public async Task<PlatformRead> GetPlatform(Guid id)
        {
            var platform = await _repository.GetPlatform(id);
            if (platform == null)
            {
                throw new NotFoundException("Platform", id);
            }
            return new PlatformRead(platform);
        }

        public async Task<TipRead> AddTipToPlatform(NewTip newTip)
        {
            var platform = await _repository.GetPlatform(newTip.PlatformId);
            if (platform == null)
            {
                throw new NotFoundException("Platform", newTip.PlatformId);
            }
            return await _tipService.Create(newTip);
        }

        public Task<List<TipRead>> GetTipsByPlatform(Guid platformId)
        {
            return _tipService.GetTipsByPlatform(platformId);
        }
    }
}