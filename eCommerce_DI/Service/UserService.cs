using ECommerce_Commons.Enumerators;
using ECommerce_Commons.Utilitaries;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Domain.Service
{
    public class UserService : IUserService, IDisposable
    {
        readonly IUserAddressService _userAddressService;
        readonly IUserRepository _baseRepository;

        public UserService(IUserRepository repository, IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
            _baseRepository = repository;
        }

        public bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType, ref string ErrorMessage)
        {
            User user = _baseRepository.Find(x => x.UserName == userName).FirstOrDefault();

            if (user == null)
            {
                ErrorMessage = "User not found";
                return false;
            }

            if (!user.HasAccess(LoginType, ref ErrorMessage))
            {
                return false;
            }

            password = CriptoUtilitary.sha256encrypt(password);

            bool isValid = user.Password.Equals(password);

            ErrorMessage = isValid ? string.Empty : "Username or passaword are incorrect";

            return isValid;
        }

        public User Save(User user)
        {
            if (user.Id == 0)
            {
                return NewUser(user);
            }

            return UpdateUser(user);
        }

        public IEnumerable<User> GetAllActives()
        {
            return _baseRepository.GetAllActives();
        }

        private User NewUser(User user)
        {
            try
            {
                _baseRepository.OpenTransaction();

                var userAdded = _baseRepository.Add(user);

                if (user.Addresses?.Count > 0)
                {
                    for (int i = 0; i < user.Addresses.Count; i++)
                    {
                        user.Addresses[i].User = userAdded;
                    }

                    _userAddressService.AddRange(user.Addresses);
                }

                _baseRepository.CommitTransaction();

                return _baseRepository.Get(userAdded.Id);
            }
            catch (Exception ex)
            {
                _baseRepository.RollBack();
                throw ex;
            }
        }

        private User UpdateUser(User user)
        {
            try
            {
                _baseRepository.OpenTransaction();

                _baseRepository.Update(user);

                foreach (var address in user.Addresses)
                {
                    address.User = user;

                    var addressAdd = _userAddressService.Save(address);

                    address.Id = addressAdd.Id;
                }

                _baseRepository.CommitTransaction();

                return user;
            }
            catch (Exception ex)
            {
                _baseRepository.RollBack();
                throw ex;
            }
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
            _userAddressService.Dispose();
        }

        public User Get(long Id)
        {
            return _baseRepository.Get(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _baseRepository.Find(predicate);
        }

        public void Remove(User entity)
        {
            _baseRepository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<User> entities)
        {
            _baseRepository.RemoveRange(entities);
        }

        public int Count(Expression<Func<User, bool>> predicate)
        {
            return _baseRepository.Count(predicate);
        }
    }
}
