using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister.Repository;
using BR.Rodobens.Migration.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister.Services
{
    public class UserRegisterService : Service, IUserRegisterService
    {
        private readonly IUserRegisterRepository _userRegisterRepository;
        public UserRegisterService(IMediator mediator,
                                   IUserRegisterRepository userRegisterRepository
            ) : base(mediator)
        {
            _userRegisterRepository = userRegisterRepository;
        }


        public void InsertUserRegister(UserRegister userRegister)
        {
            if (userRegister.IsValid())
            {
                _userRegisterRepository.Add(userRegister);
                _userRegisterRepository.SaveChanges();
            }
        }
        public void UpdateUserRegister(UserRegister userRegister)
        {
            if (userRegister.IsValid())
            {
                _userRegisterRepository.Update(userRegister);
                _userRegisterRepository.SaveChanges();
            }
        }

        public void DeleteUserRegister(int id)
        {
            _userRegisterRepository.Remove(GetById(id));
            _userRegisterRepository.SaveChanges();
        }

        public UserRegister GetById(int id)
        {
            return _userRegisterRepository.Find(x => x.UserRegisterId == id).FirstOrDefault();
        }

        public List<UserRegister> GetAll()
        {
            return _userRegisterRepository.GetAll().ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _userRegisterRepository.Dispose();
        }
    }

}
