using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class StoreModel:BaseModel
    {
        [Required]
        public string Name { get; set;}
        [NotMapped]
        public  ImageModel Logo {get; set;}
    }
}