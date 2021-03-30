using System;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Dtos
{
    public class PlatformRead
    {
        public PlatformRead(Platform platform)
        {
            Id = platform.Id;
            Name = platform.Name;
            Description = platform.Description;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}