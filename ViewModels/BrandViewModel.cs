using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository.Brand;


namespace Products.ViewModels
{
    public class BrandViewModel
    {
        #region Private Variables 
        public IBrandRepository _repo {get; set;}
        #endregion
        public BrandViewModel(IBrandRepository repo)
        {
            this._repo=repo;
        }
        public BrandViewModel()
        {

        }
        public async Task<BrandModel> Create(BrandModel data)
        {
            data.ID= Guid.NewGuid();
            var result =this._repo.Add(data);
            return await result;
        }

        public async Task<List<BrandModel>> GetBrands()
        {     
            return await this._repo.GetAll() as List<BrandModel>;
        }
    }
}