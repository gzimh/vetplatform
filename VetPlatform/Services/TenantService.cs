using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Api.Models;
using VetPlatform.Data;
using VetPlatform.Data.Models;

namespace VetPlatform.Api.Services
{
    public class TenantService : ITenantService
    {
        private TenantContext _context;
        public TenantService(TenantContext context)
        {
            _context = context;
        }
        public Tenant AddTenant(TenantRequestModel requestModel)
        {
            var tenant = new Tenant()
            {
                Name = requestModel.Name,
                HostName = requestModel.HostName,
                Theme = requestModel.Theme
            };

            _context.Tenants.Add(tenant);
            _context.SaveChanges();

            return tenant;
        }
    }
}
