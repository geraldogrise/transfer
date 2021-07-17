using BR.Rodobens.Migration.Application.Apps;
using BR.Rodobens.Migration.Application.Interfaces;
using BR.Rodobens.Migration.Domain.Notifications;
using BR.Rodobens.Migration.Infra.CrossCutting.Log;
using BR.Rodobens.Migration.Infra.Data.Context;
using BR.Rodobens.Migration.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using BR.Rodobens.Migration.Domain.Aggregates.Costumers.Services;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType.Repository;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType.Services;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal.Repository;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal.Services;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister.Repository;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister.Services;


namespace BR.Rodobens.Migration.Infra.CrossCutting.Ioc
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ICostumerAppService, CostumerAppService>();
            services.AddScoped<IPartnerTypeAppService, PartnerTypeAppService>();
            services.AddScoped<IUserPersonalAppService, UserPersonalAppService>();
            services.AddScoped<IUserRegisterAppService, UserRegisterAppService>();

            // Domain
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Service
            services.AddSingleton<ILogger, Logger>();
            services.AddScoped<ICostumerService, CostumerService>();
            services.AddScoped<IPartnerTypeService, PartnerTypeService>();
            services.AddScoped<IUserPersonalService, UserPersonalService>();
            services.AddScoped<IUserRegisterService, UserRegisterService>();

            // Data
            services.AddScoped<DatabaseContext>();
            services.AddScoped<IPartnerTypeRepository, PartnerTypeRepository>();
            services.AddScoped<IUserPersonalRepository, UserPersonalRepository>();
            services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
        }
    }
}
