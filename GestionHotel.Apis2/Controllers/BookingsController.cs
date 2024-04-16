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

    [HttpGet("book-room/{roomId}")]
    public IActionResult BookRoom(string roomId)
    {
        return Ok("Creating a booking...");
    }

    [HttpGet("cancel-booking/{bookingId}")]
    public IActionResult CancelBooking(string bookingId)
    {
        return Ok("Deleting a booking...");
    }
    
    [HttpPost("handle-client-arrival/{email}")]
    public IActionResult HandleClientArrival(string email)
    {
        return Ok("handle-client-arrival");
    }
    
    [HttpPost("handle-client-departure/{email}")]
    public IActionResult HandleClientDeparture(string email)
    {
        return Ok("handle-client-departure");
    }
}