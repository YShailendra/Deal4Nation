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
        public string Image { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public Guid? Category { get; set; }

        public Guid? SubCategory { get; set; }

    }
}