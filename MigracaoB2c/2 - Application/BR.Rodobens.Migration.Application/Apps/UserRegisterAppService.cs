using AutoMapper;
using BR.Rodobens.Migration.Application.Apps.Core;
using BR.Rodobens.Migration.Application.Interfaces;
using BR.Rodobens.Migration.Application.ViewModels;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister.Services;
using BR.Rodobens.Migration.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Application.Apps
{
    public class UserRegisterAppService : ApplicationService, IUserRegisterAppService
    {

        private readonly IMapper _mapper;

        private readonly IUserRegisterService _userRegisterService;

        public UserRegisterAppService(IMediator mediator,
                             INotificationHandler<DomainNotification> notifications,
                             IMapper mapper,
                             IUserRegisterService userRegisterService
                                     ) : base(mediator, notifications)
        {
            _mapper = mapper;
            _userRegisterService = userRegisterService;
        }
        public void InsertUserRegister(UserRegisterModel userRegister)
        {
            _userRegisterService.InsertUserRegister(_mapper.Map<UserRegister>(userRegister));
        }

        public void UpdateUserRegister(UserRegisterModel userRegister)
        {
            _userRegisterService.UpdateUserRegister(_mapper.Map<UserRegister>(userRegister));
        }

        public void DeleteUserRegister(int id)
        {
            _userRegisterService.DeleteUserRegister(id);
        }

        public UserRegisterModel GetById(int id)
        {
            return _mapper.Map<UserRegisterModel>(_userRegisterService.GetById(id));
        }

        public List<UserRegisterModel> GetAll()
        {
            return _mapper.Map<List<UserRegisterModel>>(_userRegisterService.GetAll());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _userRegisterService.Dispose();
        }
    }
}
