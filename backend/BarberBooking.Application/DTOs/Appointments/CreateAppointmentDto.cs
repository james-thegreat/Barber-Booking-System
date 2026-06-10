using System.ComponentModel.DataAnnotations;


namespace BarberBooking.Application.DTOs.Appointments;

public class CreateAppointmentDto
{
    [Required]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    public string CustomerPhone { get; set; } = string.Empty;

    [Required]
    public DateTime AppointmentTime { get; set; }
    [Required]
    public int BarberId { get; set; }
    [Required]
    public int ServiceId { get; set; }
}