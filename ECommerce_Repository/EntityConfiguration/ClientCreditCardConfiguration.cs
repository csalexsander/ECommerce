using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.EntityConfiguration
{
    public class ClientCreditCardConfiguration : IEntityTypeConfiguration<ClientCreditCard>
    {
        public void Configure(EntityTypeBuilder<ClientCreditCard> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(x => x.Number).IsRequired();

            entity.Property(x => x.SecurityCode).IsRequired();

            entity.Property(x => x.Banner).IsRequired();

            entity.Property(x => x.CardHolder).IsRequired();

            entity.ToTable("ClientCreditCards");

            entity.HasOne(x => x.User).WithMany(x => x.CreditCards).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
