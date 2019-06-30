using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPlatform.Api.Models;
using VetPlatform.Data;
using VetPlatform.Data.Models;

namespace VetPlatform.Api.Services
{
    public class BookingsService : IBookingsService
    {
        private VetPlatformContext _context;
        private List<string> ValidStatuses = new List<string> { "pending", "done", "canceled"};
        public BookingsService(VetPlatformContext context)
        {
            _context = context;
        }

        public async Task<Booking> ChangeBookingStatus(ChangeStatusRequestModel requestModel)
        {
            var booking = await _context.Bookings.FindAsync(requestModel.BookingId);
            if (booking == null) throw new Exception($"Booking: {requestModel.BookingId} not found");

            booking.Status = requestModel.Status;
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<BookingsResponseModel> GetBookings(BookingsRequestModel requestModel)
        {
            var responseModel = new BookingsResponseModel();

            try
            {
                var query = _context.Bookings
                .Where(p => p.Schedule.Date == requestModel.Date.Date 
                && requestModel.Status.Contains(p.Status.ToLower()))
                .OrderBy(p => p.Schedule);

                var test = _context.Bookings.ToList();

                var bookings = await query
                    .Skip(requestModel.Skip)
                    .Take(requestModel.Take)
                    .ToListAsync();

                responseModel.Payload = bookings.Select(booking => new BookingResponseModel
                {
                    Id = booking.Id,
                    Customer = new CustomerResponseModel
                    {
                        Id = Guid.NewGuid(),
                        Name = $"DC - {Guid.NewGuid().ToString().Substring(1, 5)}"
                    },
                    Schedule = booking.Schedule,
                    Status = booking.Status
                }).ToList();

                responseModel.HasMore = (requestModel.Skip + requestModel.Take) < query.Count();

                responseModel.Success = true;
            }
            catch (Exception ex)
            {
                //
                responseModel.Success = false;
            }

            return responseModel;
        }

        public bool IsValidStatus(string status)
        {
            return ValidStatuses.Any(s => s == status);
        }
    }
}
