using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Api.Models;
using VetPlatform.Data.Models;

namespace VetPlatform.Api.Services
{
    public interface ITenantService
    {
        Tenant AddTenant(TenantRequestModel requestModel);
    }
}
