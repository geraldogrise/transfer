using AutoMapper;
using BR.Rodobens.Migration.Application.ViewModels;
using BR.Rodobens.Migration.Domain.Aggregates.Costumers;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;


namespace BR.Rodobens.Migration.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Costumer, CostumerModel>();
            CreateMap<PartnerType, PartnerTypeModel>();
            CreateMap<UserPersonal, UserPersonalModel>();
            CreateMap<UserRegister, UserRegisterModel>();
        }
    }
}
