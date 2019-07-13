using System;
using System.Collections.Generic;
using System.Text;
using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Repository.Context
{
    public class ClientCreditCardContext : BaseContext
    {
        public DbSet<ClientCreditCard> ClientCreditCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientCreditCard>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("ClientCreditCards");
                entity.HasOne(x => x.User).WithMany(x => x.CreditCards);
            });
        }

    }
}
