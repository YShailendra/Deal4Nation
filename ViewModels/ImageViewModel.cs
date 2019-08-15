using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository.Image;

namespace Products.ViewModels{
    public class ImageViewModel {

        private IImageRepository _repo {get;set;}

        public ImageViewModel(IImageRepository repo){
            this._repo = repo;
        }

        public async Task<ImageModel> Create(ImageModel data)
        {
            data.ID = Guid.NewGuid();
            var result = this._repo.Add(data);
            return await result;
        }

        public async Task<List<ImageModel>> GetImages()
        {
            return await this._repo.GetAll() as List<ImageModel>;
        }

        public async Task<ImageModel> GetImageById(Guid id)
        {
            return await this._repo.Find(id.ToString());
        }

        public async Task<ImageModel> UpdateImage(Guid id,ImageModel model)
        {
            model.ID = id;
            return await this._repo.Update(model);
        }
        public async Task<ImageModel> DeleteImage(string id)
        {
            return await this._repo.Remove(id);
        }
    }


    }
