using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Application.Models;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Application
{
    public class CountryApplication : BaseApplication<Country, CountryModel>, ICountryApplication
    {
        public CountryApplication(ICountryService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}
