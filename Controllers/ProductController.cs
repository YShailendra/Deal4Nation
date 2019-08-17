using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Product;
using Products.ViewModels;

namespace Products.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        #region Private Property
        //private IProductRepository _repo;
        //private IImageRepository _imgRepo;

        private ProductViewModel _repo;
        public ProductController(ProductViewModel vm)
        {
            _repo = vm;
            //this.vm = new BrandViewModel(this._repo, imgrepo);
        }
        #endregion
        // GET api/values
        [HttpGet]

        public async Task<IActionResult> Get()
        {

            var result = await _repo.GetAllProduct();
            return Ok(result);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductModel value)
        {
            return Ok(await _repo.CreateProduct(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ProductModel value)
        {
            //await this.vm.UpdateBrand(value);
            return Ok(await _repo.UpdateProduct(id, value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _repo.DeleteProduct(id));
        }
    }
}