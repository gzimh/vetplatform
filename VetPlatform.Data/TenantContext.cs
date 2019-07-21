using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VetPlatform.Data.Models;

namespace VetPlatform.Data
{
    public class TenantContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tenant>().HasData(Seed.Tenants);
        }

    }
}
