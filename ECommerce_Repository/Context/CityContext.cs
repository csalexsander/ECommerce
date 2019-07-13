using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Context
{
    public class CityContext : BaseContext
    {
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("Cities");
                entity.HasKey(x => x.Id);
            });
        }
    }
}
