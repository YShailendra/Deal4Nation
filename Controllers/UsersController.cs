using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.User;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : Controller
    {
        private UserViewModel viewModel;
        public UsersController(IUserRepository repo){
            this.viewModel = new UserViewModel(repo);
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.viewModel.GetUsers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await this.viewModel.GetUserById(id));
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginModel model){
            return Ok(await this.viewModel.Login(model));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Register ([FromBody]UserModel value)
        {
            Console.WriteLine(value);
            return Ok(await this.viewModel.RegisterUser(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]UserModel value)
        {
            return Ok(await this.viewModel.UpdateUser(id,value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody]string email)
        {
            Console.WriteLine(email);
            return Ok(await this.viewModel.ForgetPassword(email));
        }
        
        [HttpPost("ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody]ChangePasswordModel value)
        {
        
            return Ok(await this.viewModel.ChangePassword(id,value));
        }
        [HttpPost("VerifyOtp")]
         public async Task<IActionResult> VerifyOtp( [FromBody]ChangePasswordModel value)
        {
            return Ok(await this.viewModel.VerifyOtp(value));
        }
    }
}
