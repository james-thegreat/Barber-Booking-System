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
public DbSet<BarberAvailability> BarberAvailabilities { get; set; }

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

        modelBuilder.Entity<BarberAvailability>()
            .HasOne(availability => availability.Barber)
            .WithMany(barber => barber.Availabilities)
            .HasForeignKey(availability => availability.BarberId);

        modelBuilder.Entity<Barber>().HasData(
            new Barber { Id = 1, DisplayName = "James", Bio = "Classic cuts and beard trims.", IsActive = true },
            new Barber { Id = 2, DisplayName = "Mike", Bio = "Skin fades and modern styles.", IsActive = true }
        );

        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Haircut", Description = "Standard haircut", DurationMinutes = 30, Price = 35, IsActive = true },
            new Service { Id = 2, Name = "Skin Fade", Description = "Fresh skin fade", DurationMinutes = 45, Price = 45, IsActive = true },
            new Service { Id = 3, Name = "Beard Trim", Description = "Beard shaping and tidy up", DurationMinutes = 20, Price = 20, IsActive = true }
        );

    modelBuilder.Entity<BarberAvailability>().HasData(
        new BarberAvailability
        {
            Id = 1,
            BarberId = 1,
            DayOfWeek = DayOfWeek.Monday,
            StartTime = new TimeSpan(9, 0, 0),
            EndTime = new TimeSpan(17, 0, 0)
        },
        new BarberAvailability
        {
            Id = 2,
            BarberId = 1,
            DayOfWeek = DayOfWeek.Tuesday,
            StartTime = new TimeSpan(9, 0, 0),
            EndTime = new TimeSpan(17, 0, 0)
        },
        new BarberAvailability
        {
            Id = 3,
            BarberId = 2,
            DayOfWeek = DayOfWeek.Monday,
            StartTime = new TimeSpan(10, 0, 0),
            EndTime = new TimeSpan(18, 0, 0)
        },
        new BarberAvailability
        {
            Id = 4,
            BarberId = 2,
            DayOfWeek = DayOfWeek.Tuesday,
            StartTime = new TimeSpan(10, 0, 0),
            EndTime = new TimeSpan(18, 0, 0)
        }
    );

    }
}