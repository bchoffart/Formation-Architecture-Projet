using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;
using GestionHotel.Apis2.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly BookingsService _bookingsService = new BookingsService();

    [HttpPost("book-room")]
    [CustomAuthorization(UserRole.Receptionist, UserRole.Client)]
    public void BookRoom([FromBody] BookingReservationInput input)
    {
        _bookingsService.AttemptBooking(input);
    }

    [CustomAuthorization(UserRole.Receptionist, UserRole.Client)]
    [HttpGet("cancel-booking/{bookingId}")]
    public IActionResult CancelBooking(string bookingId)
    {
        return Ok("Deleting a booking...");
    }
    
    [CustomAuthorization(UserRole.Receptionist)]
    [HttpPost("handle-client-arrival/{email}")]
    public IActionResult HandleClientArrival(string email)
    {
        return Ok("handle-client-arrival");
    }
    
    [CustomAuthorization(UserRole.Receptionist)]
    [HttpPost("handle-client-departure/{email}")]
    public IActionResult HandleClientDeparture(string email)
    {
        return Ok("handle-client-departure");
    }
}