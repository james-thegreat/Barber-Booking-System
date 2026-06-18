namespace BarberBooking.Application.DTOs.Appointments;

public class AppointmentDto
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerPhone { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public string Status { get; set; } = string.Empty;

    public int BarberId { get; set; }

    public string? BarberName { get; set; }

    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }
}