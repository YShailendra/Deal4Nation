using Products.Models;
using Products.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Repository.Offer
{
    public interface IOfferRepository:IBaseRepository<OfferModel>
    {
        Task<IEnumerable<OfferModel>> GetByStoreId(Guid id);
        Task<IEnumerable<OfferModel>> GetByBrand(Guid id);
        Task<IEnumerable<OfferModel>> GetByCategories(Guid ids);
        Task<IEnumerable<OfferModel>> GetFavouriteOffers(Guid userId);
    }
}