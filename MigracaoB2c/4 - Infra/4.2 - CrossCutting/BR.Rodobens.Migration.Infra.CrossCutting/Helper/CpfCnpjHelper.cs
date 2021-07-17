using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Infra.CrossCutting.Helper
{
    public static class CpfCnpjHelper
    {
        public static string FormatCpfCnpj(string value)
        {
            string replacements = ".-";
            if (value == null) return string.Empty;
            foreach (var ch in replacements.ToCharArray())
            {
                value = value.Replace(ch.ToString(), "");
            }
            return value;
        }
    }
}
