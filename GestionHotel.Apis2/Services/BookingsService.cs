using GestionHotel.Apis2.Controllers;
using GestionHotel.Apis2.Models;

namespace GestionHotel.Apis2.Services;

public class BookingsService : GenericCrudService<Booking>
{
    private RoomsService _roomsService = new RoomsService();
    public void AttemptBooking(BookingReservationInput input)
    {
        var room = _roomsService.SelectById(input.RoomId);
        if (room == null) return;
        if (!room.IsRoomAvailable) return;
        this.BookRoom(input, room);
    }

    private void BookRoom(BookingReservationInput input, Room room)
    {
        Booking booking = new Booking(input.ClientId);
    }
    
    public void HandleClientArrival(string email)
    {
        // TO-DO : Update booking status + update (eventually) payment status
        throw new NotImplementedException();
    }

    public void HandleClientDeparture()
    {
        // TO-DO : Update booking status + payment status + mark booking room for cleanup
        throw new NotImplementedException();
    }
    
    public void CancelBooking(string bookingId)
    {
        // TO-DO : Update booking status => must be still open and handle 48h
        throw new NotImplementedException();
    }
}