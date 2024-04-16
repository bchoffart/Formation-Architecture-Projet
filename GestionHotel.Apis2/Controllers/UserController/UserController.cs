using GestionHotel.Apis2.Models;
using GestionHotel.Apis2.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private UserService userService = new UserService();
    
    [HttpPost("register")]
    public bool Register([FromBody] RegistrationInput input)
    {
        var user = new User(input.LastName, input.FirstName, input.Email, input.Password);
        return userService.RegisterAccount(user);
    }
    
    [HttpPost("login")]
    public UserWithoutPassword Login([FromBody] LoginInput input)
    {
        return userService.Login(input.Email, input.Password);
    }
}