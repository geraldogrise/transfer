using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Application.ViewModels
{
    public class CostumerModel
    {
        public string Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string PartnerType { get; set; }
    }
}
