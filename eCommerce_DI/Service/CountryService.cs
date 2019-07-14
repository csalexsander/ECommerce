using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Service
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        public CountryService(ICountryRepository repository) : base(repository)
        {
        }
    }
}
