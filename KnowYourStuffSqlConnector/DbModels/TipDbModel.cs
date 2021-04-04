using System;
using System.ComponentModel.DataAnnotations;

namespace KnowYourStuffSqlConnector.DbModels
{
    public class TipDbModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Snippet { get; set; }
        
        public int PlatformId { get; set; }
        public PlatformDbModel Platform { get; set; }
    }
}