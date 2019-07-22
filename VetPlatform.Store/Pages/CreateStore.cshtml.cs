using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VetPlatform.Store.Models;
using VetPlatform.Store.Services;

namespace VetPlatform.Store.Pages
{
    public class CreateStoreModel : PageModel
    {
        private ITenantService _tenantService;
        private IUserService _userService;

        public CreateStoreModel(ITenantService tenantService, IUserService userService)
        {
            _tenantService = tenantService;
            _userService = userService;
        }

        [BindProperty]
        public CreateStoreRequestModel Store { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var addTenantResult = await _tenantService.AddTenant(Store.Tenant);
            if (addTenantResult.Success && addTenantResult.Tenant != null)
            {
                var registerAccountResult = await _userService.RegisterAccount(addTenantResult.Tenant.Id, Store.User);

                if (!registerAccountResult.Success)
                {
                    await _tenantService.DeleteTenant(addTenantResult.Tenant);
                    return RedirectToPage("/CreateStoreFail", new { error = registerAccountResult.Error });
                }
            }
            else
            {
                return RedirectToPage("/CreateStoreFail", new { error = addTenantResult.Error });
            }
            
            return RedirectToPage("/CreateStoreSuccess");
        }
    }
}