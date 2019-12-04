using Products.Context;
using Products.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Repository.User
{
    public class UserRepository:IUserRepository
    {
        private AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public UserRepository()
        {

        }
        public async Task<ResultModel<UserModel>> Add(UserModel item)
        {
            
            var finalresult = new ResultModel<UserModel>();
            var result = await GetByEmailOrNumber(item.Email);
            if(result == null){
                await context.User.AddAsync(item);
                await context.SaveChangesAsync();
            }
            else{
                finalresult.HasError = true;
                finalresult.ErrorMessage = new string[]{"User already exist"};
            }
            finalresult.Result = item;
            return finalresult;
        }
        public async Task<IEnumerable<UserModel>>GetAll()
        {
            var data= await this.context.User.ToListAsync();
            return data;
        }
        public async Task<UserModel> Find(string Id)
        {
            return await this.context.User.Where(w=>w.ID==Guid.Parse(Id)).FirstOrDefaultAsync();
        }
        public async Task<UserModel> GetByEmailOrNumber(string _value)
        {
            return await this.context.User.Where(w=>w.Username==_value||w.PhoneNo==_value||w.Email==_value).FirstOrDefaultAsync();
        }
        public async Task<UserModel> Remove(string Id)
        {
            var itemToRemove = await context.User.FirstOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.User.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<UserModel> Update(UserModel item)
        {
            if(item!=null)
            {
                this.context.Entry(item).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            return item;
        }

        Task<UserModel> IBaseRepository<UserModel>.Add(UserModel item)
        {
            throw new NotImplementedException();
        }
    }
}