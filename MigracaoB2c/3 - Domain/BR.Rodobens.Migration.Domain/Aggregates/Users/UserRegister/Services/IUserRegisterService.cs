using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister.Services
{
    public interface IUserRegisterService : IDisposable
    {
        public void InsertUserRegister(UserRegister userRegister);
        public void UpdateUserRegister(UserRegister userRegister);
        public void DeleteUserRegister(int id);
        public UserRegister GetById(int id);
        public List<UserRegister> GetAll();
    }
}
