using Products.Context;

namespace BookingSystemApi.Repository
{
    public class BaseRepository
    {
        public BaseRepository() { }

        protected AppDbContext context;
        public BaseRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        

        //public void SaveChanges(AppDbContext context)
        //{   
        //    context.SaveChangesAsync();
        //}

    }
}