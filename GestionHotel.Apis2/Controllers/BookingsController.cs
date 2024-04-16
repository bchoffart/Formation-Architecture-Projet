using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;
using GestionHotel.Apis2.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private BookingCrudService bookingCrudService = new BookingCrudService();
    
    [HttpGet("show-available-rooms")]
    [CustomAuthorization(UserRole.Receptionist, UserRole.Client)]
    public List<Booking> ShowAvailableRooms()
    {
        return bookingCrudService.SelectAll();
    }

    [HttpPost("book-room")]
    public IActionResult BookRoom()
    {
        return Ok("Creating a booking...");
    }

    [HttpGet("cancel-booking")]
    public IActionResult CancelBooking()
    {
        return Ok("Deleting a booking...");
    }
}