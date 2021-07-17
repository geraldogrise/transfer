using BR.Rodobens.Migration.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Application.Interfaces
{
    public interface IPartnerTypeAppService : IDisposable
    {
        public void InsertPartnerType(PartnerTypeModel partnerType);
        public void UpdatePartnerType(PartnerTypeModel partnerType);
        public void DeletePartnerType(int id);
        public PartnerTypeModel GetById(int id);
        public List<PartnerTypeModel> GetAll();
    }
}
