using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VetPlatform.Data.Providers;

namespace VetPlatform.Api.Controllers
{
    [Route("api/tenants")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private ITenantProvider _tenantProvider;
        private ILogger<TenantsController> _logger;

        public TenantsController(ITenantProvider tenantProvider,
            ILogger<TenantsController> logger)
        {
            _tenantProvider = tenantProvider;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetInformation()
        {
            try
            {
                var tenantId = _tenantProvider.GetTenantId();
                var tenant = await _tenantProvider.GetTenant(tenantId);
                return Ok(tenant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Something went wrong.");
            }   
        }
    }
}