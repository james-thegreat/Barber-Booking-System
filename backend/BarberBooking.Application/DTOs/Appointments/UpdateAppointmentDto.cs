namespace BarberBooking.Application.DTOs.Appointments;

public class UpdateAppointmentDto
{
    public string CustomerName { get; set; } = string.Empty;

    public string CustomerPhone { get; set; } = string.Empty;

    public string ServiceName { get; set; } = string.Empty;

    public DateTime AppointmentTime { get; set; }

    public string Status { get; set; } = string.Empty;
}