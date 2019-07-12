using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Context
{
    public class UserContext : BaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<ClientCreditCard> ClientCreditCards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.ToTable("UserAddresses");
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.User).WithMany(x => x.Addresses);

            });

            modelBuilder.Entity<ClientCreditCard>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("ClientCreditCards");
                entity.HasOne(x => x.User).WithMany(x => x.CreditCards);
            });
        }
    }
}
