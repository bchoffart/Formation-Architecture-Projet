using System.Text.RegularExpressions;
using GestionHotel.Apis2.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.Apis2.Services;

public class UserService
{
    private DatabaseContext _db = new DatabaseContext();

    private bool ApplyUserVerifications(User user)
    {
        if (user.Password.Length < 10) return false;
        var addr = new System.Net.Mail.MailAddress(user.Email);
        return user.Email == addr.Address;
    }
    
    public bool RegisterAccount(User user)
    {
        if (ApplyUserVerifications(user)) return false;
        var createdUser = _db.Users.Add(user);
        _db.SaveChanges();
        return createdUser.State == EntityState.Added;
    }

    public User Login(string email, string password)
    {
        var foundUser = _db.Users.Where(u => u.Email == email).First();
        if (foundUser == null) throw new BadHttpRequestException("Cannot find User.", 422);
        if (foundUser.Password != password) throw new BadHttpRequestException("Please check your credentials.", 401);
        return foundUser;
    }
    
}