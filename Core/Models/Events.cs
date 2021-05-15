using System;
using System.Collections.Generic;

namespace KnowYourStuffCore.Models
{
    public class TipCreatedEvent
    {
        public Guid Id;

        public string Description;

        public string Snippet;
        
        public Guid PlatformId { get; set; }
    }
    
    public class PlatformCreatedEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}