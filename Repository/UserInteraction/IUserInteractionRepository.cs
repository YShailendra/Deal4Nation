using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Repository.UserInteraction
{
    public interface IUserInteractionRepository 
    {
        Task<AdsModel> InsertAds(AdsModel value);
        Task<ClickModel> InsertClicks (ClickModel value);
        Task<PaymentRequestModel> InsertPayments (PaymentRequestModel value);
        Task <ICollection<AdsModel>> GetAds();
        Task<ICollection<ClickModel>> GetClicks();
        Task<ICollection<PaymentRequestModel>> GetPayments();



    }
}