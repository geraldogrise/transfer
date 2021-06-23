using AutoMapper;
using BR.ITAU.TRANSFER.API.Application.Apps.Core;
using BR.ITAU.TRANSFER.API.Application.Interfaces;
using BR.ITAU.TRANSFER.API.Application.ViewModels;
using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva;
using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva.Services;
using BR.ITAU.TRANSFER.API.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.ITAU.TRANSFER.API.Application.Apps
{
    public class CurvaAppService : ApplicationService, ICurvaAppService
    {
        private readonly IMapper _mapper;

        private readonly ICurvaService _curvaService;

        public CurvaAppService(IMediator mediator,
                               INotificationHandler<DomainNotification> notifications,
                               IMapper mapper,
                               ICurvaService curvaService
                                       ) : base(mediator, notifications)
        {
            _mapper = mapper;
            _curvaService = curvaService;
        }
		
		public void InserirCurva(CurvaModel curva)
		{
			_curvaService.InserirCurva(_mapper.Map<Curva>(curva));
		}

		public void AtualizarCurva(CurvaModel curva)
		{
			_curvaService.AtualizarCurva(_mapper.Map<Curva>(curva));
		}

		public void DeletarCurva(int codigoCurva)
		{
			_curvaService.DeletarCurva(codigoCurva);
		}

		public CurvaModel ObterCurva(int codigoCurva)
		{
			return _mapper.Map<CurvaModel>(_curvaService.ObterCurva(codigoCurva));
		}

		public List<CurvaModel> ListarCurva( )
		{
			return _mapper.Map<List<CurvaModel>>(_curvaService.ListarCurva());
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			Dispose(true);
		}
		protected virtual void Dispose(bool disposing)
		{

			_curvaService.Dispose();
		}

    }
}