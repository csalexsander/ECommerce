using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Context
{
    public class CountryContext : BaseContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("Cities");
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("States");
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("Countries");
            });
        }
    }
}

