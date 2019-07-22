using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Data.Models;

namespace VetPlatform.Store.Models
{
    public class AddTenantResultModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public Tenant Tenant { get; set; }
    }
}
