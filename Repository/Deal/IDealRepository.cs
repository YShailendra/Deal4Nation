using Products.Models;
using Products.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Repository.Deal
{
    public interface IDealRepository : IBaseRepository<DealModel>
    {
        Task<IEnumerable<DealModel>> GetDealsByCategory(Guid id);

    }
}