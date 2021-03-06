using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Brand;
using Products.Repository.Category;
using Products.Repository.Deal;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
       #region Private Property
        private ICategoryRepository _repo;
        private CategoryViewModel vm;
        public CategoryController(ICategoryRepository repo){
            this._repo = repo;
            this.vm = new CategoryViewModel(this._repo);
        }
        #endregion
        // GET api/values
        [HttpGet]

        public async Task<IActionResult> Get()
        {
           
            var result= await this.vm.GetCategories();
            return  Ok(result);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await this.vm.GetCategoryById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryModel value)
        {
             return Ok(await this.vm.Create(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]CategoryModel value)
        {
            return Ok(await this.vm.UpdateCategory(id,value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await this.vm.DeleteCategory(id));
        }
    }
}
