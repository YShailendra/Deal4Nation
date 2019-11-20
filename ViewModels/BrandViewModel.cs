using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository.Brand;
using Products.Repository.Image;


namespace Products.ViewModels
{
    public class BrandViewModel
    {
        #region Private Variables 
        public IBrandRepository _repo { get; set; }
        public IImageRepository _imgRepo { get; set; }
        #endregion
        public BrandViewModel(IBrandRepository repo, IImageRepository imgRepo)
        {
            this._repo = repo;
            this._imgRepo = imgRepo;
        }
        public BrandViewModel()
        {

        }
        public async Task<BrandModel> Create(BrandModel data)
        {
            data.ID = Guid.NewGuid();
            var result = await this._repo.Add(data);
            // if(result !=null && data.Logo!=null){
            //      var img =  await this._imgRepo.Find(data.Logo.ID.ToString());
            //      if(img !=null){
            //          img.RefrenceID = data.ID;
            //      }
            //     await this._imgRepo.Update(img);
            //     data.Logo = img;
            // }

            //this._imgRepo.Add()

            return result;
        }

        public async Task<List<BrandModel>> GetBrands()
        {
            return await this._repo.GetAll() as List<BrandModel>;
        }

        public async Task<BrandModel> GetBrandById(string id)
        {
            return await this._repo.Find(id);
        }

        public async Task<BrandModel> UpdateBrand(Guid id, BrandModel model)
        {
            model.ID = id;
            return await this._repo.Update(model);
        }
        public async Task<BrandModel> DeleteBrand(string id)
        {
            return await this._repo.Remove(id);
        }

        public async Task<IEnumerable<BrandModel>> GetBrandByType(string key)
        {
            return await this._repo.GetBrandByType(key);
        }
    }
}