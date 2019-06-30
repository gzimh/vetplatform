using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetPlatform.Api.Models
{
    public class ChangeStatusRequestModel
    {
        [Required]
        public Guid BookingId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
