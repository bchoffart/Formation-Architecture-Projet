using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionHotel.Apis2.Models.Enums;

namespace GestionHotel.Apis2.Models;

public class User : BaseModel
{
    [Required]
    public string LastName { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

    public UserRole Role { get; set; }

    public User(string lastName, string firstName, string email, string password)
    {
        LastName = lastName;
        FirstName = firstName;
        Email = email;
        Password = password;
        Role = UserRole.Client;
    }

    public User(string lastName, string firstName, string email, string password, UserRole role)
    {
        LastName = lastName;
        FirstName = firstName;
        Email = email;
        Password = password;
        Role = role;
    }
}