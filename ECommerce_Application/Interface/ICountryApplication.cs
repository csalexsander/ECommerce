﻿using ECommerce_Application.Models;
using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Interface
{
    public interface ICountryApplication : IBaseApplication<Country, CountryModel>
    {
    }
}
