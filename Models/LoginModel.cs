using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
       
        public string Password { get; set; }

        public string Token{get;set;}
       
       
    }
}