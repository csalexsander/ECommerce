using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce_Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BaseContext context) : base(context)
        {

        }

        public IEnumerable<User> GetAllActives()
        {
            return _Context.Users.Where(u => u.Active).ToList();
        }

        public User GetUserComplete(long Id, Enumerators.LoginType loginType)
        {
            var query = QueryUserComplete();

            return query.FirstOrDefault(user => user.Id == Id);
        }

        private IIncludableQueryable<User, List<ClientCreditCard>> QueryUserComplete()
        {
            return _Context.Users.Include(user => user.Role).Include(user => user.Addresses).Include(user => user.CreditCards);
        }

        public User GetUserWithRole(long Id, string UserName = "")
        {
            var query = _Context.Users.Include(user => user.Role);

            if (string.IsNullOrWhiteSpace(UserName))
            {
                return query.FirstOrDefault(user => user.Id == Id);
            }

            return query.FirstOrDefault(user => user.UserName == UserName);
        }
    }
}
