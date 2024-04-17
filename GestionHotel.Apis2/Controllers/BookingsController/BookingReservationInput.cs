using System.Text.Json.Serialization;
using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Controllers;

public class BookingReservationInput
{
    [JsonInclude]
    public string ClientId;
    [JsonInclude]
    public string RoomId;
    [JsonInclude]
    public DateTime StartDate;
    [JsonInclude]
    public DateTime EndDate;
    [JsonInclude] public PaymentMethod? PaymentMethod;

    public BookingReservationInput(string clientId, string roomId, DateTime startDate, DateTime endDate)
    {
        ClientId = clientId;
        RoomId = roomId;
        StartDate = startDate;
        EndDate = endDate;
        PaymentMethod = Models.Enums.PaymentMethod.Other;
    }
    
    public BookingReservationInput(string clientId, string roomId, DateTime startDate, DateTime endDate, PaymentMethod paymentMethod)
    {
        ClientId = clientId;
        RoomId = roomId;
        StartDate = startDate;
        EndDate = endDate;
        PaymentMethod = paymentMethod;
    }
}