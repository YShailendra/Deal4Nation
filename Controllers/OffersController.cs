using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Offer;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    public class OffersController : Controller
    {
        #region Private Property
        private IOfferRepository _repo;
        private  OffersViewModel vm;
        public OffersController(IOfferRepository repo){
            this._repo = repo;
            this.vm= new OffersViewModel(this._repo);
        }
        #endregion
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await this.vm.GetAllOffers());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return  Ok(await this.vm.GetOfferById(Guid.Parse(id)));;
        }
        [HttpGet("GetByStoreId/{id}")]
        public async Task<IActionResult> GetByStoreId(string id)
        {
            Console.WriteLine(id);
            return  Ok(await this.vm.GetByStoreId(Guid.Parse(id)));;
        }
        [HttpGet("GetByBrandId/{id}")]
        public async Task<IActionResult> GetByBrandId(string id)
        {
             Console.WriteLine(id);
            return  Ok(await this.vm.GetByBrand(Guid.Parse(id)));;
        }

        [HttpGet("GetFavouriteByUserId/{id}")]
        public async Task<IActionResult> GetFavouriteByUserId(string id)
        {
            return  Ok(await this.vm.GetFavoriteByUserId(Guid.Parse(id)));;
        }

          [HttpGet("GetByCategories/{id}")]
        public async Task<IActionResult> GetByCategories(string id)
        {
            Console.WriteLine(id);
            return  Ok(await this.vm.GetByCategories(Guid.Parse(id)));
        }    
        //POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OfferModel value)
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
