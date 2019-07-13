using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Context
{
    public class CountryContext : BaseContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("Countries");
            });
        }
    }
}

