using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Infra.CrossCutting.Log
{
    public interface ILogger
    {
        void WriteLog(Exception excecao);
    }
}
