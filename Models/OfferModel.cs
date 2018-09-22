using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class OfferModel:BaseModel
    {
        [Required]
        public string Name { get; set;}
        public string Description {get; set;}
        public string ShortDescription {get; set;}
        public string Cashback {get; set;}
        public Guid BrandID {get; set;}
        public Guid CategoryID {get; set;}
        public Guid SubCategoryID {get; set;}
        public string Url {get; set;}
        public string Logo {get; set;}
        public string CouponCode {get; set;}
        [NotMapped]
        public List<ImageModel> Images {get;set;}

        [ForeignKey("CategoryID")]
        public CategoryModel Category { get; set; }
       
        [ForeignKey("BrandID")]
        public BrandModel Brand {get; set;} 
        public Boolean? IsActive { get; set;}
        public DateTime EndOn { get; set;}
        public DateTime StartOn { get; set;}
      
    }
}