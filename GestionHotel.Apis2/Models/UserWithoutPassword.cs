using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Models;

public class UserWithoutPassword(string userId, string lastName, string firstName, string email, UserRole role)
{
    public string UserId { get; set; } = userId;
    public string LastName { get; set; } = lastName;
    public string FirstName { get; set; } = firstName;
    public string Email { get; set; } = email;
    public UserRole Role { get; set; } = role;
}