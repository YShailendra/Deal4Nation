using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Store;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    public class StoresController : Controller
    {
        private IStoreRepository _repo;
        private StoresViewModel viewModel;
        public StoresController(IStoreRepository repo)
        {
            this._repo = repo;
            this.viewModel = new StoresViewModel(this._repo);
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.viewModel.GetAllOffers());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StoreModel value)
        { 
            return Ok(await this.viewModel.Create(value));
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
