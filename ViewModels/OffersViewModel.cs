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
        public async Task<IEnumerable<OfferModel>> GetByStoreId(Guid id)
        {
           var data = await _offerRepo.GetByStoreId(id);
           return data;
        }
        public async Task<IEnumerable<OfferModel>> GetByBrand(Guid id)
        {
           var data = await _offerRepo.GetByBrand(id);
           return data;
        }
        public async Task<IEnumerable<OfferModel>> GetByCategories(List<Guid> ids)
        {
           var data = await _offerRepo.GetByCategories(ids);
           return data;
        }

        public async Task<IEnumerable<OfferModel>> GetFavoriteByUserId(Guid userId)
        {
           var data = await _offerRepo.GetFavouriteOffers(userId);
           return data;
        }
        #region  Private Methods
       
        #endregion
    }
}