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

            PrepareDomainName();

            var tenantExists = await _tenantService.TenantExists(Store.Tenant.Domain);
            if (tenantExists)
            {
                ModelState.AddModelError("Store.Tenant.Domain", $"Store with domain: {Store.Tenant.Domain} already exists.");
                return Page();
            }

            var userExists = await _userService.UserExists(Store.User.Email);
            if (userExists)
            {
                ModelState.AddModelError("Store.User.Email", $"User with email: {Store.User.Email} already exists.");
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

        private void PrepareDomainName()
        {
            Store.Tenant.Domain = Store.Tenant.Domain.ToLower();
            if (!Store.Tenant.Domain.EndsWith(".vetplatform.com"))
            {
                Store.Tenant.Domain += ".vetplatform.com";
            }
        }
    }
}