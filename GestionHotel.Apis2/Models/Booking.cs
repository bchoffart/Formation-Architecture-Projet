namespace GestionHotel.Apis2.Models;

public class Booking
{
    public string BookingId { get; set; }
    public string ClientId { get; private set; }

    public List<Room> Rooms { get; } = new List<Room>();

    public Booking(string clientId)
    {
        ClientId = clientId;
    }
}