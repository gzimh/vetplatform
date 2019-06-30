using System;
using System.Collections.Generic;
using System.Text;

namespace VetPlatform.Data.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public DateTime Schedule { get; set; }
        public string Status { get; set; }
    }
}
