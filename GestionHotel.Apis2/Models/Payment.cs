using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Models;

public class Payment
{
    public string Amount;
    public string CreditCard;
    public string ExpiryDate;
    public PaymentMethod PaymentMethod;

    public Payment(string amount, string creditCard, string expiryDate, PaymentMethod paymentMethod)
    {
        Amount = amount;
        CreditCard = creditCard;
        ExpiryDate = expiryDate;
        PaymentMethod = paymentMethod;
    }
}