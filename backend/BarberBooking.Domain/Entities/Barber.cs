namespace BarberBooking.Domain.Entities;

public class Barber
{
    public int Id { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public string? Bio { get; set; }

    public bool IsActive { get; set; } = true;

    public List<Appointment> Appointments { get; set; } = new();
}