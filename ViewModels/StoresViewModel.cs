using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository;
using Newtonsoft.Json;
using Products.Repository.Offer;
using Products.Repository.Deal;
using Products.Repository.Store;
using Products.Repository.Image;

namespace Products.ViewModels
{
    public class StoresViewModel : BaseViewModel
    {
        #region Private Property
        private IStoreRepository _repo;
        private IImageRepository _imgRepo;
        #endregion
        public StoresViewModel(IStoreRepository repo, IImageRepository imgRepo)
        {
            this._repo = repo;
            this._imgRepo = imgRepo;
        }
        public StoresViewModel()
        {

        }
        public async Task<StoreModel> GetOfferById(Guid id)
        {
            var data = await _repo.Find(id.ToString());
            return data;
        }
        public async Task<IEnumerable<StoreModel>> GetAllOffers()
        {
            var data = await _repo.GetAll();
            return data;
        }
        public async Task<StoreModel> Create(StoreModel model)
        {
            model.ID = Guid.NewGuid();
            var data = await _repo.Add(model);
            data = await this.UpdateStoreImage(data, model);
            return data;
        }
        public async Task<StoreModel> UpdateStore(Guid id, StoreModel model)
        {
            model.ID = id;
            return await _repo.Update(model); ;
        }
        public async Task<StoreModel> DeleteStore(string id)
        {
            var data = await _repo.Remove(id);
            return data;
        }

        public async Task<IEnumerable<StoreModel>> GetSubStores(Guid id)
        {
            var data = await this._repo.GetSubStores(id);
            return data;
        }





        #region  Private Methods
        private async Task<StoreModel> UpdateStoreImage(StoreModel result, StoreModel data)
        {
            // if(result !=null && data.Logo!=null){
            //      var img =  await this._imgRepo.Find(data.Logo.ID.ToString());
            //      if(img !=null){
            //          img.RefrenceID = data.ID;
            //      }
            //     await this._imgRepo.Update(img);
            //     data.Logo = img;
            // }
            return data;
        }
        #endregion
    }
}