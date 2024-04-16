using System.Text.Json.Serialization;

namespace GestionHotel.Apis2.Controllers;

public class RegistrationInput(string email, string password, string lastName, string firstName)
{
    [JsonInclude]
    public readonly string Email = email;
    [JsonInclude]
    public readonly string Password = password;
    [JsonInclude]
    public readonly string LastName = lastName;
    [JsonInclude]
    public readonly string FirstName = firstName;
}