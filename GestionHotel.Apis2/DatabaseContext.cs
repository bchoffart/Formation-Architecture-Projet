using GestionHotel.Apis2.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.Apis2;

public class DatabaseContext: DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=./GestionHotel.db");
}