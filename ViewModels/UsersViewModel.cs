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
    public class UserViewModel
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

        public async Task<List<UserModel>> GetUsers()
        {     
            return await this._repo.GetAll() as List<UserModel>;
        }

        public async Task<LoginModel> Login(LoginModel data)
        {
            
            if (!string.IsNullOrEmpty(data.Username) &&
           !string.IsNullOrEmpty(data.Password))
            {
                var user = this._repo.GetByEmailOrNumber(data.Username).Result;
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
                        // return Ok(token);
                       
                    }
                  
                }
            
            }
            return data;
        } 
    }
}