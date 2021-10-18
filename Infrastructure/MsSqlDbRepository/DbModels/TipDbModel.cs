using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.MsSqlDbRepository.DbModels
{
    [Table("Tips")]
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
        
        public Guid PlatformId { get; set; }
        public PlatformDbModel Platform { get; set; }
    }
}