using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Api.Models;
using VetPlatform.Data.Models;

namespace VetPlatform.Api.Services
{
    public interface IBookingsService
    {
        Task<BookingsResponseModel> GetBookings(BookingsRequestModel requestModel);
        Task<Booking> ChangeBookingStatus(ChangeStatusRequestModel requestModel);
        bool IsValidStatus(string status);
    }
}
