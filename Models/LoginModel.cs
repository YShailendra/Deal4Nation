using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Products.Models
{
    public class LoginModel
    {
        public string Username { get; set; }

      
        public string Password { get; set; }

        public dynamic Token{get;set;}
       
       
    }
}