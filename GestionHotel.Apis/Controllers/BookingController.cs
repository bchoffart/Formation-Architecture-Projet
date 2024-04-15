using Microsoft.AspNetCore.Mvc;

namespace GestionHotel.Apis.Controllers;

public class BookingController : Controller
{
    // GET
    public void Index()
    {
        Console.WriteLine("Mon endpoint");
    }
}