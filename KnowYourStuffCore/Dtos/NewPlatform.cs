using System.ComponentModel.DataAnnotations;

namespace KnowYourStuffCore.Dtos
{
    public class NewPlatform
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(300)]
        public string Description { get; set; }
    }
}