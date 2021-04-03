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
    }
}