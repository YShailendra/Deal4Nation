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
    public class CategoryRepository : ICategoryRepository
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
            var itemToRemove = await context.Category.FirstOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Category.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<CategoryModel> Update(CategoryModel item)
        {
            if (item != null)
            {
                this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            var data = await this.context.Category.Select(s => new CategoryModel()
            {
                ID = s.ID,
                Name = s.Name,
                CreatedOn = s.CreatedOn,
                isFav = s.isFav,
                CatType = s.CatType,
                CatPID = s.CatPID,
                Logo = s.Logo
            }).ToListAsync();
            return data;
        }

        public async Task<CategoryModel> Find(string key)
        {
            return await this.context.Category.Where(w => w.CatType == Int32.Parse(key)).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<CategoryModel>> GetAllSub(string key)
        {
            var data = await this.context.Category.Where(d => d.CatPID == Guid.Parse(key))
            .Select(s => new CategoryModel()
            {
                ID = s.ID,
                Name = s.Name,
                CreatedOn = s.CreatedOn,
                isFav = s.isFav,
                CatType = s.CatType,
                CatPID = s.CatPID
            }).ToListAsync();
            return data;
            // return await this.context.Category.wH
        }


    }
}