using System;

namespace KnowYourStuffCore.Models
{   
    public class TipCreatedEvent
    {
        public Guid Id;

        public string Description;

        public string Snippet;
        
        public Guid PlatformId { get; set; }
    }
}