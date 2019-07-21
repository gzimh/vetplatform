using System;
using System.Collections.Generic;
using System.Text;

namespace VetPlatform.Data.Models
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public string Theme { get; set; }

        public string Logo { get; set; }
    }
}
