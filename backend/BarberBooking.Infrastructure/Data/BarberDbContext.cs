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
    public DbSet<Service> Services { get; set; }
    public DbSet<Barber> Barbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Barber)
            .WithMany(b => b.Appointments)
            .HasForeignKey(a => a.BarberId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Service)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.ServiceId);

        modelBuilder.Entity<Barber>().HasData(
            new Barber { Id = 1, DisplayName = "James", Bio = "Classic cuts and beard trims.", IsActive = true },
            new Barber { Id = 2, DisplayName = "Mike", Bio = "Skin fades and modern styles.", IsActive = true }
        );

        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Haircut", Description = "Standard haircut", DurationMinutes = 30, Price = 35, IsActive = true },
            new Service { Id = 2, Name = "Skin Fade", Description = "Fresh skin fade", DurationMinutes = 45, Price = 45, IsActive = true },
            new Service { Id = 3, Name = "Beard Trim", Description = "Beard shaping and tidy up", DurationMinutes = 20, Price = 20, IsActive = true }
        );
    }
}