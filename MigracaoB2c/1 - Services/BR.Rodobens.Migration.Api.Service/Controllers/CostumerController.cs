using BR.Rodobens.Migration.Api.Service.Controllers.Core;
using BR.Rodobens.Migration.Application.Apps;
using BR.Rodobens.Migration.Application.Interfaces;
using BR.Rodobens.Migration.Application.ViewModels;
using BR.Rodobens.Migration.Domain.Exceptions;
using BR.Rodobens.Migration.Domain.Notifications;
using BR.Rodobens.Migration.Infra.CrossCutting.GraphSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Api.Service.Controllers
{
    public class CostumerController : BaseController
    {

        private readonly ICostumerAppService _costumerAppService;
        public CostumerController(
            INotificationHandler<DomainNotification> notifications,
            IMediator mediator,
            ICostumerAppService costumerAppService
            ) : base(notifications, mediator)
        {
            _costumerAppService = costumerAppService;
        }


        [HttpGet]
        [Route("GetCostumer")]
        public IActionResult GetCostumer(string id)
        {
            try
            {
                return Response(_costumerAppService.GetById(id));
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }

        [HttpGet]
        [Route("GetCostumers")]
        public IActionResult GetCostumers()
        {
            try
            {
                return Response(_costumerAppService.GetAll());
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }

        [HttpPost]
        [Route("InsertCostumer")]
        public  async Task<IActionResult> InsertCostumer([FromBody] CostumerModel action)
        {
            try
            {
                if (action == null)
                {
                    RaiseError("!");
                }
                await _costumerAppService.InsertCostumer(action);
                return Response();
            }
            catch (ValidationException ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null, "warning");
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }

        [HttpPatch]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePaasword([FromBody] CostumerPassword costumer)
        {
            try
            {
                await  _costumerAppService.UpdatePassword(costumer);
                return Response();
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }

        [HttpDelete]
        [Route("DeleteCostumer")]
        public async Task<IActionResult> DeleteCostumer(string id)
        {
            try
            {
                await  _costumerAppService.DeleteCostumer(id);
                return Response();
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }
    }
}
