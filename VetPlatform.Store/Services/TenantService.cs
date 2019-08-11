using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> TenantExists(string domain)
        {
            var existingTenant = await _context.Tenants.FirstOrDefaultAsync(p => p.HostName == domain);
            return existingTenant != null;
        }

        public async Task<AddTenantResultModel> AddTenant(TenantRequestModel requestModel)
        {
            var result = new AddTenantResultModel();

            var tenant = new Tenant()
            {
                Name = requestModel.Name,
                HostName = requestModel.Domain,
                Theme = requestModel.Theme
            };

            try
            {
                await _context.Tenants.AddAsync(tenant);
                await _context.SaveChangesAsync();

                var logo = await AddLogo(tenant.Id, requestModel.Logo);
                tenant.Logo = logo;

                _context.Tenants.Update(tenant);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Tenant = tenant;
            }
            catch (Exception ex) {
                result.Success = false;
                result.Error = $"Unhandled expection: {ex.Message}";
            }
          
            return result;
        }

        public async Task DeleteTenant(Tenant tenant)
        {
            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();
        }


        private async Task<string> AddLogo(Guid tenantId, IFormFile file)
        {
            var directory = Path.Combine(_environment.WebRootPath, "img", "uploads", tenantId.ToString());

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
