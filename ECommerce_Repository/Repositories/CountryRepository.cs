using ECommerce_Domain.Entities;
using ECommerce_Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Repositories
{
    public class CountryRepository : BaseRepository<Country>
    {
        public CountryRepository(CountryContext context) : base(context)
        {
        }
    }
}
