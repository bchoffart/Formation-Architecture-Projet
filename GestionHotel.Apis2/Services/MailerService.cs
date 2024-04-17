namespace GestionHotel.Apis2.Services;

public class MailerService
{
    public void SendEmail(string email, string subject)
    {
        Console.WriteLine($"Sending email to {email}...");
    }
}