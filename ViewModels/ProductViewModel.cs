using Products.Models;
using Products.Repository.Image;
using Products.Repository.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.ViewModels
{
    public class ProductViewModel
    {
        #region Private Property
        private IProductRepository _repo;

        #endregion
        public ProductViewModel(IProductRepository repo)
        {
            _repo = repo;
        }
        public ProductViewModel()
        {

        }
        public async Task<ProductModel> GetProductById(Guid id)
        {
            return await _repo.Find(id.ToString());
        }
        public async Task<IEnumerable<ProductModel>> GetAllProduct()
        {
            var data = await _repo.GetAll();
            return data;
        }
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            // model.ID = Guid.NewGuid();
            var result = await _repo.Add(model);
            //result = await this.UpdateProductImage(result, model);
            return result;
        }
        public async Task<ProductModel> UpdateProduct(Guid id, ProductModel model)
        {
            model.ID = id;
            return await _repo.Update(model); ;
        }
        public async Task<ProductModel> DeleteProduct(string id)
        {
            return await _repo.Remove(id);
        }
        #region  Private Methods
        //private async Task<ProductModel> UpdateProductImage(ProductModel result, ProductModel data)
        //{
        //    if (result != null && data.Logo != null)
        //    {
        //        var img = await this._imgRepo.Find(data.Logo.ID.ToString());
        //        if (img != null)
        //        {
        //            img.RefrenceID = data.ID;
        //        }
        //        await this._imgRepo.Update(img);
        //        data.Logo = img;
        //    }
        //    return data;
        //}
        #endregion
    }
}
