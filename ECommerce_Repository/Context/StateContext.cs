using ECommerce_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Context
{
    public class StateContext : BaseContext
    {
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("States");
                entity.HasKey(x => x.Id);
            });
        }
    }
}
