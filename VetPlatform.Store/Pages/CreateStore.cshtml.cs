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

        public CreateStoreModel(ITenantService tenantService)
        {
            _tenantService = tenantService;
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

            await _tenantService.AddTenant(Store.Tenant);

            return RedirectToPage("/Index");
        }
    }
}