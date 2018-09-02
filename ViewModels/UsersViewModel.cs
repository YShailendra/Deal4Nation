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
    }
}