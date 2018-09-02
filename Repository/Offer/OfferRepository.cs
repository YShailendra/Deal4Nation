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
            return await this.context.Offers.Where(w=>w.ID==System.Guid.Parse(Id)).SingleOrDefaultAsync();
        }
        public async Task<OfferModel> GetByEmailOrNumber(string _value)
        {
            return await this.context.Offers.Where(w=>w.Name==_value).FirstOrDefaultAsync();
        }
        public async Task<OfferModel> Remove(string Id)
        {
            var itemToRemove = await context.Offers.SingleOrDefaultAsync(r => r.ID == Guid.Parse(Id));
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
        
    }
}