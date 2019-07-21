using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Data;
using VetPlatform.Data.Models;
using VetPlatform.Store.Models;

namespace VetPlatform.Store.Services
{
    public class TenantService : ITenantService
    {
        private TenantContext _context;
        private IHostingEnvironment _environment;

        public TenantService(TenantContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<Tenant> AddTenant(TenantRequestModel requestModel)
        {
            var tenant = new Tenant()
            {
                Name = requestModel.Name,
                HostName = requestModel.Domain,
                Theme = requestModel.Theme
            };

            await _context.Tenants.AddAsync(tenant);
            await _context.SaveChangesAsync();

            var logo = await AddLogo(tenant.Id, requestModel.Logo);
            tenant.Logo = logo;

            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();

            return tenant;
        }

        private async Task<string> AddLogo(Guid tenantId, IFormFile file)
        {
            var directory = Path.Combine(_environment.WebRootPath, "img", tenantId.ToString());

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var path = Path.Combine(directory, file.FileName);

            if (file.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return file.FileName;
        }
    }
}
