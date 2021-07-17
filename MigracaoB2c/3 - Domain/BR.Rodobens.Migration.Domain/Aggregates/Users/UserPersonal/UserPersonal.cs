using BR.Rodobens.Migration.Domain.Aggregates.Core;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal
{
    using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;
    public class UserPersonal : EntityCore<UserPersonal>
    {
        public virtual string Id { get; set; }
        public virtual int UserPersonalId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual int UserRegisterId { get; set; }
        public virtual UserRegister UserRegister { get; set; }
        public virtual ProcessadoEnum Processado { get; set; }

        #region Validations
        public bool IsValid()
        {
            return base.IsValid(this);
        }
        #endregion
    }
}
