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
        User user = new User(input.email, input.firstName, input.lastName, input.password);
        return userService.RegisterAccount(user);
    }
    
    [HttpPost("login")]
    public User Login([FromBody] LoginInput input)
    {
        return userService.Login(input.email, input.password);
    }
}