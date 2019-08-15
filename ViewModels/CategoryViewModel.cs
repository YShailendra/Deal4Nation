using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository.Category;


namespace Products.ViewModels
{
    public class CategoryViewModel
    {
        #region Private Variables 
        public ICategoryRepository _repo {get; set;}
        #endregion
        public CategoryViewModel(ICategoryRepository repo)
        {
            this._repo=repo;
        }
        public CategoryViewModel()
        {

        }
        public async Task<CategoryModel> Create(CategoryModel data)
        {
            data.ID= Guid.NewGuid();
            var result =this._repo.Add(data);
            return await result;
        }

        public async Task<List<CategoryModel>> GetCategories()
        {     
            return await this._repo.GetAll() as List<CategoryModel>;
        }
        public async Task<CategoryModel> GetCategoryById(string id)
        {     
            return await this._repo.Find(id);
        }
        public async Task<CategoryModel> UpdateCategory(Guid id,CategoryModel model)
        {   model.ID = id; 
            return await this._repo.Update(model);
        }
        public async Task<CategoryModel> DeleteCategory(string id)
        {     
            return await this._repo.Remove(id);
        }

    }
}