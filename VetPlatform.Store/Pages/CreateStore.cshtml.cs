using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VetPlatform.Store.Models;

namespace VetPlatform.Store.Pages
{
    public class CreateStoreModel : PageModel
    {
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

            return RedirectToPage("/Index");
        }
    }
}