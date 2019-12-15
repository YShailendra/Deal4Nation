using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Repository;
using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;

namespace Products.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        public AppDbContext context;
        public ProductRepository()
        { }
        public ProductRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public async Task<ProductModel> Add(ProductModel item)
        {

            await context.Product.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<ProductModel> Find(string key)
        {
            return await context.Product.Where(w => w.ID == Guid.Parse(key)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            return await context.Product.ToListAsync();
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
        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(Guid id)
        {
            return await context.Product.Where(w => w.CategoryID == id).Select(s => new ProductModel()
            {
                ID = s.ID,
                Name = s.Name,
                CreatedOn = s.CreatedOn,
                Url = s.Url,
                Logo= s.Logo,
                CategoryID = s.CategoryID,
                SubCategoryID = s.SubCategoryID,
                Category = this.context.Category.Where(a => a.ID == s.CategoryID).FirstOrDefault(),
                SubCategory = this.context.Category.Where(a => a.ID == s.SubCategoryID).FirstOrDefault(),
            }).ToListAsync();
        }
    }
}
