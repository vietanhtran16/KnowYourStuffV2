using System;
using KnowYourStuffCore.Dtos;

namespace KnowYourStuffCore.Models
{
    public class Platform
    {
        public Platform(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }
        
        public Platform(Guid id, string name, string description)
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