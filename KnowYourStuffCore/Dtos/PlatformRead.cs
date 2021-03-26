using System;

namespace KnowYourStuffCore.Dtos
{
    public class PlatformRead
    {
        public PlatformRead(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}