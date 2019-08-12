using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetPlatform.Api.Models
{
    public class RegisterRequestModel
    {
        public RegisterRequestModel()
        {
            TenantId = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string TenantId { get; set; }
    }
}
