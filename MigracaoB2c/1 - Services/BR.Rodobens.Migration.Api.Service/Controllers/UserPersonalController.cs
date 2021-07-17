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
    public class UserPersonalController : BaseController
    {
        private readonly IUserPersonalAppService _userPersonalAppService;

        public UserPersonalController(INotificationHandler<DomainNotification> notifications,
                                               IMediator mediator,
                                               IUserPersonalAppService userPersonalAppService) : base(notifications, mediator)
        {
            _userPersonalAppService = userPersonalAppService;
        }

        [HttpGet]
        [Route("GetUserPersonal")]
        public IActionResult GetUserPersonal(int id)
        {
            try
            {
                return Response(_userPersonalAppService.GetById(id));
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }

        [HttpGet]
        [Route("GetUserPersonals")]
        public IActionResult GetUserPersonals()
        {
            try
            {
                return Response(_userPersonalAppService.GetAll());
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }

        [HttpGet]
        [Route("Migrate")]
        public async Task<IActionResult> MigrateB2C()
        {
            try
            {
                await _userPersonalAppService.Migrate();
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
