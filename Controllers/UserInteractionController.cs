using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.UserInteraction;
using Products.ViewModels;

namespace Products.Controllers
{

    public class UserInteractionController : Controller
    {

        private IUserInteractionRepository repo;
        private UserInteractionViewModel vm;
        public UserInteractionController(IUserInteractionRepository _repo)
        {
            this.repo = _repo;
            this.vm = new UserInteractionViewModel(this.repo);
        }

        [Route("api/[controller]/ads")]
        [HttpGet]

        public async Task<IActionResult> GetAds()
        {

            var result = await this.vm.GetAds();
            return Ok(result);
        }
        [Route("api/[controller]/ads")]
        [HttpPost]
        public async Task<IActionResult> CreateAds([FromBody] AdsModel value)
        {
            return Ok(await this.vm.CreateAds(value));
        }
        // POST api/values

        [Route("api/[controller]/clicks")]
        [HttpGet]

        public async Task<IActionResult> GetClicks(){
            var result = await this.vm.GetClicks();
            return Ok(result);
        }

        [Route("api/[controller]/cliks")]
        [HttpPost]

        public async Task<IActionResult> CreateClicks([FromBody] ClickModel value){
            return Ok(await this.vm.RecordClicks(value));
        }

        [Route("api/[controller]/payments")]
        [HttpGet]
        public async Task<IActionResult> GetPaymentResult(){
            var result = await this.vm.GetPaymentRequests();
            return Ok(result);
        }

        [Route("api/[controller]/payments")]
        [HttpPost]

        public async Task<IActionResult> CreatePaymentRequest([FromBody] PaymentRequestModel value){
            return Ok (await this.vm.CreatePaymentRequest(value));
        }
    }
}