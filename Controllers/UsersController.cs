using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.User;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model){
            return Ok(await this.viewModel.Login(model));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Register ([FromBody]UserModel value)
        {
            return Ok(await this.viewModel.RegisterUser(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UserModel value)
        {
            return Ok(await this.viewModel.UpdateUser(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            return Ok(await this.viewModel.ForgetPassword(email));
        }
        
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody]ChangePasswordModel value)
        {
            return Ok(await this.viewModel.ChangePassword(value));
        }
        [HttpPost("VerifyOtp")]
         public async Task<IActionResult> VerifyOtp(int id, [FromBody]ChangePasswordModel value)
        {
            return Ok(await this.viewModel.VerifyOtp(value));
        }
    }
}
