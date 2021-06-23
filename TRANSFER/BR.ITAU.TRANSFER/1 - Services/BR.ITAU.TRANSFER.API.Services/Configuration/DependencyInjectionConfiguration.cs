using MediatR;
using Microsoft.Extensions.DependencyInjection;
using BR.ITAU.TRANSFER.API.Services.Middlewares;
using BR.ITAU.TRANSFER.Infra.CrossCutting.Ioc;

namespace BR.ITAU.TRANSFER.API.Services.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            BootStrapper.RegisterServices(services);           

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MediatorMiddleware<,>));
        }
    }
}
