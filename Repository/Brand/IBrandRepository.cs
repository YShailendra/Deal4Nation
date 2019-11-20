using Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Repository.Brand
{
    public interface IBrandRepository:IBaseRepository<BrandModel>
    {
        Task<IEnumerable<BrandModel>> GetBrandByType(string key);
    }
}