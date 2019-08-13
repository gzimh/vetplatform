using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPlatform.Api.Models
{
    public class BookNowRequestModel
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string UserId { get; set; }
        public string Reason { get; set; }
    }
}
