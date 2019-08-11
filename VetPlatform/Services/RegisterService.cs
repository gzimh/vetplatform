using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VetPlatform.Api.Models;
using VetPlatform.Data;
using VetPlatform.Data.Options;

namespace VetPlatform.Api.Services
{
    public class RegisterService : IRegisterService
    {
        private UserManager<ApplicationUser> _userManager;

        public RegisterService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResponseModel> Register(RegisterRequestModel model)
        {
            var result = new RegisterResponseModel();

            var user = new ApplicationUser
            {
                FullName = model.Name,
                Email = model.Name,
                UserName = model.Email
            };

            try
            {
                var createUserResult = await _userManager.CreateAsync(user);
                if (createUserResult.Succeeded)
                {

                    var addClaimsResult = await _userManager.AddClaimsAsync(user, new Claim[] {
                    new Claim("name", model.Name),
                    new Claim("email", model.Email),
                    new Claim("tenantId", model.TenantId),
                    new Claim("role", RoleOptions.User)
                });

                    if (!addClaimsResult.Succeeded)
                    {
                        await _userManager.DeleteAsync(user);
                        result.Success = false;
                        result.Error = addClaimsResult.Errors?.FirstOrDefault()?.Description;
                    }
                }
                else
                {
                    result.Success = false;
                    result.Error = createUserResult.Errors?.FirstOrDefault()?.Description;
                }
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Error = ex.Message;
            }

            return result;
        }
    }
}
