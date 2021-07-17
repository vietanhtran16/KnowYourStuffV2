using System;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Exceptions;

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

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new MissingPropertyException("Platform", "Name");
            }
        }

        public Guid Id { get; }
        public string Name { get; }

        public string Description { get; }
    }
}