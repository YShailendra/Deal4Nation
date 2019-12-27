using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Ads;
using Products.ViewModels;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdsController : Controller
    {
        private IAdsRepository _repo;
        private AdsViewModel vm;

        public AdsController(IAdsRepository repo){
            this._repo = repo;
            this.vm = new AdsViewModel(this._repo);
        }

        [HttpGet , AllowAnonymous]
        public async Task<IActionResult> Get(){
            var result = await this.vm.GetAds();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string value){
            var result = await this.vm.GetAdsById(Guid.Parse(value));
            return Ok(result);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]AdsModel value)
        {
            return Ok(await this.vm.Create(value));
        }
    }
}
