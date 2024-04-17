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
    public string Amount;
    [JsonInclude]
    public string CreditCard;
    [JsonInclude]
    public string ExpiryDate;

    public readonly Payment Payment;
    public BookingReservationInput(string clientId, string roomId, DateTime startDate, DateTime endDate)
    {
        ClientId = clientId;
        RoomId = roomId;
        StartDate = startDate;
        EndDate = endDate;
        PaymentMethod = PaymentMethod.Other;
    }
    
    [JsonConstructor]
    public BookingReservationInput(string clientId, string roomId, DateTime startDate, DateTime endDate, PaymentMethod paymentMethod, string creditCard, string expiryDate, string amount)
    {
        ClientId = clientId;
        RoomId = roomId;
        StartDate = startDate;
        EndDate = endDate;
        PaymentMethod = paymentMethod;
        Payment = new Payment(amount, creditCard, expiryDate);
    }
}