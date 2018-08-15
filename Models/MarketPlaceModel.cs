using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class MarketPlaceModel:BaseModel
    {
        [Required]
        public string Name { get; set;}
        public string Description { get; set;}
        public ImageModel Logo { get; set;}
        public string Url { get; set;}
        public Boolean? IsActive { get; set;}
    }
}