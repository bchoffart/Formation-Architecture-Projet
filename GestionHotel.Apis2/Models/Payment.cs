namespace GestionHotel.Apis2.Models;

public class Payment
{
    public string Amount;
    public string CreditCard;
    public string ExpiryDate;

    public Payment(string amount, string creditCard, string expiryDate)
    {
        Amount = amount;
        CreditCard = creditCard;
        ExpiryDate = expiryDate;
    }
}