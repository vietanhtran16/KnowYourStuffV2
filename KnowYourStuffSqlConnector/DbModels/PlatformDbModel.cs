using System;
using System.ComponentModel.DataAnnotations;

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
    }
}