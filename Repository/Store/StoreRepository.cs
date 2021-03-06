using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Products.Repository.Store
{
    public class StoreRepository:IStoreRepository
    {
        private AppDbContext context;

        public StoreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public StoreRepository()
        {

        }
        public async Task<StoreModel> Add(StoreModel item)
        {
            await this.context.Stores.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<StoreModel>>GetAll()
        {
            var data= await this.context.Stores.ToListAsync();
            return data;
        }
        public async Task<StoreModel> Find(string Id)
        {
            return await this.context.Stores.Where(w=>w.ID==System.Guid.Parse(Id)).FirstOrDefaultAsync();
        }
        public async Task<StoreModel> GetByName(string _value)
        {
            return await this.context.Stores.Where(w=>w.Name==_value).FirstOrDefaultAsync();
        }
        public async Task<StoreModel> Remove(string Id)
        {
            var itemToRemove = await context.Stores.FirstOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Stores.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<StoreModel> Update(StoreModel item)
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