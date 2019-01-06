using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.Models
{
    public class ChangePasswordModel
    {
        public Guid UserId {get;set;}
        public string NewPassword { get;}
        public string OldPassword {get;}
        public string ConfirmPassword {get;}
        public string Otp { get; }
       
    };
}