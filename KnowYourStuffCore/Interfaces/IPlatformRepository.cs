using KnowYourStuffCore.Dtos;

namespace KnowYourStuffCore.Interfaces
{
    public interface IPlatformRepository
    {
        Platform CreatePlatform(Platform newPlatform);
    }
}