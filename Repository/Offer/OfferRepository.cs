using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Products.Repository.Offer
{
    public class OfferRepository:IOfferRepository
    {
        private AppDbContext context;

        public OfferRepository(AppDbContext context)
        {
            this.context = context;
        }

        public OfferRepository()
        {

        }
        public async Task<OfferModel> Add(OfferModel item)
        {
            await this.context.Offers.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<OfferModel>>GetAll()
        {
            var data= await this.context.Offers.ToListAsync();
            return data;
        }
        public async Task<OfferModel> Find(string Id)
        {
            return await this.context.Offers.Where(w=>w.ID==System.Guid.Parse(Id)).FirstOrDefaultAsync();
        }
        public async Task<OfferModel> GetByEmailOrNumber(string _value)
        {
            return await this.context.Offers.Where(w=>w.Name==_value).FirstOrDefaultAsync();
        }
        public async Task<OfferModel> Remove(string Id)
        {
            var itemToRemove = await context.Offers.FirstOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Offers.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<OfferModel> Update(OfferModel item)
        {
            if(item!=null)
            {
                this.context.Entry(item).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<IEnumerable<OfferModel>> GetByStoreId(Guid id)
        {
            return await this.context.Offers.Where(w=>w.BrandID==id).ToListAsync();
        }

        public async Task<IEnumerable<OfferModel>> GetByBrand(Guid id)
        {
            return await this.context.Offers.Where(w=>w.BrandID==id).ToListAsync();
        }

        public async Task<IEnumerable<OfferModel>> GetByCategories(Guid ids)
        {
            return await this.context.Offers.Where(w=>w.CategoryID == ids).ToListAsync();
        } 
        public async Task<IEnumerable<OfferModel>> GetFavouriteOffers(Guid userId)
        {
            return await this.context.Favourite.Where(w=>w.UserId==userId).
            Join(this.context.Offers,fav=>fav.OfferId,offer=>offer.ID,(fav,Offer)=> new { fav, Offer}).Select(s=> s.Offer).ToListAsync();
        }
    }
}