using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository;
using Newtonsoft.Json;
using Products.Repository.Offer;
using Products.Repository.Deal;

namespace Products.ViewModels
{
    public class DealsViewModel:BaseViewModel
    {
        #region Private Property
        private IDealRepository _repo;
        #endregion
        public DealsViewModel(IDealRepository repo)
        {
            this._repo = repo;
        }
        public DealsViewModel()
        {
            
        }
        public async Task<DealModel> GetDealById(Guid id)
        {
           return await _repo.Find(id.ToString());
        }
        public async Task<IEnumerable<DealModel>> GetAllDeal()
        {
           var data = await _repo.GetAll();
           return data;
        }
        public async Task<DealModel> CreateDeal(DealModel model)
        {
            model.ID = Guid.NewGuid();
            return await _repo.Add(model);
        }
        public async Task<DealModel> UpdateDeal(Guid id,DealModel model)
        {
            model.ID =id;
            return await _repo.Update(model); ;
        }
        public async Task<DealModel> DeleteDeal(string id)
        {
           return await _repo.Remove(id);
        }
        #region  Private Methods
       
        #endregion
    }
}