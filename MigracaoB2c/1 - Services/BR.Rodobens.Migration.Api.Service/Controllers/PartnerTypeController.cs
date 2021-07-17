using BR.Rodobens.Migration.Api.Service.Controllers.Core;
using BR.Rodobens.Migration.Application.Interfaces;
using BR.Rodobens.Migration.Application.ViewModels;
using BR.Rodobens.Migration.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Api.Service.Controllers
{
    public class PartnerTypeController : BaseController
    {
        private readonly IPartnerTypeAppService _partnerTypeAppService;

        public PartnerTypeController(INotificationHandler<DomainNotification> notifications,
                                               IMediator mediator,
                                               IPartnerTypeAppService partnerTypeAppService) : base(notifications, mediator)
        {
            _partnerTypeAppService = partnerTypeAppService;
        }

        [HttpGet]
        [Route("GetPartnerType")]
        public IActionResult GetPartnerType(int id)
        {
            try
            {
                return Response(_partnerTypeAppService.GetById(id));
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }

        [HttpGet]
        [Route("GetPartnerTypes")]
        public IActionResult GetPartnerTypes()
        {
            try
            {
                return Response(_partnerTypeAppService.GetAll());
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }
    }
}
