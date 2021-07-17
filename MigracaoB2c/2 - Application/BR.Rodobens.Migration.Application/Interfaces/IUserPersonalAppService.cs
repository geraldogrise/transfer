using BR.Rodobens.Migration.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Application.Interfaces
{
    public interface IUserPersonalAppService : IDisposable
    {
        public void InsertUserPersonal(UserPersonalModel userPersonal);
        public void UpdateUserPersonal(UserPersonalModel userPersonal);
        public void DeleteUserPersonal(int id);
        public UserPersonalModel GetById(int id);
        public List<UserPersonalModel> GetAll();
        public Task Migrate();
    }
}
