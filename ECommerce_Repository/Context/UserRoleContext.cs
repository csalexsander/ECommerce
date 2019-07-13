using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Context
{
    public class UserRoleContext : BaseContext
    {
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasKey(x => x.Id);
            });
        }
    }
}
