using System.ComponentModel.DataAnnotations;
using KnowYourStuffCore.Models;

namespace KnowYourStuffCore.Dtos
{
    public class NewPlatform
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public Platform ToPlatform()
        {
            return new Platform(Name, Description);
        }
    }
}