using EVRentalBusiness.Service;
using EVRentalEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService _bookingService = null;
        private readonly ILogger<BookingController> _logger;

        public BookingController(BookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking([FromBody] BookingModel booking)
        {
            try
            {
                _logger.LogInformation("Seri log working: Add Booking...");
                object result = _bookingService.AddBooking(booking);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while adding booking: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetAllBooking")]
        public IActionResult GetAllBooking()
        {
            try
            {
                _logger.LogInformation("Seri log working: Fetching Bookings...");
                object result = _bookingService.GetAllBooking();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while fetching bookings: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


    }
}
