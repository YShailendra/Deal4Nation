
using System;
using Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Products.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) { }
        public AppDbContext(){ }
      
        public DbSet<UserModel> User { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<CategoryModel> Category { get; set; } 
        public DbSet<ImageModel> AppImage { get; set; }
        public DbSet<MarketPlaceModel> MarketPlace { get; set; }
         public DbSet<DealModel> Deals { get; set; }
        public DbSet<OfferModel> Offers {get; set;}
        public DbSet<StoreModel> Stores {get; set;}
        public DbSet<FavouriteModel> Favourite {get; set;}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
        
         builder.Entity<UserModel>(entity => {
                    entity.HasIndex(e => e.Email).IsUnique();
                    entity.HasIndex(e=>e.PhoneNo).IsUnique();
                });
         //builder.Entity<CategoryModel>().HasData(new CategoryModel{ ID=Guid.NewGuid()},);               
        }
        
    }
}