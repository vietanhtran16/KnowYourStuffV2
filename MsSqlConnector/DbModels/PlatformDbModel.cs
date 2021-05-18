using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        
        public List<TipDbModel> Tips { get; set; }

        public Platform ToPlatform()
        {
            return new Platform(Id, Name, Description, Tips.Select(tip => new Tip(tip.Id, tip.Description, tip.Snippet, tip.PlatformId)).ToList());
        }
    }
}