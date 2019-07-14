using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");

            entity.HasKey(x => x.Id);
            
            entity.Property(e => e.CreationDate).IsRequired();

            entity.Property(e => e.Name).IsRequired();

            entity.Property(e => e.Email).IsRequired();

            entity.Property(e => e.Password).IsRequired();

            entity.HasOne(e => e.Role).WithMany(x => x.Users).OnDelete(DeleteBehavior.SetNull);

            entity.Property(e => e.UserName).IsRequired();

        }
    }
}
