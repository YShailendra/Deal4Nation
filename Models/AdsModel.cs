using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    public class AdsModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public ImageModel Image { get; set; }
      
        public string AdsDescription{get;set;}

        public string Link{get;set;}

        public Guid AdsCategory {get;set;}

    }
}