using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnowYourStuffCore.Models;

namespace Infrastructure.MsSqlDbRepository.DbModels
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
        
        public List<TipDbModel> Tips { get; set; }

        public Platform ToPlatform()
        {
            return new Platform(Id, Name, Description);
        }
    }
}