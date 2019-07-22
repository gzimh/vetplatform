using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VetPlatform.Store.Pages
{
    public class CreateStoreFailModel : PageModel
    {
      
        public void OnGet(string error)
        {
            ViewData["error"] = error;
        }
    }
}