using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string Description{ get; set; }
        public Guid CategoryID { get; set; }
        public string Url { get; set; }
        public Guid? SubCategoryID { get; set; }
        
     
        public CategoryModel Category { get; set; }
        
     
        public CategoryModel SubCategory { get; set; }

        public string Logo { get; set; }
    }
}
