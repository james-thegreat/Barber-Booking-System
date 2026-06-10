using System.ComponentModel.DataAnnotations;

namespace BarberBooking.Application.DTOs.Services;

public class ServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int DurationMinutes { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}

public class CreateServiceDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Range(1, 480)]
    public int DurationMinutes { get; set; }

    [Range(0, 1000)]
    public decimal Price { get; set; }
}

public class UpdateServiceDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Range(1, 480)]
    public int DurationMinutes { get; set; }

    [Range(0, 1000)]
    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true;
}