using BR.Rodobens.Migration.Domain.Interfaces;
using System.Collections.Generic;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal.Repository
{
    public interface IUserPersonalRepository : IRepository<UserPersonal>
    {
        public List<UserPersonal> ListAll();
    }
}