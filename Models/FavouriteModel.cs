using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Products.Models
{
    public class FavouriteModel:BaseModel
    {
        public Guid UserId { get; set; }
        public int OfferId { get; set; }
    }
}