using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
namespace Products.Models
{
    public class BrandModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public string Logo { get; set; }
        public bool? isFav { get; set; }

    }
}