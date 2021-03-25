using KnowYourStuffCore.Dtos;

namespace KnowYourStuffCore
{
    public interface IPlatformRepository
    {
        PlatformRead CreatePlatform(NewPlatform newPlatform);
    }
}