using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;

namespace KnowYourStuffCore.Interfaces
{
    public interface ITipService
    {
        Task<TipRead> Create(NewTip tip);
        Task<IEnumerable<TipRead>> GetTipsByPlatform(Guid platformId);
    }
}