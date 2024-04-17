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
        _roomsService.ChangeRoomAvailability(room.Id, false);
        if (input.PaymentMethod != PaymentMethod.Other)
        {
            booking = UpdateBookingPaymentMethodAndApplyPayment(booking, input.Payment);
        }
        Insert(booking);
    }

    private Booking UpdateBookingPaymentMethodAndApplyPayment(Booking booking, Payment payment)
    {
        _paymentService.HandlePayment(payment);
        booking.PayBooking();
        return booking;
    }
    
    public void HandleClientArrival(string email, Payment? payment)
    {
        var foundUser = _userService.Select(u => u.Email == email)[0]!;
        var foundBooking = Select(b => b.UserId == foundUser.Id)[0];
        if (foundBooking == null) return;
        if (payment != null && foundBooking.PaymentStatus != PaymentStatus.Paid)
        {
            foundBooking = UpdateBookingPaymentMethodAndApplyPayment(foundBooking, payment);
            Update(foundBooking);
        }
        _roomsService.ChangeRoomOccupation(foundBooking.RoomId, true);
    }

    public void HandleClientDeparture(string email, Payment payment)
    {
        var booking = FindBookingForClientByEmail(email);
        booking = UpdateBookingPaymentMethodAndApplyPayment(booking, payment);
        _roomsService.MarkRoomForCleaning(booking.RoomId);
        _roomsService.ChangeRoomAvailability(booking.RoomId, true);
        _roomsService.ChangeRoomOccupation(booking.RoomId, false);
    }
    
    public void CancelBooking(string bookingId)
    {
        var booking = SelectById(bookingId);
        if (booking == null) return;
        booking.BookingStatus = BookingStatus.Canceled;
        if ((booking.StartDate - DateTime.Now).TotalDays < 2)
        {
            Console.WriteLine("Client will not receive a refund.");
        }
        _roomsService.ChangeRoomAvailability(booking.RoomId, true);
        Update(booking);
    }

    public Booking FindBookingForClientByEmail(string email)
    {
        var foundUser = _userService.Select(u => u.Email == email)[0]!;
        return Select(b => b.UserId == foundUser.Id)[0];
    }
}