using System;
using System.Collections.Generic;
using System.Text;

namespace VetPlatform.Data.Providers
{
    public interface ITenantProvider
    {
        Guid GetTenantId();
    }
}
