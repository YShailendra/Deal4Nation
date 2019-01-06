using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Helper;
using Products.Models;
using Products.Repository;
using Products.Repository.User;

namespace Products.ViewModels
{
    public class UserViewModel:BaseViewModel
    {
        #region Private Variables 
        public IUserRepository _repo {get; set;}
        #endregion
        public UserViewModel(IUserRepository repo)
        {
            this._repo=repo;
        }
        public UserViewModel()
        {

        }
        public async Task<UserModel> RegisterUser(UserModel data)
        {
            data.ID= Guid.NewGuid();
            data.Password = AppHelper.Instance.GetHash(data.Password); 
            var result =this._repo.Add(data);
            return await result;
        }
        public async Task<UserModel> UpdateUser(UserModel data)
        {
            var result = this._repo.Update(data);
            return await result;
        }
        public async Task<UserModel> DeleteUser(string id)
        {
            return await this._repo.Remove(id);
        }
        public async Task<List<UserModel>> GetUsers()
        {     
            return await this._repo.GetAll() as List<UserModel>;
        }

        public async Task<LoginModel> Login(LoginModel data)
        {
            
            if (!string.IsNullOrEmpty(data.Username) &&
           !string.IsNullOrEmpty(data.Password))
            {
                var user = await this._repo.GetByEmailOrNumber(data.Username);
                data.Password = AppHelper.Instance.GetHash(data.Password);
                if (user != null)
                {
                    if(data.Password == user.Password)
                    {
                        data.Token = new JwtTokenBuilder()
                                                        .AddSecurityKey(JwtSecurityKey.Create(user.ID.ToString()))
                                                        .AddSubject(user.Email)
                                                        .AddIssuer("Security.Bearer")
                                                        .AddAudience("Security.Bearer")
                                                        // .AddClaim("IsAdmin", user.IsAdmin)
                                                        .AddExpiry(5)
                                                        .Build().ToString();
                       
                    }
                  
                }
            
            }
            return data;
        } 
        public async Task<string> ForgetPassword(string email){
           var result = await this._repo.GetByEmailOrNumber(email);
            if(result!=null)
            {
                result.Otp= base.GenerateTicketNumber().Substring(8);
                await this._repo.Update(result);
                this.SendForgetPasswordMail(email,result.Otp);
                return "Otp sent over email";
            }
            else {
                return "Inavalid Email";
            }
        }
        public async Task<LoginModel> ChangePassword(ChangePasswordModel data){
            var user = await this._repo.Find(data.UserId.ToString());
            var result = new LoginModel();
            if (user != null)
            {
                result.Password = data.NewPassword;
                result.Username = user.Email;
                if (data.NewPassword == data.ConfirmPassword)
                {

                    user.Password = AppHelper.Instance.GetHash(data.NewPassword);
                    await this._repo.Update(user);
                    return await this.Login(result);
                }
                else
                {
                    result.Token = "Password didnot match";
                }
            }
            return result;
        }
        public async Task<string> VerifyOtp(ChangePasswordModel data){
             var user = await this._repo.Find(data.UserId.ToString());
             if(user.Otp==data.Otp)
             {
                 return "Otp Verified";
             }
             return "Wrong Otp";
        }


        #region Private Methods
        private void SendForgetPasswordMail(string email,string otp)
        {
            string subject="Forget Password OTP";
            string body=string.Format("Your OTP is {0}.",otp);
            EmailHelper.SendMail(email,body,subject);
        }
        #endregion
    }
}