using AutoMapper;
using BR.ITAU.TRANSFER.API.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BR.ITAU.TRANSFER.API.Services.Configuration
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
