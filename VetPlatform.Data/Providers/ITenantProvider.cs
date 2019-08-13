using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VetPlatform.Data.Models;

namespace VetPlatform.Data.Providers
{
    public interface ITenantProvider
    {
        Guid GetTenantId();
        Task<Tenant> GetTenant(Guid tenantId);
    }
}
