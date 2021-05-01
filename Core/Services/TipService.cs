using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Interfaces;

namespace KnowYourStuffCore.Services
{
    public class TipService : ITipService
    {
        private readonly ITipRepository _repository;
        public TipService(ITipRepository repository)
        {
            _repository = repository;
        }
        public async Task<TipRead> Create(NewTip tip)
        {
            var newTip = await _repository.Create(tip.ToTip());
            return new TipRead(newTip);
        }

        public async Task<List<TipRead>> GetTipsByPlatform(Guid platformId)
        {
            var tips = await _repository.GetTipsByPlatform(platformId);
            return tips.Select(tip => new TipRead(tip)).ToList();
        }
    }
}