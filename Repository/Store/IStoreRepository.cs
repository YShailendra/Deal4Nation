using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Repository.Store
{
    public interface IStoreRepository:IBaseRepository<StoreModel>
    {
        Task<StoreModel> GetByName(string _value);
    }
}