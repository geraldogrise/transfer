using System;

namespace BR.ITAU.TRANSFER.Infra.CrossCutting.Log
{
    public interface ILogger
    {
        void writeLog(Exception excecao);
    }
}
