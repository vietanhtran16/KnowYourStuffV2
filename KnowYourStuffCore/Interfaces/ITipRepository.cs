using System.Threading.Tasks;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Interfaces
{
    public interface ITipRepository
    {
        Task<Tip> Create(Tip newTip);
    }
}