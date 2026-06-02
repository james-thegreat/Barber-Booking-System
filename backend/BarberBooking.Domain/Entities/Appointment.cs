namespace BarberBooking.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public DateTime AppointmentDate { get; set; }

    public string Service { get; set; } = string.Empty;
}