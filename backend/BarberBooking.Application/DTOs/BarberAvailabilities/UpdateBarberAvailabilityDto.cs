using System.ComponentModel.DataAnnotations;

namespace BarberBooking.Application.DTOs.BarberAvailabilities;

public class UpdateBarberAvailabilityDto
{
    [Required]
    public DayOfWeek DayOfWeek { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    public bool IsActive { get; set; } = true;
}