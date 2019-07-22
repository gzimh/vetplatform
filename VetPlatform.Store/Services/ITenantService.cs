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
        Task<AddTenantResultModel> AddTenant(TenantRequestModel requestModel);
        Task DeleteTenant(Tenant tenant);
    }
}
