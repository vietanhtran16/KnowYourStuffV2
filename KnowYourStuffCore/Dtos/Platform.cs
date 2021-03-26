using System;

namespace KnowYourStuffCore.Dtos
{
    public class Platform
    {
        public Platform(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public Guid Id { get; }
        public string Name { get; }

        public string Description { get; }
    }
}