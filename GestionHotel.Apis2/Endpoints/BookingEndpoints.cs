using GestionHotel.Apis2.Models;

public static class BookingEndpoints
{
    private const string BASE_URL = "/api/v1/booking/";

    public static void MapBookingsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup(BASE_URL)
            .WithOpenApi()
            .WithTags("Booking");

        group.MapGet("", () =>
            {
                var booking = new Booking("zob");
                return booking.ClientId;
            })
            .WithName("GetAvailableRooms");

        group.MapPost("", () => { return "hello POST"; })
            .WithName("CreateBooking");
    }
}