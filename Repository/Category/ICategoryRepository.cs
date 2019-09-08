using Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Repository.Category
{
    public interface ICategoryRepository : IBaseRepository<CategoryModel>
    {
        Task<IEnumerable<CategoryModel>> GetAllSub(string key);
        Task<IEnumerable<CategoryModel>> GetProductCategory();
    }
}