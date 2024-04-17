using System.Text.Json.Serialization;
using GestionHotel.Apis2.Models;
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
    [JsonInclude]
    public PaymentMethod PaymentMethod { get; private set; }
    [JsonInclude]
    public Payment Payment { get; set; }

    public BookingReservationInput(string clientId, string roomId, DateTime startDate, DateTime endDate)
    {
        ClientId = clientId;
        RoomId = roomId;
        StartDate = startDate;
        EndDate = endDate;
        PaymentMethod = PaymentMethod.Other;
    }
    
    public BookingReservationInput(string clientId, string roomId, DateTime startDate, DateTime endDate, PaymentMethod paymentMethod, string creditCard, string expiry, string amount)
    {
        ClientId = clientId;
        RoomId = roomId;
        StartDate = startDate;
        EndDate = endDate;
        PaymentMethod = paymentMethod;
        Payment = new Payment(amount, creditCard, expiry);
    }
}