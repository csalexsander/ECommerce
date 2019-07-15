using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.EntityConfiguration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.CreationDate).IsRequired();

            entity.Property(e => e.Name).IsRequired();

            entity.ToTable("Countries");
        }
    }
}
