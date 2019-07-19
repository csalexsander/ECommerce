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
    public class UserService : BaseService<User>, IUserService, IDisposable
    {
        readonly IUserAddressService _userAddressService;
        readonly IUserRoleRepository _userRoleRepositorio;

        public UserService(IUserRepository repository, IUserAddressService userAddressService, IUserRoleRepository userRoleRepository) : base(repository)
        {
            _userAddressService = userAddressService;
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

        public IEnumerable<User> GetAllActives()
        {
            return Find(x => x.Active);
        }

        public override User Save(User user, ref string errorMessage)
        {
            bool userNameIsValid = UsernameisValid(user.UserName, user.Id, ref errorMessage);

            if (!userNameIsValid)
            {
                return null;
            }
            
            if (user.Id == 0)
            {
                return NewUser(user);
            }

            return UpdateUser(user, ref errorMessage);
        }

        private User NewUser(User user)
        {
            try
            {
                _baseRepository.OpenTransaction();

                user.Password = CriptoUtilitary.sha256encrypt(user.Password);

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

        private User UpdateUser(User user, ref string errorMessage)
        {
            try
            {
                _baseRepository.OpenTransaction();

                _baseRepository.Update(user);

                if (user.Addresses != null)
                {
                    foreach (var address in user.Addresses)
                    {
                        address.User = user;

                        var addressAdd = _userAddressService.Save(address, ref errorMessage);

                        address.Id = addressAdd.Id;
                    }
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

        public bool UsernameisValid(string UserName, long Id, ref string ErrorMessage)
        {
            var userbd = GetFirstOrDefaultByUsername(UserName);

            if (userbd != null)
            {
                if (userbd.Id != Id)
                {
                    ErrorMessage = "username is already registered";
                    return false;
                }
            }

            return true;
        }

        public override void Dispose()
        {
            _userRoleRepositorio.Dispose();
            _userAddressService.Dispose();

            base.Dispose();
        }

        public User GetFirstOrDefaultByUsername(string UserName)
        {
            return GetFirstOrDefault(x => x.UserName.Equals(UserName));
        }
    }
}
