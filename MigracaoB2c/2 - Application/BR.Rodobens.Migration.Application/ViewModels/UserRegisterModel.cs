using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Application.ViewModels
{
    public class UserRegisterModel
    {
        public int UserRegisterId { get; set; }
        public string Login { get; set; }
        public short PartnerTypeId { get; set; }
    }
}
