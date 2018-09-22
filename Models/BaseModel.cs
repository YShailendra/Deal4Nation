using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Products.Models
{
    public class BaseModel
    {
        public Guid ID { get; set;}
        public DateTime CreatedOn {get; set;}
        [JsonIgnore]
        public DateTime? UpdatedOn {get; set;}
        [JsonIgnore]
        public Guid? CreatedBy {get; set;}
        [JsonIgnore]
        public Guid? UpdatedBy {get; set;}
    }
}