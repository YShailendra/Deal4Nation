using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class CategoryModel:BaseModel
    {
        [Required]
        public string Name { get; set;}
        [Required]
        public int CatType { get; set;}
        public Guid? CatPID { get; set;}

        public bool? isFav {get;set;}
    }
}