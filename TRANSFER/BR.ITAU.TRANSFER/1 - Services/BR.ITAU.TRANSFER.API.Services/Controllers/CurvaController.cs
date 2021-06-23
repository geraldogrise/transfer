namespace BR.ITAU.TRANSFER.API.Services.Controllers
{
    using BR.ITAU.TRANSFER.API.Application.Interfaces;
    using BR.ITAU.TRANSFER.API.Application.ViewModels;
    using BR.ITAU.TRANSFER.API.Domain.Notifications;
    using BR.ITAU.TRANSFER.API.Services.Controllers.Core;
    using BR.ITAU.TRANSFER.API.Domain.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;

    /// <summary>
    /// Claase para controller da API
    /// </summary>
    [Route("api")]
    public class CurvaController : BaseController
    {
        private readonly ICurvaAppService _curvaAppService;

        public CurvaController(INotificationHandler<DomainNotification> notifications,
                                               IMediator mediator,
                                               ICurvaAppService curvaAppService) : base(notifications, mediator)
        {
            _curvaAppService = curvaAppService;
        }
        
		[HttpPost]
		[Route("InserirCurva")]
		public IActionResult InserirCurva([FromBody] CurvaModel curva)
		{
			try
			{
				_curvaAppService.InserirCurva(curva);
				return Response();
			}
			catch (Exception ex)
			{
				RaiseError(ex.Message);
				return Response(null, ex.Message, null);
			}
		}

		[HttpPost]
		[Route("AtualizarCurva")]
		public IActionResult AtualizarCurva([FromBody] CurvaModel curva)
		{
			try
			{
				_curvaAppService.AtualizarCurva(curva);
				return Response();
			}
			catch (Exception ex)
			{
				RaiseError(ex.Message);
				return Response(null, ex.Message, null);
			}
		}

		[HttpPost]
		[Route("DeletarCurva")]
		public IActionResult DeletarCurva([FromBody] int codigoCurva)
		{
			try
			{
				_curvaAppService.DeletarCurva(codigoCurva);
				return Response();
			}
			catch (Exception ex)
			{
				RaiseError(ex.Message);
				return Response(null, ex.Message, null);
			}
		}

		[HttpGet]
		[Route("ObterCurva")]
		public IActionResult ObterCurva(int codigoCurva)
		{
			try
			{
				return Response(_curvaAppService.ObterCurva(codigoCurva));
			}
			catch (Exception ex)
			{
				RaiseError(ex.Message);
				return Response(null, ex.Message, null);
			}
		}

		[HttpGet]
		[Route("ListarCurva")]
		public IActionResult ListarCurva()
		{
			try
			{
				return Response(_curvaAppService.ListarCurva());
			}
			catch (Exception ex)
			{
				RaiseError(ex.Message);
				return Response(null, ex.Message, null);
			}
		}

    }
}