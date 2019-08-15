using Products.Models;
using System.Threading.Tasks;


namespace Products.Repository.Ads
{
    public interface IAdsRepository : IBaseRepository<AdsModel>
    {
        Task <AdsModel> GetAdsByCategory(string _value);
    }
}