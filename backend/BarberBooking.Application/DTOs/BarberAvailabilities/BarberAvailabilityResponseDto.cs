namespace BarberBooking.Application.DTOs.BarberAvailabilities;

public class BarberAvailabilityResponseDto
{
    public int Id { get; set; }

    public int BarberId { get; set; }

    public string BarberName { get; set; } = string.Empty;

    public DayOfWeek DayOfWeek { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }
}