using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    public class ClickModel : BaseModel
    {
       public Guid OfferId{get;set;}
       public Guid UserId{get;set;}

    }
}