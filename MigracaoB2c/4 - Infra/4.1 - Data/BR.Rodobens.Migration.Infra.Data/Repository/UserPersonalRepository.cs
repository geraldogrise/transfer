using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal.Repository;
using BR.Rodobens.Migration.Infra.Data.Context;
using BR.Rodobens.Migration.Infra.Data.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BR.Rodobens.Migration.Infra.Data.Repository
{
    public class UserPersonalRepository : Repository<UserPersonal>, IUserPersonalRepository
    {
        public UserPersonalRepository(DatabaseContext context) : base(context)
        {

        }
        public List<UserPersonal> ListAll()
        {
            return _context.UserPersonals.Include("UserRegister")
                            .Include("UserRegister.PartnerType")
                            .Where(x=> x.Processado == ProcessadoEnum.No)
                            .ToList();
        }
    }
}
