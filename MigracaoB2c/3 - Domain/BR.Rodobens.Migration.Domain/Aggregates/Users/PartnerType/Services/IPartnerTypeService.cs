using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType.Services
{
    public interface IPartnerTypeService : IDisposable
    {
        public void InsertPartnerType(PartnerType partnerType);
        public void UpdatePartnerType(PartnerType partnerType);
        public void DeletePartnerType(int id);
        public PartnerType GetById(int id);
        public List<PartnerType> GetAll();
    }
}
