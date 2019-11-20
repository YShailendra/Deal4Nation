using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Products.Repository.Brand;

namespace Products.Repository.Category
{
    public class BrandRepository : IBrandRepository
    {
        private AppDbContext context;

        public BrandRepository(AppDbContext context)
        {
            this.context = context;
        }

        public BrandRepository()
        {

        }
        public async Task<BrandModel> Remove(string Id)
        {
            var itemToRemove = await context.Brand.FirstOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Brand.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<BrandModel> Update(BrandModel item)
        {
            if (item != null)
            {
                this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<BrandModel> Add(BrandModel item)
        {
            await this.context.Brand.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<BrandModel>> GetAll()
        {
            var data = await this.context.Brand.Select(s => new BrandModel()
            {
                ID = s.ID,
                Name = s.Name,
                CreatedOn = s.CreatedOn,
                isFav = s.isFav,
                Logo = s.Logo,
                BrandType = s.BrandType
            }
            ).ToListAsync();
            return data;
        }

        public async Task<BrandModel> Find(string key)
        {
            return await this.context.Brand.Where(w => w.ID == Guid.Parse(key)).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<BrandModel>> GetBrandByType(string key)
        {
            return await this.context.Brand.Where(w => w.BrandType == key).Select(s => new BrandModel()
            {
                ID = s.ID,
                Name = s.Name,
                CreatedOn = s.CreatedOn,
                isFav = s.isFav,
                Logo = s.Logo,
                BrandType = s.BrandType
            }
            ).ToListAsync();
        
        }

    }
}