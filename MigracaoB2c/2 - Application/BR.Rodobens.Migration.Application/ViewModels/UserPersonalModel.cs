using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Application.ViewModels
{
    public class UserPersonalModel
    {
        public string Id { get; set; }
        public int UserPersonalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public int UserRegisterId { get; set; }
    }
}
