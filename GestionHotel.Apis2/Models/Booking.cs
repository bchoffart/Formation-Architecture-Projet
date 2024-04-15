using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHotel.Apis2.Models;

public class Booking
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string BookingId { get; set; }
    [Required]
    public string UserId { get; private set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    
    public List<Room> Rooms { get; } = new List<Room>();

    public Booking(string userId)
    {
        UserId = userId;
    }
}