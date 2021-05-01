using System;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Dtos
{
    public class TipRead
    {
        public TipRead(Tip tip)
        {
            Id = tip.Id;
            Description = tip.Description;
            Snippet = tip.Snippet;
            PlatformId = tip.PlatformId;
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Snippet { get; set; }
        public Guid PlatformId { get; set; }
    }
}