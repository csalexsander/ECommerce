using ECommerce_Commons.Utilitaries;
using ECommerce_Domain.Entities;
using ECommerce_Repository.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce_Repository.Context
{
    public class BaseContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ClientCreditCard> ClientCreditCards { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ECommerce;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ClientCreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserAddresConfiguration());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.DisplayName();
            }
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty(nameof(BaseEntity.CreationDate)) != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(BaseEntity.CreationDate)).CurrentValue = DateTime.Now;
                }
                else
                {
                    entry.Property(nameof(BaseEntity.CreationDate)).IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty(nameof(User.Password)) != null))
            {
                if (entry.State == EntityState.Added)
                {
                    var currentValue = entry.Property(nameof(BaseEntity.CreationDate)).CurrentValue.ToString();

                    entry.Property(nameof(User.Password)).CurrentValue = CriptoUtilitary.sha256encrypt(currentValue);
                }
                else
                {
                    entry.Property(nameof(User.Password)).IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}

