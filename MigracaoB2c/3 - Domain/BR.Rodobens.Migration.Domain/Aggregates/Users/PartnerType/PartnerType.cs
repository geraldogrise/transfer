using BR.Rodobens.Migration.Domain.Aggregates.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType
{
    using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;
    public class PartnerType : EntityCore<PartnerType>
    {
        public virtual short PartnerTypeId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual List<UserRegister> UserRegisterList { get; set; }

        #region Validations
        public bool IsValid()
        {
            return base.IsValid(this);
        }
        #endregion
    }
}
