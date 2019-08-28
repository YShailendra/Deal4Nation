using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Deal;
using Products.Repository.Image;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    public class DealsController : Controller
    {
        #region Private Property
        private IDealRepository _repo;
        private DealsViewModel vm;
        public DealsController(IDealRepository repo, IImageRepository imgRepo)
        {
            this._repo = repo;
            this.vm = new DealsViewModel(this._repo, imgRepo);
        }
        #endregion
        // GET api/values
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            //var vm = new DealsViewModel(this._repo);
            var result = await this.vm.GetAllDeal();
            return Ok(result);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await this.vm.GetDealById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DealModel value)
        {
            Console.WriteLine(value);
            return Ok(await this.vm.CreateDeal(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]DealModel value)
        {
            return Ok(await this.vm.UpdateDeal(id, value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await this.vm.DeleteDeal(id));
        }
    }
}
