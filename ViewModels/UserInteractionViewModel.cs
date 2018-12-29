using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;
using Products.Repository.UserInteraction;

namespace Products.ViewModels{

    public class UserInteractionViewModel{
        #region Private Variables 
        public IUserInteractionRepository _repo { get; set; }
        #endregion
        public UserInteractionViewModel(IUserInteractionRepository repo)
        {
            this._repo = repo;
        }
        public async Task<AdsModel> CreateAds(AdsModel data)
        {
            data.ID = Guid.NewGuid();
            var result = this._repo.InsertAds(data);
            return await result;
        }

     public async Task<ClickModel> RecordClicks(ClickModel data){
         data.ID = Guid.NewGuid();
         var result = this._repo.InsertClicks(data);
         return await result;
     }

     public async Task<PaymentRequestModel> CreatePaymentRequest(PaymentRequestModel data){
         data.ID = Guid.NewGuid();
         var result = this._repo.InsertPayments(data);
         return await result;
     }

     public async Task<ICollection<AdsModel>> GetAds(){
         var result = this._repo.GetAds();
         return await result;
     }

        public async Task<ICollection<ClickModel>> GetClicks()
        {
            var result = this._repo.GetClicks();
            return await result;
        }

        public async Task<ICollection<PaymentRequestModel>> GetPaymentRequests()
        {
            var result = this._repo.GetPayments();
            return await result;
        }

    }
}