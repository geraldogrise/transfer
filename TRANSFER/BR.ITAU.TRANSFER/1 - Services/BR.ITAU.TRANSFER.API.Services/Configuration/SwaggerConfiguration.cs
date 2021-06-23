using BR.ITAU.TRANSFER.API.Services.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace BR.ITAU.TRANSFER.API.Services.Configuration
{
    public static class SwaggerConfiguration
    {    
        public static void AddSwaggerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerOptions = new SwaggerOptions();
            new ConfigureFromConfigurationOptions<SwaggerOptions>(configuration.GetSection("SwaggerOptions"))
                .Configure(swaggerOptions);

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Software Express",
                        Version = "v1",
                        Description = "Software Express API",
                        Contact = new OpenApiContact
                        {
                            Name = "Geraldo Grise",
                            Url = new Uri("http://grisrcorp.com")
                        }
                    });
            });

        }
    }
}