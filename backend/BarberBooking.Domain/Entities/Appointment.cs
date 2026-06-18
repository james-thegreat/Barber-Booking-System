namespace BarberBooking.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerPhone { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Status { get; set; } = "Pending";

    public int BarberId { get; set; }
    public Barber? Barber { get; set; }
    
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
}