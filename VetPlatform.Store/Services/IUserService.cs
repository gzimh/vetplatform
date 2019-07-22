using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Store.Models;

namespace VetPlatform.Store.Services
{
    public interface IUserService
    {
        Task<RegisterAccountResultModel> RegisterAccount(Guid tenantId, UserRequestModel model);
    }
}