using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Data.Models;
using VetPlatform.Store.Models;

namespace VetPlatform.Store.Services
{
    public interface ITenantService
    {
        Task<Tenant> AddTenant(TenantRequestModel requestModel);
    }
}
