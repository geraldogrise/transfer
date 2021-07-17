using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BR.Rodobens.Migration.Infra.CrossCutting.Log
{
    public class Logger : ILogger
    {
        private readonly LoggerOptions _logOptions;

        public Logger(LoggerOptions logOptions)
        {
            _logOptions = logOptions;
        }
        public void WriteLog(Exception excecao)
        {
            string caminhoArquivoLog = _logOptions.TargetPath + DateTime.Now.ToString("ddMMyyyy") + "_" + Guid.NewGuid() + ".txt";

            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog))
            {
                streamWriter.WriteLine(excecao.Message);
                streamWriter.WriteLine(excecao.StackTrace);
                streamWriter.Close();
            }
        }
    }
}
