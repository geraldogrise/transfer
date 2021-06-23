using BR.ITAU.TRANSFER.Infra.CrossCutting.Log;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BR.ITAU.TRANSFER.API.Services.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                 _logger.writeLog(context.Exception);
            }
        }
    }
}
