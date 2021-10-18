using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Interfaces
{
    public interface ITipRepository
    {
        Task<Tip> Create(Tip newTip);
        Task<IEnumerable<Tip>> GetTipsByPlatform(Guid id);
    }
}