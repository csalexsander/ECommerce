using System;
using System.Collections.Generic;
using System.Text;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;

namespace ECommerce_Domain.Service
{
    public class UserRoleService : BaseService<UserRole>, IUserRoleService
    {
        public UserRoleService(IUserRoleRepository repository) : base(repository)
        {
            
        }

        public override UserRole Save(UserRole entity, ref string errorMessage)
        {
            var valid = ValidateRoleName(entity.Name, entity.Id, ref errorMessage);

            if (!valid)
            {
                return null;
            }

            return base.Save(entity, ref errorMessage);
        }

        public UserRole GetFirstOrDefaultByName(string name)
        {
            return _baseRepository.GetFirstOrDefault(x => x.Name.Equals(name));
        }

        private bool ValidateRoleName(string name, long Id, ref string errorMessage)
        {
            var role = GetFirstOrDefaultByName(name);

            if (role != null)
            {
                if (role.Id != Id)
                {
                    errorMessage = "this role already exists";
                    return false;
                }
            }

            return true;

        }        
    }
}
