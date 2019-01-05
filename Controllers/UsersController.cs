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

        // GET api/values/5
        [HttpPost]
        [Route("api/[controller]/login")]
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
