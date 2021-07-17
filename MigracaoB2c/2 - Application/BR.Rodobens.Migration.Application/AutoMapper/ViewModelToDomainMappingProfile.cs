using AutoMapper;
using BR.Rodobens.Migration.Application.ViewModels;
using BR.Rodobens.Migration.Domain.Aggregates.Costumers;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;

namespace BR.Rodobens.Migration.Application.AutoMapper
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CostumerModel,Costumer>();
            CreateMap<PartnerTypeModel, PartnerType>();
            CreateMap<UserPersonalModel, UserPersonal>();
            CreateMap<UserRegisterModel, UserRegister>();
        }
    }
}
