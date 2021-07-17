using AutoMapper;
using BR.Rodobens.Migration.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BR.Rodobens.Migration.Api.Service.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMappings();
        }
    }
}
