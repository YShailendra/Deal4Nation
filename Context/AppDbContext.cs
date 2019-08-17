
using System;
using Products.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Products.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public AppDbContext() { }

        public DbSet<UserModel> User { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<MarketPlaceModel> MarketPlace { get; set; }
        public DbSet<DealModel> Deals { get; set; }
        public DbSet<OfferModel> Offers { get; set; }
        public DbSet<StoreModel> Stores { get; set; }
        public DbSet<FavouriteModel> Favourite { get; set; }
        public DbSet<AdsModel> Ads { get; set; }
        public DbSet<ClickModel> UserClick { get; set; }
        public DbSet<PaymentRequestModel> PaymentRequest { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserModel>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.PhoneNo).IsUnique();
            });
            //builder.Entity<CategoryModel>().HasData(new CategoryModel{ ID=Guid.NewGuid()},);               
        }


        /// <summary>  
        /// Overriding Save Changes  
        /// </summary>  
        /// <returns></returns>  
        public override int SaveChanges()
        {
            var addedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is BaseModel &&
                                    (x.State == EntityState.Added));
            var updatedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is BaseModel &&
                                    (x.State == EntityState.Modified));
            //Gt user Name from  session or other authentication   
            var userName = Guid.NewGuid();

            foreach (var entity in addedEntityList)
            {
                ((BaseModel)entity.Entity).ID = Guid.NewGuid();
                ((BaseModel)entity.Entity).CreatedOn = DateTime.Now;
                ((BaseModel)entity.Entity).CreatedBy = userName;
            }
            foreach (var entity in updatedEntityList)
            {

                ((BaseModel)entity.Entity).UpdatedOn = DateTime.Now;
                ((BaseModel)entity.Entity).UpdatedBy = userName;
            }
            return base.SaveChanges();
        }
        /// <summary>  
        /// Overriding Save Changes Async  
        /// </summary>  
        /// <returns></returns>  
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var addedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is BaseModel &&
                                    (x.State == EntityState.Added));
            var updatedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is BaseModel &&
                                    (x.State == EntityState.Modified));
            //Gt user Name from  session or other authentication   
            var userName = Guid.NewGuid();

            foreach (var entity in addedEntityList)
            {
                ((BaseModel)entity.Entity).ID = Guid.NewGuid();
                ((BaseModel)entity.Entity).CreatedOn = DateTime.Now;
                ((BaseModel)entity.Entity).CreatedBy = userName;
            }
            foreach (var entity in updatedEntityList)
            {

                ((BaseModel)entity.Entity).UpdatedOn = DateTime.Now;
                ((BaseModel)entity.Entity).UpdatedBy = userName;
            }
            int result = await base.SaveChangesAsync();
            return result; 
        }
        
    }
}