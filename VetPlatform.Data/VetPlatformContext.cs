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
         
            modelBuilder.Entity<Booking>().HasData(Seed.Bookings);

            modelBuilder.Entity<Booking>().HasQueryFilter(p => p.TenantId == _tenantProvider.GetTenantId());
        }

    }
}
