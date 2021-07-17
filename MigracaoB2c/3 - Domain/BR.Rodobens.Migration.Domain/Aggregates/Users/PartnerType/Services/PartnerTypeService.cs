using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType.Repository;
using BR.Rodobens.Migration.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType.Services
{
    public class PartnerTypeService : Service, IPartnerTypeService
    {
        private readonly IPartnerTypeRepository _partnerTypeRepository;
        public PartnerTypeService(IMediator mediator,
                                   IPartnerTypeRepository partnerTypeRepository
            ) : base(mediator)
        {
            _partnerTypeRepository = partnerTypeRepository;
        }


        public void InsertPartnerType(PartnerType partnerType)
        {
            if (partnerType.IsValid())
            {
                _partnerTypeRepository.Add(partnerType);
                _partnerTypeRepository.SaveChanges();
            }
        }
        public void UpdatePartnerType(PartnerType partnerType)
        {
            if (partnerType.IsValid())
            {
                _partnerTypeRepository.Update(partnerType);
                _partnerTypeRepository.SaveChanges();
            }
        }

        public void DeletePartnerType(int id)
        {
            _partnerTypeRepository.Remove(GetById(id));
            _partnerTypeRepository.SaveChanges();
        }

        public PartnerType GetById(int id)
        {
            return _partnerTypeRepository.Find(x => x.PartnerTypeId == id).FirstOrDefault();
        }

        public List<PartnerType> GetAll()
        {
            return _partnerTypeRepository.GetAll().ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _partnerTypeRepository.Dispose();
        }
    }
}
