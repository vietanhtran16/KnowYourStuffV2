using System;
using System.ComponentModel.DataAnnotations;
using KnowYourStuffCore.Models;

namespace KnowYourStuffSqlConnector.DbModels
{
    public class PlatformDbModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }

        public Platform ToPlatform()
        {
            return new Platform(Id, Name, Description);
        }
    }
}