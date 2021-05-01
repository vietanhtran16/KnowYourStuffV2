using System;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Dtos
{
    public class NewTip
    { 
        public string Description { get; set; }
        public string Snippet { get; set; }
        public Guid PlatformId { get; set; }

        public Tip ToTip()
        {
            return new Tip(Description, Snippet, PlatformId);
        }
    }
}