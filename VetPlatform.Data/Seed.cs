using System;
using System.Collections.Generic;
using System.Text;
using VetPlatform.Data.Models;
using VetPlatform.Data.Options;

namespace VetPlatform.Data
{
    public static class Seed
    {
        private static Guid _randomTenantId => Guid.Parse("37ef41bd-b7ed-4fa2-bef8-916b03b1e174");
        public static List<Tenant> Tenants => new List<Tenant> {
            new Tenant
            {
                Id = _randomTenantId,
                HostName = "pets.vetplatform.local",
                Name = "Pets Clinic",
                Theme = "#3f51b5"
            },
            new Tenant
            {
                Id = Guid.Parse("85029b8d-86f1-4c81-befc-a832819ad557"),
                HostName = "meds.vetplatform.local",
                Name = "Meds Clinic",
                Theme = "#33691e"
            },
            new Tenant
            {
                Id = Guid.Parse("fe0024a5-5d18-4b2e-b2eb-59a0f42d1861"),
                HostName = "localhost",
                Name = "Dev",
                Theme = "#bf360c"
            }
        };

        public static List<Booking> Bookings => new List<Booking>
        {
            new Booking
            {
                Id = Guid.NewGuid(),
                TenantId = _randomTenantId,
                Schedule = new DateTime(2019, 4, 20, 08, 00, 00),
                Status = BookingsStatusOptions.Done
            },
            new Booking
            {
                Id = Guid.NewGuid(),
                TenantId = _randomTenantId,
                Schedule = new DateTime(2019, 4, 20, 09, 00, 00),
                Status = BookingsStatusOptions.Pending
            }
        };
    }
}
