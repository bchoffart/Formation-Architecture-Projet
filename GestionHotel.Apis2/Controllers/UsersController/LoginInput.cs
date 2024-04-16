using System.Text.Json.Serialization;

namespace GestionHotel.Apis2.Controllers;

public class LoginInput(string email, string password)
{
    [JsonInclude]
    public string Email = email;
    [JsonInclude]
    public string Password = password;
}