using AutoMapper;
using BR.Rodobens.Migration.Application.Apps.Core;
using BR.Rodobens.Migration.Application.Interfaces;
using BR.Rodobens.Migration.Application.ViewModels;
using BR.Rodobens.Migration.Domain.Aggregates.Costumers.Services;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal.Services;
using BR.Rodobens.Migration.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Application.Apps
{
    public class UserPersonalAppService : ApplicationService, IUserPersonalAppService
    {

        private readonly IMapper _mapper;
        private readonly IUserPersonalService _userPersonalService;


        public UserPersonalAppService(IMediator mediator,
                             INotificationHandler<DomainNotification> notifications,
                             IMapper mapper,
                             IUserPersonalService userPersonalService
                                     ) : base(mediator, notifications)
        {
            _mapper = mapper;
            _userPersonalService = userPersonalService;
         }
        public void InsertUserPersonal(UserPersonalModel userPersonal)
        {
            _userPersonalService.InsertUserPersonal(_mapper.Map<UserPersonal>(userPersonal));
        }

        public void UpdateUserPersonal(UserPersonalModel userPersonal)
        {
            _userPersonalService.UpdateUserPersonal(_mapper.Map<UserPersonal>(userPersonal));
        }

        public void DeleteUserPersonal(int id)
        {
            _userPersonalService.DeleteUserPersonal(id);
        }

        public UserPersonalModel GetById(int id)
        {
            return _mapper.Map<UserPersonalModel>(_userPersonalService.GetById(id));
        }

        public List<UserPersonalModel> GetAll()
        {
            return _mapper.Map<List<UserPersonalModel>>(_userPersonalService.GetAll());
        }

        public async Task Migrate()
        {
            await _userPersonalService.Migrate();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _userPersonalService.Dispose();
        }
    }
}
