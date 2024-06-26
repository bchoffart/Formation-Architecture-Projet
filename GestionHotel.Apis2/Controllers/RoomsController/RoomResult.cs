﻿using System.ComponentModel.DataAnnotations;
using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;


public class RoomResult: BaseModel
{
    public RoomType Type { get; set; }
    public double Price { get; set; }
    public RoomState State { get; set; }
    public int Capacity { get; set; }
    public bool IsRoomClean { get; private set; }
    public bool IsRoomAvailable { get; private set; }

    public RoomResult(string id, RoomType type, double price, int capacity)
    {
        Id = id;
        Type = type;
        Price = price;
        Capacity = capacity;
    }

    public RoomResult(string id, RoomType type, double price, RoomState state, int capacity, bool isRoomClean, bool isRoomAvailable)
    {
        Id = id;
        Type = type;
        Price = price;
        State = state;
        Capacity = capacity;
        IsRoomClean = isRoomClean;
        IsRoomAvailable = isRoomAvailable;
    }
}