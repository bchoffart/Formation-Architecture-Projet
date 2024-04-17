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
        var booking = new Booking(input.ClientId, input.StartDate, input.EndDate, room.Id);
        _roomsService.ChangeRoomAvailability(room.Id);
        var updatedBooking = UpdateBookingPaymentMethodAndApplyPayment(input, booking);
        Insert(updatedBooking);
        SaveDatabase();
    }

    private Booking UpdateBookingPaymentMethodAndApplyPayment(BookingReservationInput input, Booking booking)
    {
        if (input.PaymentMethod == PaymentMethod.Other) return booking;
        booking.PaymentMethod = input.PaymentMethod;
        _paymentService.HandlePayment(input.Payment, input.PaymentMethod);
        return booking;
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
        throw new NotImplementedException();
    }
}