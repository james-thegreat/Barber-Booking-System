using Microsoft.EntityFrameworkCore;
using BarberBooking.Domain.Entities;

namespace BarberBooking.Infrastructure.Data;

public class BarberDbContext : DbContext
{
    public BarberDbContext(DbContextOptions<BarberDbContext> options)
        : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }
}