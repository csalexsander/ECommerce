using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.EntityConfiguration
{
    public class UserAddresConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> entity)
        {
            entity.ToTable("UserAddresses");

            entity.HasKey(x => x.Id);

            entity.Property(e => e.CreationDate).IsRequired();

            entity.Property(e => e.Street).IsRequired();

            entity.Property(e => e.Neighborhood).IsRequired();
            
            entity.HasOne(e => e.User).WithMany(u => u.Addresses).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
