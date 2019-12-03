using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Brand;
using Products.Repository.Deal;
using Products.Repository.Image;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BrandController : Controller
    {
       #region Private Property
        private IBrandRepository _repo;
        private IImageRepository _imgRepo;

        private BrandViewModel vm;
        public BrandController(IBrandRepository repo,IImageRepository imgrepo){
            this._repo = repo;
            this.vm = new BrandViewModel(this._repo,imgrepo);
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
            return null;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BrandModel value)
        {
             return Ok(await this.vm.Create(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]BrandModel value)
        {
            //await this.vm.UpdateBrand(value);
            return Ok(await this.vm.UpdateBrand(id,value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
             return Ok(await this.vm.DeleteBrand(id));
        }


[HttpGet("getBrandsByType/{key}")]
        public async Task<IActionResult> GetBrandsByType(string key){
return Ok(await this.vm.GetBrandByType(key));
        }
    }
}
