using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal.Services
{
    public interface IUserPersonalService : IDisposable
    {
        public void InsertUserPersonal(UserPersonal userPersonal);
        public void UpdateUserPersonal(UserPersonal userPersonal);
        public void DeleteUserPersonal(int id);
        public UserPersonal GetById(int id);
        public List<UserPersonal> GetAll();
        public Task Migrate();
    }
}
