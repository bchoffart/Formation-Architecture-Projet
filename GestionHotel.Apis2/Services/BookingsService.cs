using GestionHotel.Apis2.Controllers;
using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Services;

public class BookingsService : GenericCrudService<Booking>
{
    private readonly RoomsService _roomsService = new RoomsService();
    private readonly UserService _userService = new UserService();
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
        var updatedBooking = UpdateBookingPaymentMethodAndApplyPayment(booking, input.Payment, input.PaymentMethod);
        Insert(updatedBooking);
        SaveDatabase();
    }

    private Booking UpdateBookingPaymentMethodAndApplyPayment(Booking booking, Payment payment, PaymentMethod paymentMethod)
    {
        if (paymentMethod == PaymentMethod.Other) return booking;
        booking.PaymentMethod = paymentMethod;
        _paymentService.HandlePayment(payment, paymentMethod);
        return booking;
    }
    
    public void HandleClientArrival(string email, Payment? payment, PaymentMethod paymentMethod = PaymentMethod.Other)
    {
        var foundUser = _userService.Select(u => u.Email == email)[0]!;
        var foundBooking = Select(b => b.UserId == foundUser.Id)[0];
        if (payment != null)
        {
            foundBooking = UpdateBookingPaymentMethodAndApplyPayment(foundBooking, payment, paymentMethod);
        }
        _roomsService.ChangeRoomOccupation(foundBooking.RoomId);
        throw new NotImplementedException();
    }

    public void HandleClientDeparture(string email)
    {
        
        // TO-DO : Update booking status + payment status + mark booking room for cleanup
        throw new NotImplementedException();
    }
    
    public void CancelBooking(string bookingId)
    {
        throw new NotImplementedException();
    }
}