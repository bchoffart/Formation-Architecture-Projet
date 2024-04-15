using GestionHotel.Apis2;
using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;

public static class BookingEndpoints
{
    private const string BASE_URL = "/api/v1/booking/";
    public static void MapBookingsEndpoints(this IEndpointRouteBuilder routes)
    {
        var db = new DatabaseContext();
        var group = routes.MapGroup(BASE_URL)
            .WithOpenApi()
            .WithTags("Booking");

        group.MapGet("", () =>
            {
                // db.Add(new Room(RoomType.Simple, 125, RoomState.New, 3));
                // db.Add(new Room(RoomType.Double, 300, RoomState.ToBeRedone, 3));
                // db.Add(new Room(RoomType.Penthouse, 425, RoomState.BigDamage, 3));
                // db.SaveChanges();
                var availableRooms = db.Rooms.Where(r => r.IsRoomAvailable == true).ToList();
                return availableRooms;
            })
            .WithName("GetAvailableRooms");

        group.MapPost("", () => { return "hello POST"; })
            .WithName("CreateBooking");
    }
}