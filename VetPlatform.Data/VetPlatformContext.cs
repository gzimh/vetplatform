using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VetPlatform.Data.Models;
using VetPlatform.Data.Providers;

namespace VetPlatform.Data
{
    public class VetPlatformContext : DbContext
    {
        private ITenantProvider _tenantProvider;

        public DbSet<Booking> Bookings { get; set; }

        public VetPlatformContext(DbContextOptions<VetPlatformContext> options, ITenantProvider tenantProvider) : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                Id = Guid.NewGuid(),
                TenantId = Guid.Parse("37ef41bd-b7ed-4fa2-bef8-916b03b1e174"),
                Schedule = new DateTime(2019, 4, 20, 08, 00, 00)
            },
            new Booking
            {
                Id = Guid.NewGuid(),
                TenantId = Guid.Parse("85029b8d-86f1-4c81-befc-a832819ad557"),
                Schedule = new DateTime(2019, 4, 20, 09, 00, 00)
            });

            modelBuilder.Entity<Booking>().HasQueryFilter(p => p.TenantId == _tenantProvider.GetTenantId());
        }

    }
}
