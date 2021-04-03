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
                throw new NotFoundException();
            }
            return new PlatformRead(platform);
        }

        public Task<TipRead> AddTipToPlatform(NewTip newTip)
        {
            return _tipService.Create(newTip);
        }
    }
}