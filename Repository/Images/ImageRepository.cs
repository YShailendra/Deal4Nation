using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Products.Repository.Image;

namespace Products.Repository.Image
{
    public class ImageRepository : IImageRepository
    {

        private AppDbContext context;

        public ImageRepository(AppDbContext context){
            this.context = context;
        }

        public async Task<ImageModel> Add(ImageModel item)
        {
             await  this.context.Images.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }

        public  async Task<ImageModel> Find(string Id)
        {
            
            return await this.context.Images.Where(w => w.ID == System.Guid.Parse(Id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ImageModel>> GetAll()
        {
           return await this.context.Images.ToListAsync();
        }

        public async Task<ImageModel> Remove(string Id)
        {
            var itemToRemove = await context.Images.SingleOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.Images.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }

        public async Task<ImageModel> Update(ImageModel item)
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