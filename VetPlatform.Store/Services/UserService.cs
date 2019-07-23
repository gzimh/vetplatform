using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VetPlatform.Data;
using VetPlatform.Store.Models;

namespace VetPlatform.Store.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> UserExists(string email)
        {
            var existingUser = await _userManager.FindByNameAsync(email);
            return existingUser != null;
        }

        public async Task<RegisterAccountResultModel> RegisterAccount(Guid tenantId, UserRequestModel model)
        {
            RegisterAccountResultModel result = new RegisterAccountResultModel();

            var user = new ApplicationUser
            {
                FullName = model.Name,
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            try
            {
                
                var createUserResult = await _userManager.CreateAsync(user, model.Password);

                if (createUserResult.Succeeded)
                {
                    var addClaimsResult = await _userManager.AddClaimsAsync(user, new List<Claim> {
                        new Claim("role", RoleOptions.StoreAdmin),
                        new Claim("tenantId", tenantId.ToString()),
                    });

                    if (!addClaimsResult.Succeeded)
                    {
                        await _userManager.DeleteAsync(user);
                        result.Success = false;
                        result.Error = "Couldn't add claim for user.";
                    }
                    else
                    {
                        result.Success = true;
                    }
                }
                else
                {
                    result.Success = false;
                    if(createUserResult.Errors != null && createUserResult.Errors.Count() > 0)
                    {
                        result.Error = GetErrorSummary(createUserResult);
                    }
                    else
                    {
                        result.Error = "Couldn't not create user.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Error = $"Unhandled expection: {ex.Message}";
            }

            return result;
        }
        private string GetErrorSummary(IdentityResult identityResult)
        {
            string result = "";
            foreach (var error in identityResult.Errors)
            {
                result += error.Description + "\n";
            }

            return result;
        }
    }
}
