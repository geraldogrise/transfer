using AutoMapper;
using BR.ITAU.TRANSFER.API.Application.ViewModels;
using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva;


namespace BR.ITAU.TRANSFER.API.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            
			CreateMap<Curva, CurvaModel>();
        }
    }
}