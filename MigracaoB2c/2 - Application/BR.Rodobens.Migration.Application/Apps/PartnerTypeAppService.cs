using AutoMapper;
using BR.Rodobens.Migration.Application.Apps.Core;
using BR.Rodobens.Migration.Application.Interfaces;
using BR.Rodobens.Migration.Application.ViewModels;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType.Services;
using BR.Rodobens.Migration.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Application.Apps
{
    public class PartnerTypeAppService : ApplicationService, IPartnerTypeAppService
    {

        private readonly IMapper _mapper;

        private readonly IPartnerTypeService _partnerTypeService;

        public PartnerTypeAppService(IMediator mediator,
                             INotificationHandler<DomainNotification> notifications,
                             IMapper mapper,
                             IPartnerTypeService partnerTypeService
                                     ) : base(mediator, notifications)
        {
            _mapper = mapper;
            _partnerTypeService = partnerTypeService;
        }
        public void InsertPartnerType(PartnerTypeModel partnerType)
        {
            _partnerTypeService.InsertPartnerType(_mapper.Map<PartnerType>(partnerType));
        }

        public void UpdatePartnerType(PartnerTypeModel partnerType)
        {
            _partnerTypeService.UpdatePartnerType(_mapper.Map<PartnerType>(partnerType));
        }

        public void DeletePartnerType(int id)
        {
            _partnerTypeService.DeletePartnerType(id);
        }

        public PartnerTypeModel GetById(int id)
        {
            return _mapper.Map<PartnerTypeModel>(_partnerTypeService.GetById(id));
        }

        public List<PartnerTypeModel> GetAll()
        {
            return _mapper.Map<List<PartnerTypeModel>>(_partnerTypeService.GetAll());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _partnerTypeService.Dispose();
        }
    }
}
