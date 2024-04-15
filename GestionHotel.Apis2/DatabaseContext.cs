using GestionHotel.Apis2.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.Apis2;

public class DatabaseContext: DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }

    public string DbPath { get; }

    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "GestionHotel.db");
        Console.WriteLine(DbPath);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}