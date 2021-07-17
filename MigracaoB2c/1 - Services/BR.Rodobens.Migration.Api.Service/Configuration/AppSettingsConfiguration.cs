using BR.Rodobens.Migration.Infra.CrossCutting.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace BR.Rodobens.Migration.Api.Service.Configuration
{
    public static class AppSettingsConfiguration
    {
        public static void AddAcessoService(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var AcessoOptions = new AccessOptions();
            new ConfigureFromConfigurationOptions<AccessOptions>(configuration.GetSection("AccessConfiguration"))
                .Configure(AcessoOptions);

            services.AddSingleton(AcessoOptions);
        }
    }
}
