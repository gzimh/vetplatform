using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Api.Models;

namespace VetPlatform.Api.Services
{
    public interface IRegisterService
    {
        Task<RegisterResponseModel> Register(RegisterRequestModel model);
    }
}
