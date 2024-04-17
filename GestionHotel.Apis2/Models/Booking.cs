using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Models;

public class Booking : BaseModel
{
    [Required]
    public string UserId { get; private set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public BookingStatus BookingStatus { get; set;  }
    
    public string RoomId { get; set; }

    public Booking(string userId, DateTime startDate, DateTime endDate, string roomId)
    {
        UserId = userId;
        StartDate = startDate;
        EndDate = endDate;
        RoomId = roomId;
        PaymentStatus = PaymentStatus.AwaitingPaymentMethodChoice;
        BookingStatus = BookingStatus.Created;
    }

    public void PayBooking()
    {
        PaymentStatus = PaymentStatus.Paid;
    }
}