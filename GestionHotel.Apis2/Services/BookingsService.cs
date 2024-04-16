using GestionHotel.Apis2.Models;

namespace GestionHotel.Apis2.Services;

public class BookingsService : GenericCrudService<Booking>
{
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