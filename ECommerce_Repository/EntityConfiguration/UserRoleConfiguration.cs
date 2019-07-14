using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.EntityConfiguration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> entity)
        {
            entity.ToTable("Cities");

            entity.HasKey(x => x.Id);

            entity.Property(e => e.CreationDate).IsRequired();

            entity.Property(e => e.AccessLevel).IsRequired();

            entity.Property(e => e.Name).IsRequired();
        }
    }
}
