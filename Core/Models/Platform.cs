using System;
using System.Collections.Generic;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Exceptions;

namespace KnowYourStuffCore.Models
{
    public class Platform
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        public IList<Tip> Tips = new List<Tip>();

        public IList<object> Events = new List<object>();
        public Platform(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Events.Add(new PlatformCreatedEvent()
            {
                Id = Id,
                Name = Name,
                Description = Description
            });
        }
        
        public Platform(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        
        public Platform(Guid id, string name, string description, IList<Tip> tips)
        {
            Id = id;
            Name = name;
            Description = description;
            Tips = tips;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new MissingPropertyException("Platform", "Name");
            }
        }

        public void AddTip(Tip tip)
        {
            Tips.Add(tip);
            Events.Add(new TipCreatedEvent()
            {
                Id = tip.Id,
                Description = tip.Description,
                Snippet = tip.Snippet,
                PlatformId = tip.PlatformId
            });
        }
    }
}