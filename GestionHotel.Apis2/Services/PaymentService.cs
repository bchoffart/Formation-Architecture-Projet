using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Models.Enums;
using GestionHotel.Externals.PaiementGateways.Paypal;
using GestionHotel.Externals.PaiementGateways.Stripe;

namespace GestionHotel.Apis2.Services;

public class PaymentService
{
    private readonly PaypalGateway _paypalGateway = new PaypalGateway();
    private readonly StripeGateway _stripeGateway = new StripeGateway();
    
    public void HandlePayment(Payment payment)
    {
        
        switch (payment.PaymentMethod)
        {
            case PaymentMethod.Paypal:
                HandlePaypalPayment(payment);
                break;
            case PaymentMethod.Stripe:
            {
                HandleStripePayment(payment);
                break;
            }
            case PaymentMethod.Other:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(payment.PaymentMethod), payment.PaymentMethod, null);
        }
    }

    private void HandlePaypalPayment(Payment payment)
    {
        var actualPaymentPaypal = _paypalGateway.ProcessPaymentAsync(payment.CreditCard, payment.ExpiryDate, payment.Amount);
    }

    private void HandleStripePayment(Payment payment)
    {
        var stripePayementInfo = new StripePayementInfo
        {
            CardNumber = payment.CreditCard,
            ExpiryDate = payment.ExpiryDate,
            Amount = payment.Amount
        };
        var actualPayment = _stripeGateway.ProcessPaymentAsync(stripePayementInfo);
    }
}