using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Infra.CrossCutting.GraphSettings
{
    public class GraphOptions
    {
        public string TenantId { get; set; }
        public string AppId { get; set; }
        public string ClientSecret { get; set; }
        public string B2cExtensionAppClientId { get; set; }
    }
}
