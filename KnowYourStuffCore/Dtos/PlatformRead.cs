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

        private Guid Id { get; }
        private string Name { get; }
        private string Description { get; }
    }
}