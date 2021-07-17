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
    public class UserRegisterController : BaseController
    {
        private readonly IUserRegisterAppService _userRegisterAppService;

        public UserRegisterController(INotificationHandler<DomainNotification> notifications,
                                               IMediator mediator,
                                               IUserRegisterAppService userRegisterAppService) : base(notifications, mediator)
        {
            _userRegisterAppService = userRegisterAppService;
        }

        [HttpGet]
        [Route("GetUserRegister")]
        public IActionResult GetUserRegister(int id)
        {
            try
            {
                return Response(_userRegisterAppService.GetById(id));
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }

        [HttpGet]
        [Route("GetUserRegisters")]
        public IActionResult GetUserRegisters()
        {
            try
            {
                return Response(_userRegisterAppService.GetAll());
            }
            catch (Exception ex)
            {
                RaiseError(ex.Message);
                return Response(null, ex.Message, null);
            }
        }
    }
}
