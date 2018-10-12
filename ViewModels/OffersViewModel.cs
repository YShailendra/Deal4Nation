using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository;
using Newtonsoft.Json;
using Products.Repository.Offer;

namespace Products.ViewModels
{
    public class OffersViewModel:BaseViewModel
    {
        #region Private Property
        private IOfferRepository _offerRepo;
        #endregion
        public OffersViewModel(IOfferRepository repo)
        {
            this._offerRepo = repo;
        }
        public OffersViewModel()
        {
            
        }
        public async Task<OfferModel> GetOfferById(Guid id)
        {
           var data = await _offerRepo.Find(id.ToString());
           return data;
        }
        public async Task<IEnumerable<OfferModel>> GetAllOffers()
        {
           var data = await _offerRepo.GetAll();
           return data;
        }
        public async Task<OfferModel> Create(OfferModel model)
        {
           model.ID= Guid.NewGuid(); 
           var data = await _offerRepo.Add(model);
           return data;
        }
        #region  Private Methods
       
        #endregion
    }
}