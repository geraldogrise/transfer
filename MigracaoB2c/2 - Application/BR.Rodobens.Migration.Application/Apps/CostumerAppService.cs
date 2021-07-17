using AutoMapper;
using BR.Rodobens.Migration.Application.Apps.Core;
using BR.Rodobens.Migration.Application.Interfaces;
using BR.Rodobens.Migration.Application.ViewModels;
using BR.Rodobens.Migration.Domain.Aggregates.Costumers;
using BR.Rodobens.Migration.Domain.Aggregates.Costumers.Services;
using BR.Rodobens.Migration.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BR.Rodobens.Migration.Application.Apps
{
    public class CostumerAppService : ApplicationService, ICostumerAppService
    {

        private readonly IMapper _mapper;
        private readonly ICostumerService _costumerService;

        public CostumerAppService(IMediator mediator,
                             INotificationHandler<DomainNotification> notifications,
                             IMapper mapper,
                             ICostumerService costumerService
                                     ) : base(mediator, notifications)
        {
            _mapper = mapper;
            _costumerService = costumerService;
        }

        public async Task InsertCostumer(CostumerModel costumer)
        {
            await _costumerService.InsertCostumer(_mapper.Map<Costumer>(costumer));
        }
        public async Task UpdatePassword(CostumerPassword costumer)
        {
           await _costumerService.UpdatePassword(costumer.Id, costumer.Password);
        }
        public async Task DeleteCostumer(string id)
        {
           await _costumerService.DeleteCostumer(id);
        }

        public CostumerModel GetById(string id)
        {
            return _mapper.Map<CostumerModel>(_costumerService.GetById(id));
        }

        public async Task<List<CostumerModel>> GetAll()
        {
            var result = await _costumerService.GetAll();
            return _mapper.Map<List<CostumerModel>>(result);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _costumerService.Dispose();
        }


    }
}
