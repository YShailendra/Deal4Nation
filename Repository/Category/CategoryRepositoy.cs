using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Products.Repository.Category
{
    public class CategoryRepository:ICategoryRepository
    {
        private AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CategoryRepository()
        {

        } 
        public async Task<CategoryModel> Remove(string Id)
        {
            var itemToRemove = await context.Category.SingleOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Category.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<CategoryModel> Update(CategoryModel item)
        {
            if(item!=null)
            {
                this.context.Entry(item).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<CategoryModel> Add(CategoryModel item)
        {
            await this.context.Category.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<CategoryModel>> GetAll()
        {
             var data= await this.context.Category.ToListAsync();
             return data;
        }

        public async Task<CategoryModel> Find(string key)
        {
            return await this.context.Category.Where(w=>w.ID==Guid.Parse(key)).SingleOrDefaultAsync();
        }

       
    }
}