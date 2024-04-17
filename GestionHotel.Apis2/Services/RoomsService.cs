using GestionHotel.Apis2.Models;

namespace GestionHotel.Apis2.Services;

public class RoomsService : GenericCrudService<Room>
{
    public void CleanRoom(string roomId)
    {
        var foundRoom = this.SelectById(roomId);
        if (foundRoom == null) return;
        foundRoom.CleanRoom();
        this.Update(foundRoom);
    }

    public void MarkRoomForCleaning(string roomId)
    {
        var foundRoom = this.SelectById(roomId);
        if (foundRoom == null) return;
        foundRoom.MarkRoomForCleaning();
        this.Update(foundRoom);
    }

    public void ChangeRoomAvailability(string roomId, bool available)
    {
        var foundRoom = this.SelectById(roomId);
        if (foundRoom == null) return;
        foundRoom.ChangeRoomAvailability(available);
        this.Update(foundRoom);
    }
    
    public void ChangeRoomOccupation(string roomId, bool occupied)
    {
        var foundRoom = this.SelectById(roomId);
        if (foundRoom == null) return;
        foundRoom.ChangeRoomOccupation(occupied);
        this.Update(foundRoom);
    }
}