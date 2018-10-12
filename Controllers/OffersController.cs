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
        public OffersController(IOfferRepository repo){
            this._repo = repo;
        }
        #endregion
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vm = new OffersViewModel(this._repo); 
            return  Ok(await vm.GetAllOffers());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OfferModel value)
        {
            var vm = new OffersViewModel(this._repo); 
            return Ok(await vm.Create(value));
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
