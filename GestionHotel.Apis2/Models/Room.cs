﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Models;

public class Room
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string RoomId { get; set; }
    [Required]
    public RoomType Type { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public RoomState State { get; set; }
    [Required]
    public int Capacity { get; set; }
    public bool IsRoomClean { get; private set; }
    public bool IsRoomAvailable { get; private set; }

    public Room(RoomType type, double price, RoomState state, int capacity)
    {
        Type = type;
        Price = price;
        State = state;
        this.Capacity = capacity;
        this.IsRoomClean = true;
        this.IsRoomAvailable = true;
    }
}