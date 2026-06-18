using System.ComponentModel.DataAnnotations;

namespace BarberBooking.Application.DTOs.BarberAvailabilities;

public class CreateBarberAvailabilityDto
{
    [Required]
    public int BarberId { get; set; }

    [Required]
    public DayOfWeek DayOfWeek { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }
}