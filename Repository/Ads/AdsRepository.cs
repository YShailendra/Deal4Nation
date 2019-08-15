using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Products.Repository.Ads;

namespace Products.Repository.Ads
{
    public class AdsRepository : IAdsRepository
    {
        private AppDbContext context;

        private AdsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<AdsModel> Add(AdsModel item)
        {
            await this.context.Ads.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }

        public async Task<AdsModel> Find(string key)
        {
            return await this.context.Ads.Where(w => w.ID == Guid.Parse(key)).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<AdsModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<AdsModel> Remove(string Id)
        {
            var itemToRemove = await context.Ads.FirstOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Ads.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }

        public async Task<AdsModel> Update(AdsModel item)
        {
            if (item != null)
            {
                this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<AdsModel> GetAdsByCategory(string value){
            return await this.context.Ads.Where(w => w.AdsCategory == Guid.Parse(value)).FirstOrDefaultAsync();
        }
    }

}