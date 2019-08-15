using Products.Context;
using Products.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Repository.UserInteraction
{
    public class UserInteractionRepository : IUserInteractionRepository
    {
        private AppDbContext context;

        public UserInteractionRepository(AppDbContext context){
                this.context = context;
        }

        public async Task<ICollection<AdsModel>> GetAds()
        {
           return await this.context.Ads.ToListAsync();
           
        }

        public async Task<ICollection<ClickModel>> GetClicks()
        {
            return await this.context.UserClick.ToListAsync();
        }

        public async Task<ICollection<PaymentRequestModel>> GetPayments()
        {
           return await this.context.PaymentRequest.ToListAsync();
        }

        public async Task<AdsModel> InsertAds(AdsModel ads)
        {
            this.context.Ads.Add(ads);
             await this.context.SaveChangesAsync();
            return ads;
        }

        public async Task<ClickModel> InsertClicks(ClickModel click)
        {
           this.context.UserClick.Add(click);
           await this.context.SaveChangesAsync();
           return click;
        }

        public async Task<PaymentRequestModel> InsertPayments(PaymentRequestModel payment)
        {
            this.context.PaymentRequest.Add(payment);
            await this.context.SaveChangesAsync();
            return payment;
        }
    }
}