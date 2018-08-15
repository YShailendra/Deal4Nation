using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class BrandModel:BaseModel
    {
        [Required]
        public string Name { get; set;}
        public ImageModel Logo { get; set; }


    }
}