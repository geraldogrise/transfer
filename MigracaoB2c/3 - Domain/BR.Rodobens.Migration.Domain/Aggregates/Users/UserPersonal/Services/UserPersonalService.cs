using BR.Rodobens.Migration.Domain.Aggregates.Costumers.Services;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal.Repository;
using BR.Rodobens.Migration.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal.Services
{
    using BR.Rodobens.Migration.Domain.Aggregates.Costumers;
    using System.Threading.Tasks;

    public class UserPersonalService : Service, IUserPersonalService
    {
        private readonly IUserPersonalRepository _userPersonalRepository;
        private readonly ICostumerService _costumerService;
        public UserPersonalService(IMediator mediator,
                                   IUserPersonalRepository userPersonalRepository,
                                   ICostumerService costumerService
            ) : base(mediator)
        {
            _userPersonalRepository = userPersonalRepository;
            _costumerService =  costumerService;
        }


        public void InsertUserPersonal(UserPersonal userPersonal)
        {
            if (userPersonal.IsValid())
            {
                _userPersonalRepository.Add(userPersonal);
                _userPersonalRepository.SaveChanges();
            }
        }
        public void UpdateUserPersonal(UserPersonal userPersonal)
        {
            if (userPersonal.IsValid())
            {
                _userPersonalRepository.Update(userPersonal);
                _userPersonalRepository.SaveChanges();
            }
        }

        public void DeleteUserPersonal(int id)
        {
            _userPersonalRepository.Remove(GetById(id));
            _userPersonalRepository.SaveChanges();
        }

        public UserPersonal GetById(int id)
        {
            return _userPersonalRepository.Find(x => x.UserPersonalId == id).FirstOrDefault();
        }

        public List<UserPersonal> GetAll()
        {
            return _userPersonalRepository.GetAll().ToList();
        }

        public async Task Migrate()
        {
            List<UserPersonal> users =  _userPersonalRepository.ListAll().Take(3).ToList(); 
            foreach (var user in users)
            {
                Costumer costumer =  GetUsersB2C(user);
                user.Id =  _costumerService.InsertCostumer(costumer).Result;
                ProcessUser(user);
            }
        }

        public void ProcessUser(UserPersonal user)
        {
            user.Processado = ProcessadoEnum.Yes;
            UpdateUserPersonal(user);
        }

        private Costumer GetUsersB2C(UserPersonal userPersonal)
        {
            var nameArray = userPersonal.Name.Split(" ");
            return new Costumer()
            {
                DisplayName = userPersonal.Name,
                GivenName = nameArray[0],
                Surname = nameArray.Length > 1 ? nameArray[1] : userPersonal.Name,
                Email = userPersonal.Email,
                Cpf = userPersonal.Cpf,
                Cnpj = userPersonal.Cnpj,
                PartnerType = userPersonal.UserRegister.PartnerType.Name
            };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _userPersonalRepository.Dispose();
        }
    }

}
