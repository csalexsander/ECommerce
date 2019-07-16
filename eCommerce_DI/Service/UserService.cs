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
        readonly IUserRoleRepository _userRoleRepositorio;

        public UserService(IUserRepository repository, IUserAddressService userAddressService, IUserRoleRepository userRoleRepository)
        {
            _userAddressService = userAddressService;
            _baseRepository = repository;
            _userRoleRepositorio = userRoleRepository;
        }

        public bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType, ref string ErrorMessage)
        {
            User user = _baseRepository.GetFirstOrDefault(x => x.UserName.Equals(userName), true);

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

                return _baseRepository.GetFirstOrDefault(userbd => userbd.Id == userAdded.Id);
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

        public User GetFirstOrDefault(Expression<Func<User, bool>> predicate)
        {
            return _baseRepository.GetFirstOrDefault(predicate);
        }

        public User GetFirstOrDefaultByUserName(string UserName)
        {
            return GetFirstOrDefault(x => x.UserName.Equals(UserName));
        }

        public User GetFirstOrDefaultById(long Id)
        {
            return GetFirstOrDefault(x => x.Id == Id);
        }
    }
}
