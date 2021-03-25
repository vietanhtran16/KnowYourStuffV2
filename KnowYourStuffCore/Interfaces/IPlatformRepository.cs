using KnowYourStuffCore.Dtos;

namespace KnowYourStuffCore
{
    public interface IPlatformRepository
    {
        Platform CreatePlatform(Platform newPlatform);
    }
}