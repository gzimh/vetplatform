using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VetPlatform.Api.Models;
using VetPlatform.Api.Services;

namespace VetPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private ITenantService _tenantService;
        private IHostingEnvironment _env;

        public StoreController(ITenantService tenantService, IHostingEnvironment env)
        {
            _tenantService = tenantService;
            _env = env;
        }

        [HttpPost]
        public IActionResult AddTenant ([FromBody] TenantRequestModel requestModel)
        {
            try
            {
                var tenant = _tenantService.AddTenant(requestModel);
                return Ok(tenant);
            }
            catch(Exception ex)
            {
                if (_env.IsProduction())
                {
                    // log error
                    return BadRequest("Something went wrong.");
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
