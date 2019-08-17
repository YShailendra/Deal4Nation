using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Repository.Product
{
    public interface IProductRepository:IBaseRepository<ProductModel>
    {
    }
}
