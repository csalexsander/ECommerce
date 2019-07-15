using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.EntityConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.ToTable("Cities");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.CreationDate).IsRequired();

            entity.Property(e => e.Name).IsRequired();

            entity.HasOne(e => e.Country).WithMany(e => e.Cities).OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.State).WithMany(e => e.Cities).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
