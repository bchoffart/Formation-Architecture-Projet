using GestionHotel.Apis2.Models;

namespace GestionHotel.Apis2.Services;

public class RoomsService : GenericCrudService<Room>
{
    public void CleanRoom(string roomId)
    {
        var foundRoom = this.Select(r => r.Id == roomId);
        if (foundRoom.Count != 1) return;
        foundRoom[0].CleanRoom();
        this.Update(foundRoom[0]);
    }

    public void MarkRoomForCleaning(string roomId)
    {
        var foundRoom = this.Select(r => r.Id == roomId);
        if (foundRoom.Count != 1) return;
        foundRoom[0].MarkRoomForCleaning();
        this.Update(foundRoom[0]);
    }
}