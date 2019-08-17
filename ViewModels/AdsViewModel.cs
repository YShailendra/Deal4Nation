using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository.Ads;


namespace Products.ViewModels
{
    public class AdsViewModel
    {

        public IAdsRepository _repo {get;set;}

        public AdsViewModel(IAdsRepository repo){
            this._repo = repo;
        }
        public async Task<AdsModel> Create(AdsModel data)
        {
            data.ID = Guid.NewGuid();
            var result = this._repo.Add(data);
            return await result;
        }

        public async Task<List<AdsModel>> GetAds()
        {
            return await this._repo.GetAll() as List<AdsModel>;
        }

        public async Task<AdsModel> GetAdsById(Guid id)
        {
            var data = await _repo.Find(id.ToString());
            return data;
        }

    }
}
