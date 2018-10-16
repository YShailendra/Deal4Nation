using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Brand;
using Products.Repository.Deal;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
       #region Private Property
        private IBrandRepository _repo;
        private BrandViewModel vm;
        public BrandController(IBrandRepository repo){
            this._repo = repo;
            this.vm = new BrandViewModel(this._repo);
        }
        #endregion
        // GET api/values
        [HttpGet]

        public async Task<IActionResult> Get()
        {
           
            var result= await this.vm.GetBrands();
            return  Ok(result);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BrandModel value)
        {
             return Ok(await this.vm.Create(value));
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