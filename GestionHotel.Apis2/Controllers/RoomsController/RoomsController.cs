using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;
using GestionHotel.Apis2.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly RoomsService _roomsService = new RoomsService();
    
    // DEBUG ROUTE : Create rooms. - TO BE REMOVED -
    [CustomAuthorization(UserRole.Admin)]
    [HttpGet("create-rooms")]
    public void CreateRooms()
    {
        var room1 = new Room(RoomType.Double, 125, RoomState.Clean, 5);
        var room2 = new Room(RoomType.Suite, 155, RoomState.BigDamage, 3);
        var room3 = new Room(RoomType.Simple, 200, RoomState.New, 2);
        _roomsService.Insert(room1);
        _roomsService.Insert(room2);
        _roomsService.Insert(room3);
    }
    
    [HttpGet("show-available-rooms")]
    [CustomAuthorization(UserRole.Receptionist, UserRole.Client)]
    public List<RoomResult> ShowAvailableRooms(string token)
    {
        var foundRooms = _roomsService.Select(r => r.IsRoomAvailable);
        return token switch
        {
            "Client" => foundRooms.Select(r => new RoomResult(r.Id, r.Type, r.Price, r.Capacity)).ToList(),
            "Receptionist" => foundRooms.Select(r => new RoomResult(
                    r.Id, r.Type, r.Price, r.State, r.Capacity, r.IsRoomAvailable, r.IsRoomClean))
                .ToList(),
            _ => throw new BadHttpRequestException("No rooms found", 404)
        };
    }

    [CustomAuthorization(UserRole.Housekeeper)]
    [HttpGet("show-unclean-rooms")]
    public List<Room?> ShowUncleanRooms()
    {
        return _roomsService.Select(r => !r.IsRoomClean);
    }

    [CustomAuthorization(UserRole.Housekeeper)]
    [HttpGet("clean-room/{roomId}")]
    public void CleanRoom(string roomId)
    {
        _roomsService.CleanRoom(roomId);
    }
}