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
           var data = await _repo.Find(id.ToString());
           return data;
        }
        public async Task<IEnumerable<DealModel>> GetAllDeal()
        {
           var data = await _repo.GetAll();
           return data;
        }
        #region  Private Methods
       
        #endregion
    }
}