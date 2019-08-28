using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository;
using Newtonsoft.Json;
using Products.Repository.Offer;
using Products.Repository.Deal;
using Products.Repository.Image;

namespace Products.ViewModels
{
    public class DealsViewModel : BaseViewModel
    {
        #region Private Property
        private IDealRepository _repo;
        private IImageRepository _imgRepo;
        #endregion
        public DealsViewModel(IDealRepository repo, IImageRepository _imgRepo)
        {
            this._repo = repo;
        }
        public async Task<DealModel> GetDealById(Guid id)
        {
            return await _repo.Find(id.ToString());
        }
        public async Task<IEnumerable<DealModel>> GetAllDeal()
        {
            var data = await _repo.GetAll();
            return data;
        }

        public async Task<DealModel> CreateDeal(DealModel model)
        {
            Console.WriteLine(model);
            model.ID = Guid.NewGuid();

            var result = await _repo.Add(model);

            // result = await this.UpdateDealImage(result, model);
            return result;
        }
        public async Task<DealModel> UpdateDeal(Guid id, DealModel model)
        {
            model.ID = id;
            return await _repo.Update(model); ;
        }
        public async Task<DealModel> DeleteDeal(string id)
        {
            return await _repo.Remove(id);
        }
        #region  Private Methods
        private async Task<DealModel> UpdateDealImage(DealModel result, DealModel data)
        {
            // if(result !=null && data.Logo!=null){
            //      var img =  await this._imgRepo.Find(data.Logo.ID.ToString());
            //      if(img !=null){
            //          img.RefrenceID = data.ID;
            //      }
            //     await this._imgRepo.Update(img);
            //     data.Logo = img;
            // }
            return data;
        }
        #endregion
    }
}