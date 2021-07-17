using BR.Rodobens.Migration.Domain.Aggregates.Core;
using System.Collections.Generic;


namespace BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister
{
    using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType;
    using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal;
  
    public class UserRegister : EntityCore<UserRegister>
    {
        public virtual int UserRegisterId { get; set; }
        public virtual string Login { get; set; }
        public virtual short PartnerTypeId { get; set; }
        public virtual PartnerType PartnerType { get; set; }
        public virtual List<UserPersonal> UserPersonalList { get; set; }

        #region Validations
        public bool IsValid()
        {
            return base.IsValid(this);
        }
        #endregion
    }
}
