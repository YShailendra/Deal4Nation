using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class ProductModel:BaseModel
    {
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public Guid CategoryID { get; set; }
        public string  Link { get; set; }
        public Guid? SubCategoryID { get; set; }
        [JsonIgnore]
        [NotMapped]
        public CategoryModel Category { get; set; }
        [JsonIgnore]
        [NotMapped]
        public CategoryModel SubCategory { get; set; }
    }
}
