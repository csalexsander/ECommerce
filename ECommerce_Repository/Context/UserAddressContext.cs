using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Context
{
    public class UserAddressContext : BaseContext
    {
        public DbSet<UserAddress> UserAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.ToTable("UserAddresses");
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.User).WithMany(x => x.Addresses);

            });
        }
    }
}
