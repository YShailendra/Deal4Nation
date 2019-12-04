using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Offer;
using Products.Repository.Image;
using Products.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OffersController : Controller
    {
        #region Private Property
        private IOfferRepository _repo;
        private  OffersViewModel vm;
        public OffersController(IOfferRepository repo,IImageRepository imgRepo){
            this._repo = repo;
            this.vm= new OffersViewModel(this._repo,imgRepo);
        }
        #endregion
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await this.vm.GetAllOffers());
        }

        // GET api/values/5
        [HttpGet("{id}") ,AllowAnonymous]
        public async Task<IActionResult> Get(string id)
        {
            return  Ok(await this.vm.GetOfferById(Guid.Parse(id)));;
        }
        [HttpGet("GetByStoreId/{id}") ,AllowAnonymous]
        public async Task<IActionResult> GetByStoreId(string id)
        {
            
            return  Ok(await this.vm.GetByStoreId(Guid.Parse(id)));;
        }
        [HttpGet("GetByBrandId/{id}") ,AllowAnonymous]
        public async Task<IActionResult> GetByBrandId(string id)
        {
             
            return  Ok(await this.vm.GetByBrand(Guid.Parse(id)));;
        }

        [HttpGet("GetFavouriteByUserId/{id}") ,AllowAnonymous]
        public async Task<IActionResult> GetFavouriteByUserId(string id)
        {
            return  Ok(await this.vm.GetFavoriteByUserId(Guid.Parse(id)));;
        }

          [HttpGet("GetByCategories/{id}") ,AllowAnonymous]
        public async Task<IActionResult> GetByCategories(string id)
        {
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
        public async Task<IActionResult> Put(Guid id, [FromBody]OfferModel value)
        {
            return Ok(await this.vm.UpdateOffer(id,value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await this.vm.DeleteOffer(id));
        }
    }
}
