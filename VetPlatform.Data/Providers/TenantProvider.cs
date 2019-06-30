using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetPlatform.Data.Providers
{
    public class TenantProvider : ITenantProvider
    {
        private TenantContext _context;
        private IHttpContextAccessor _accessor;

        public TenantProvider(TenantContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public Guid GetTenantId()
        {
            var referer = _accessor.HttpContext.Request.Headers["Referer"].ToString();
            string host;

            if (string.IsNullOrEmpty(referer))
                host = _accessor.HttpContext.Request.Host.Host;
            else
                host = new Uri(referer).Host;

            var tenant = _context.Tenants.FirstOrDefault(t => t.HostName == host);
            if (tenant == null) throw new Exception($"Tenant not found: {host}");
            return tenant.Id;
        }
    }
}
