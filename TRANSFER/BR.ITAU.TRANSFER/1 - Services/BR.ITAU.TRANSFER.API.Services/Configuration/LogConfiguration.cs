using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using BR.ITAU.TRANSFER.Infra.CrossCutting.Log;

namespace BR.ITAU.TRANSFER.API.Services.Configuration
{
    public static class LogConfiguration
    {
        public static void AddLoggerService(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var LoggerOptions = new LoggerOptions();
            new ConfigureFromConfigurationOptions<LoggerOptions>(configuration.GetSection("LogOptions"))
                .Configure(LoggerOptions);

            services.AddSingleton(LoggerOptions);
        }
    }
}