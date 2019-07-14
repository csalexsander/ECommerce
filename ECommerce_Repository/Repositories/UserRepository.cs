using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Repository.Context;
using Microsoft.EntityFrameworkCore;
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
    }
}
