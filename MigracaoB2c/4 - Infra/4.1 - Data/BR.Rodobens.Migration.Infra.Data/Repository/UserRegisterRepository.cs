using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister.Repository;
using BR.Rodobens.Migration.Infra.Data.Context;
using BR.Rodobens.Migration.Infra.Data.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BR.Rodobens.Migration.Infra.Data.Repository
{
    public class UserRegisterRepository : Repository<UserRegister>, IUserRegisterRepository
    {
        public UserRegisterRepository(DatabaseContext context) : base(context)
        {

        }

    }
}
