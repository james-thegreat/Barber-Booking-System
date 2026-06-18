namespace BarberBooking.Domain.Entities;

public class Barber
{
    public int Id { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public string? Bio { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<BarberAvailability> Availabilities { get; set; } = new List<BarberAvailability>();
}