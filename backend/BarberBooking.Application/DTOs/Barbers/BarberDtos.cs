using System.ComponentModel.DataAnnotations;

namespace BarberBooking.Application.DTOs.Barbers;

public class BarberDto
{
    public int Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public bool IsActive { get; set; }
}

public class CreateBarberDto
{
    [Required]
    public string DisplayName { get; set; } = string.Empty;

    public string? Bio { get; set; }
}

public class UpdateBarberDto
{
    [Required]
    public string DisplayName { get; set; } = string.Empty;

    public string? Bio { get; set; }

    public bool IsActive { get; set; } = true;
}