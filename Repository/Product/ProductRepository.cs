using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Repository;
using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.Repository.Product
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public async Task<ProductModel> Add(ProductModel item)
        {
            await context.Product.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<ProductModel> Find(string key)
        {
            return await this.context.Product.Where(w => w.ID == Guid.Parse(key)).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<ProductModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> Remove(string Id)
        {
            var itemToRemove = await context.Product.FirstOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Product.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }

        public async Task<ProductModel> Update(ProductModel item)
        {
            if (item != null)
            {
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
            }
            return item;
        }
    }
}
