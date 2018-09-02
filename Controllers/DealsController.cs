using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Repository.Deal;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    public class DealsController : Controller
    {
       #region Private Property
        private IDealRepository _repo;
        public DealsController(IDealRepository repo){
            this._repo = repo;
        }
        #endregion
        // GET api/values
        [HttpGet]

        public async Task<IActionResult> Get()
        {
           var vm = new DealsViewModel(this._repo);
            var result= await vm.GetAllDeal();
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
        public void Post([FromBody]string value)
        {
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
