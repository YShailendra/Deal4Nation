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
        [Required]
        public string Logo { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public Guid? CategoryID { get; set; }

        public Guid? SubCategoryID { get; set; }

        public CategoryModel Category { get; set; }
        
        public CategoryModel SubCategory { get; set; }
        

    }
}