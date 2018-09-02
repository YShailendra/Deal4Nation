using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Repository.User
{
    public interface IUserRepository:IBaseRepository<UserModel>
    {
        Task<UserModel> GetByEmailOrNumber(string _value);
    }
}