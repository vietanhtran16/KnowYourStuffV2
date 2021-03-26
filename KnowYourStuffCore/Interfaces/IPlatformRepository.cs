using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Interfaces
{
    public interface IPlatformRepository
    {
        Platform CreatePlatform(Platform newPlatform);
    }
}