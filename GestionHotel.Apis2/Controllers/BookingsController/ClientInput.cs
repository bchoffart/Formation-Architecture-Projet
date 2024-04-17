using System.Text.Json.Serialization;
using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Controllers;

public class ClientInput
{
    [JsonInclude] 
    public string Email;
    [JsonInclude]
    public string Amount;
    [JsonInclude]
    public string CreditCard;
    [JsonInclude]
    public string ExpiryDate;
    [JsonInclude]
    public PaymentMethod PaymentMethod;
    public Payment Payment { get; private set; }

    [JsonConstructor]
    public ClientInput(string email, string amount, string creditCard, string expiryDate, PaymentMethod paymentMethod)
    {
        Email = email;
        Payment = new Payment(amount, creditCard, expiryDate, paymentMethod);
    }
}