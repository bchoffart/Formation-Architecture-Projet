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
    
    [CustomAuthorization(UserRole.Receptionist)]
    [HttpPost("handle-client-arrival/{email}")]
    public void HandleClientArrival(string email)
    {
        _bookingsService.HandleClientArrival(email);
    }
    
    [CustomAuthorization(UserRole.Receptionist)]
    [HttpPost("handle-client-departure/{email}")]
    public void HandleClientDeparture(string email)
    {
        _bookingsService.HandleClientDeparture(email);
    }

    [CustomAuthorization(UserRole.Receptionist, UserRole.Client)]
    [HttpGet("cancel-booking/{bookingId}")]
    public void CancelBooking(string bookingId)
    {
        _bookingsService.CancelBooking(bookingId);
    }
    

}