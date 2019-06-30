using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetPlatform.Api.Exceptions;
using VetPlatform.Api.Models;
using VetPlatform.Api.Services;

namespace VetPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private IBookingsService _bookingsService;

        public BookingsController(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        [HttpGet]
        public async Task<IActionResult> Bookings([FromQuery] BookingsRequestModel requestModel)
        {
            try
            {
                if (requestModel.Take < 1) return BadRequest("Take must be greater than 0");
                var bookingResponse = await _bookingsService.GetBookings(requestModel);
                return Ok(bookingResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("status")]
        public async Task<IActionResult> ChangeBookingStatus([FromBody] ChangeStatusRequestModel requestModel)
        {
            requestModel.Status = requestModel.Status.ToLower();
            if (!_bookingsService.IsValidStatus(requestModel.Status)) return BadRequest("Unsupported Status");

            try
            {
                var booking = await _bookingsService.ChangeBookingStatus(requestModel);
                return Ok(new ResponseModel { Success = true, Payload = booking.Status });
            }
            catch (Exception ex)
            {
                if (ex is BookingException) return BadRequest (ex.Message);
                return StatusCode(500);
            }
        }
    }
}
