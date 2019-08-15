using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository;
using Newtonsoft.Json;
using Products.Repository.Offer;
using Products.Repository.Image;

namespace Products.ViewModels
{
    public class OffersViewModel:BaseViewModel
    {
        #region Private Property
        private IOfferRepository _offerRepo;
        private IImageRepository _imgRepo;
        #endregion
        public OffersViewModel(IOfferRepository repo,IImageRepository imgRepo)
        {
            this._offerRepo = repo;
            this._imgRepo = imgRepo;
        }
        public OffersViewModel()
        {
            
        }
        public async Task<OfferModel> GetOfferById(Guid id)
        {
           var data = await _offerRepo.Find(id.ToString());
           Console.WriteLine(data);
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
           data = await this.UpdateOfferImage(data,model);
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
        public async Task<IEnumerable<OfferModel>> GetByCategories(Guid ids)
        {
           var data = await _offerRepo.GetByCategories(ids);
           return data;
        }
         public async Task<OfferModel> UpdateOffer(Guid id,OfferModel model)
        {
           model.ID = id;
           var data = await _offerRepo.Update(model);
           return data;
        }
         public async Task<OfferModel> DeleteOffer(string id)
        {
           var data = await _offerRepo.Remove(id);
           return data;
        }
        public async Task<IEnumerable<OfferModel>> GetFavoriteByUserId(Guid userId)
        {
           var data = await _offerRepo.GetFavouriteOffers(userId);
           return data;
        }
        #region  Private Methods
       private async Task<OfferModel> UpdateOfferImage(OfferModel result,OfferModel data)
        {
            if(result !=null && data.Images!=null){
                 var img =  await this._imgRepo.GetImagesByIds(data.Images.Select(ss=>ss.ID).ToList());
                 if(img !=null && img.Count()>0){
                     foreach (var item in img)
                     {
                        item.RefrenceID = data.ID;
                         await this._imgRepo.Update(item);
                     }
                     
                 }
            }
            return data;
        }
        #endregion
    }
}