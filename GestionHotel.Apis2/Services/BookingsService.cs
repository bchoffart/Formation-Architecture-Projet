using GestionHotel.Apis2.Controllers;
using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Services;

public class BookingsService : GenericCrudService<Booking>
{
    private readonly RoomsService _roomsService = new RoomsService();
    private readonly PaymentService _paymentService = new PaymentService();
    public void AttemptBooking(BookingReservationInput input)
    {
        var room = _roomsService.SelectById(input.RoomId);
        if (room == null) return;
        if (!room.IsRoomAvailable) return;
        BookRoom(input, room);
    }

    private void BookRoom(BookingReservationInput input, Room room)
    {
        var booking = input.PaymentMethod != PaymentMethod.Other ? 
            new Booking(input.ClientId, input.StartDate, input.EndDate, input.PaymentMethod) 
            : new Booking(input.ClientId, input.StartDate, input.EndDate);
        room.ChangeRoomAvailability();
        if (booking.PaymentMethod != PaymentMethod.Other)
        {
            _paymentService.HandlePayment(input.Payment, input.PaymentMethod);
        }
        Insert(booking);
        SaveDatabase();
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