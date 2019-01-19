using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class DealModel:BaseModel
    {
        public DealModel(){
            Logo = new ImageModel();
        }
        [Required]
        public string Name { get; set;}

        public string Description { get; set;}
        [NotMapped]
        public ImageModel Logo { get; set;}

        public string Url { get; set;}

        public Boolean? IsActive { get; set;}

        public bool? isFav {get;set;}
    }
}