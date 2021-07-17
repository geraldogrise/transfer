using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType.Repository;
using BR.Rodobens.Migration.Infra.Data.Context;
using BR.Rodobens.Migration.Infra.Data.Core.Repository;

namespace BR.Rodobens.Migration.Infra.Data.Repository
{
    public class PartnerTypeRepository : Repository<PartnerType>, IPartnerTypeRepository
    {
        public PartnerTypeRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
