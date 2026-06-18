using System.ComponentModel.DataAnnotations;

namespace BarberBooking.Application.DTOs.Appointments;

public class UpdateAppointmentDto
{
    [Required]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    public string CustomerPhone { get; set; } = string.Empty;

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public int BarberId { get; set; }

    [Required]
    public int ServiceId { get; set; }

    public string Status { get; set; } = "Pending";
}