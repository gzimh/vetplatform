using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetPlatform.Api.Models
{
    public class BookingsRequestModel
    {
        [FromQuery]
        [Required]
        public DateTime Date { get ; set; }
        [FromQuery]
        [Required]
        public int Skip { get; set; }
        [FromQuery]
        [Required]
        public int Take { get; set; }
        [FromQuery]
        [Required]
        public string[] Status { get; set; }
    }
}
