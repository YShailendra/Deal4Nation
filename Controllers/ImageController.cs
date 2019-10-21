using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repository.Image;
using Products.ViewModels;

namespace Products.Controllers{

    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ImageController: Controller{

        public IImageRepository _repo;
        private ImageViewModel vm;

        public ImageController(IImageRepository repo){
            this._repo = repo;
            this.vm = new ImageViewModel(this._repo);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.vm.GetImages();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string value)
        {
            var result = await this.vm.GetImageById(Guid.Parse(value));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromBody]ImageModel value)
        {
            var result = await this.vm.Create(value);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ImageModel value)
        {
            //await this.vm.UpdateBrand(value);
            return Ok(await this.vm.UpdateImage(id,value));
        }
       
    }
} 