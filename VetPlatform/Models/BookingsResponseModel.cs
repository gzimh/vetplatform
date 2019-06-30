using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPlatform.Api.Models
{
    
    public class BookingsResponseModel
    {
        public bool Success { get; set; }
        public bool HasMore { get; set; }
        public List<BookingResponseModel> Payload { get; set; }
    }


    public class BookingResponseModel
    {
        public Guid Id { get; set; }
        public CustomerResponseModel Customer { get; set; }
        public DateTime Schedule { get; set; }
        public string ScheduleTime => Schedule.ToString("HH:mm");

        public string Status { get; set; }
    }

    public class CustomerResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
