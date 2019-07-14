using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.EntityConfiguration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> entity)
        {
            entity.ToTable("States");

            entity.HasKey(x => x.Id);

            entity.Property(e => e.CreationDate).IsRequired();

            entity.Property(e => e.Name).IsRequired();

            entity.HasOne(e => e.Country).WithMany(e => e.States).OnDelete(DeleteBehavior.SetNull) ;

        }
    }
}
