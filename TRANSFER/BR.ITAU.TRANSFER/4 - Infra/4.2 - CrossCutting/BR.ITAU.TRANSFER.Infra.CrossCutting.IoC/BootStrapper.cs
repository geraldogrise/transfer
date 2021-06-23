using MediatR;
using Microsoft.Extensions.DependencyInjection;

using BR.ITAU.TRANSFER.API.Application.Apps;
using BR.ITAU.TRANSFER.API.Application.Interfaces;
using BR.ITAU.TRANSFER.API.Domain.Notifications;
using BR.ITAU.TRANSFER.Infra.CrossCutting.Log;
using BR.ITAU.TRANSFER.Infra.Data.Context;
using BR.ITAU.TRANSFER.Infra.Data.Repository;

using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva.Repository;

using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva.Services;

namespace BR.ITAU.TRANSFER.Infra.CrossCutting.Ioc
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
			services.AddScoped<ICurvaAppService,CurvaAppService >();
            // Integração
			
            // Domain
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // Service
    	    services.AddSingleton<ILogger, Logger>();
			services.AddScoped<ICurvaService,CurvaService >();
            // Data
			services.AddScoped<DatabaseContext>();
			services.AddScoped<ICurvaRepository,CurvaRepository >();
        }
    }
}