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
    public PaymentStatus PaymentStatus { get; set; }
    public BookingStatus BookingStatus { get; set;  }
    
    public List<Room> Rooms { get; } = new List<Room>();

    public Booking(string userId)
    {
        UserId = userId;
        PaymentStatus = PaymentStatus.AwaitingPaymentMethodChoice;
    }
}