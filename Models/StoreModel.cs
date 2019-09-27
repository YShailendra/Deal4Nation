using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class StoreModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public string Logo { get; set; }

        public bool? isFav { get; set; }

        public string Url { get; set; }

        public int StoreType { get; set; }

        public Guid? StorePID { get; set; }

        public Guid? CategoryID { get; set; }


        [ForeignKey("CategoryID")]
        public CategoryModel Category { get; set; }

    }
}