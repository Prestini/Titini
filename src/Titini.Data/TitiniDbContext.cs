using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Titini.Application.Common.Interfaces;
using Titini.Domain.Entities;

namespace Titini.Data
{
    public class TitiniDbContext : DbContext, ITitiniDbContext
    {
        public TitiniDbContext(DbContextOptions<TitiniDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TitiniDbContext).Assembly);
        }
    }
}
