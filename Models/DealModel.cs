using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class DealModel : BaseModel
    {

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Logo { get; set; }

        public string Url { get; set; }

        public Boolean? IsActive { get; set; }

        public bool? isFav { get; set; }

        public Guid? CategoryID { get; set; }
        public Guid? SubCategoryID { get; set; }

        public Guid? StoreID {get;set;}

        public string ShortDescription{get;set;}

        public string Coupon {get;set;}

        [NotMapped]
        public CategoryModel Category { get; set; }
        [NotMapped]
        public CategoryModel SubCategory { get; set; }
        [NotMapped]
    public StoreModel Store{get;set;}
    }
}