using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Product;
using Products.ViewModels;

namespace Products.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : Controller
    {
        #region Private Property
        private IProductRepository _repo;
        //private IImageRepository _imgRepo;

        private ProductViewModel vm;
        public ProductController(IProductRepository repo)
        {
            this._repo = repo;
            this.vm = new ProductViewModel(this._repo);
        }
        #endregion
        // GET api/values
        [HttpGet , AllowAnonymous]

        public async Task<IActionResult> Get()
        {

            var result = await vm.GetAllProduct();
            return Ok(result);
        }
        // GET api/values/5
        [HttpGet("{id}") ,AllowAnonymous]
        public string Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductModel value)
        {
            
            return Ok(await vm.CreateProduct(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ProductModel value)
        {
            //await this.vm.UpdateBrand(value);
            return Ok(await vm.UpdateProduct(id, value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await vm.DeleteProduct(id));
        }
    }
}