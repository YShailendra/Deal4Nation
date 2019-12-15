using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Store;
using Products.ViewModels;
using Products.Repository.Image;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StoresController : Controller
    {
        private IStoreRepository _repo;
        private StoresViewModel viewModel;
        public StoresController(IStoreRepository repo, IImageRepository imageRepo)
        {
            _repo = repo;
            viewModel = new StoresViewModel(_repo, imageRepo);
        }

        // GET api/values
        [HttpGet ,AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await viewModel.GetAllOffers());
        }

        // GET api/values/5
        [HttpGet("{id}") ,AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await viewModel.GetOfferById(id));
        }

        // POST api/values
        [HttpPost ,AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]StoreModel value)
        {
            return Ok(await viewModel.Create(value));
        }

        // PUT api/values/5
        [HttpPut("{id}") , AllowAnonymous]
        public async Task<IActionResult> Put(Guid id, [FromBody]StoreModel value)
        {
            return Ok(await viewModel.UpdateStore(id, value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}"),AllowAnonymous]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await viewModel.DeleteStore(id));
        }

        [HttpGet("getSubStores/{cid}/{id}") ,AllowAnonymous]
        public async Task<IActionResult> GetSubStores(Guid cid, Guid id)
        {
            return Ok(await viewModel.GetSubStores(cid, id));

        }


        [HttpGet("getStores/{id}") ,AllowAnonymous]

        public async Task<IActionResult> GetStores(Guid id)
        {
            return Ok(await viewModel.GetStores(id));
        }
    }
}
