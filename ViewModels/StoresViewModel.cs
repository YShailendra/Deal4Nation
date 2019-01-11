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

namespace Products.ViewModels
{
    public class StoresViewModel:BaseViewModel
    {
        #region Private Property
        private IStoreRepository _repo;
        #endregion
        public StoresViewModel(IStoreRepository repo)
        {
            this._repo = repo;
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
           return data;
        }
        public async Task<StoreModel> UpdateStore(Guid id,StoreModel model)
        {
            model.ID = id;
           return await _repo.Update(model);;
        }
        public async Task<StoreModel> DeleteStore(string id)
        {
           var data = await _repo.Remove(id);
           return data;
        }
        #region  Private Methods
       
        #endregion
    }
}