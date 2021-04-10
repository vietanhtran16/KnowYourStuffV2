using System;

namespace KnowYourStuffCore.Models
{
    public class Tip
    {
        public Tip(string description, string snippet, Guid platformId)
        {
            Id = Guid.NewGuid();
            Description = description;
            Snippet = snippet;
            PlatformId = platformId;
        }
        
        public Tip(Guid id, string description, string snippet, Guid platformId)
        {
            Id = id;
            Description = description;
            Snippet = snippet;
            PlatformId = platformId;
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Snippet { get; set; }
        public Guid PlatformId { get; set; }
    }
}