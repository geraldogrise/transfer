using AutoMapper;
using BR.ITAU.TRANSFER.API.Application.ViewModels;
using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva;


namespace BR.ITAU.TRANSFER.API.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
		    
			CreateMap<CurvaModel, Curva>();
        }
    }
}