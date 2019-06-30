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

            modelBuilder.Entity<Tenant>().HasData(new Tenant
            {
                Id = Guid.Parse("37ef41bd-b7ed-4fa2-bef8-916b03b1e174"),
                HostName = "pets.vetplatform.local",
                Name = "Pets Clinic"
            },
            new Tenant
            {
                Id = Guid.Parse("85029b8d-86f1-4c81-befc-a832819ad557"),
                HostName = "meds.vetplatform.local",
                Name = "Meds Clinic"
            },
            new Tenant
            {
                Id = Guid.Parse("fe0024a5-5d18-4b2e-b2eb-59a0f42d1861"),
                HostName = "localhost",
                Name = "Dev"
            });
        }

    }
}
