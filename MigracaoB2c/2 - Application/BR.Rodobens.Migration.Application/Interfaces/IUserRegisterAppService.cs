using BR.Rodobens.Migration.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Application.Interfaces
{
    public interface IUserRegisterAppService : IDisposable
    {
        public void InsertUserRegister(UserRegisterModel userRegister);
        public void UpdateUserRegister(UserRegisterModel userRegister);
        public void DeleteUserRegister(int id);
        public UserRegisterModel GetById(int id);
        public List<UserRegisterModel> GetAll();
    }
}
