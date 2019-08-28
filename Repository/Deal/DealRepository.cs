using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Products.Repository.Deal
{
    public class DealRepository : IDealRepository
    {
        private AppDbContext context;

        public DealRepository(AppDbContext context)
        {
            this.context = context;
        }

        public DealRepository()
        {

        }
        public async Task<DealModel> Add(DealModel item)
        {
            await this.context.Deals.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<DealModel>> GetAll()
        {
            var data = await this.context.Deals.ToListAsync();
            return data;
        }
        public async Task<DealModel> Find(string Id)
        {
            return await this.context.Deals.Where(w => w.ID == Guid.Parse(Id)).Select(s => new DealModel
            {
                ID = s.ID,
                Name = s.Name,
                Logo = s.Logo
            }).FirstOrDefaultAsync();
        }
        public async Task<DealModel> GetByEmailOrNumber(string _value)
        {
            return await this.context.Deals.Where(w => w.Name == _value).FirstOrDefaultAsync();
        }
        public async Task<DealModel> Remove(string Id)
        {
            var itemToRemove = await context.Deals.FirstOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Deals.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<DealModel> Update(DealModel item)
        {
            if (item != null)
            {
                this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            return item;
        }

    }
}