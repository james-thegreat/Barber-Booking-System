using BarberBooking.Application.DTOs.BarberAvailabilities;
using BarberBooking.Infrastructure.Data;
using BarberBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarberAvailabilitiesController : ControllerBase
{
    private readonly BarberDbContext _context;

    public BarberAvailabilitiesController(BarberDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BarberAvailabilityResponseDto>>> GetBarberAvailabilities()
    {
        var availabilities = await _context.BarberAvailabilities
            .Include(availability => availability.Barber)
            .Select(availability => new BarberAvailabilityResponseDto
            {
                Id = availability.Id,
                BarberId = availability.BarberId,
                BarberName = availability.Barber.DisplayName,
                DayOfWeek = availability.DayOfWeek,
                StartTime = availability.StartTime,
                EndTime = availability.EndTime
            })
            .ToListAsync();

        return Ok(availabilities);
    }

    [HttpGet("barber/{barberId}")]
    public async Task<ActionResult<IEnumerable<BarberAvailabilityResponseDto>>> GetAvailabilityForBarber(int barberId)
    {
        var availabilities = await _context.BarberAvailabilities
            .Include(availability => availability.Barber)
            .Where(availability => availability.BarberId == barberId)
            .Select(availability => new BarberAvailabilityResponseDto
            {
                Id = availability.Id,
                BarberId = availability.BarberId,
                BarberName = availability.Barber.DisplayName,
                DayOfWeek = availability.DayOfWeek,
                StartTime = availability.StartTime,
                EndTime = availability.EndTime
            })
            .ToListAsync();

        return Ok(availabilities);
    }

    [HttpPost]
    public async Task<ActionResult<BarberAvailabilityResponseDto>> CreateBarberAvailability(CreateBarberAvailabilityDto createDto)
    {
        var barber = await _context.Barbers.FindAsync(createDto.BarberId);

        if (barber == null)
        {
            return BadRequest($"Barber with ID {createDto.BarberId} does not exist.");
        }

        if (createDto.StartTime >= createDto.EndTime)
        {
            return BadRequest("Start time must be before end time.");
        }

        var availability = new BarberAvailability
        {
            BarberId = createDto.BarberId,
            DayOfWeek = createDto.DayOfWeek,
            StartTime = createDto.StartTime,
            EndTime = createDto.EndTime
        };

        _context.BarberAvailabilities.Add(availability);
        await _context.SaveChangesAsync();

        var responseDto = new BarberAvailabilityResponseDto
        {
            Id = availability.Id,
            BarberId = availability.BarberId,
            BarberName = barber.DisplayName,
            DayOfWeek = availability.DayOfWeek,
            StartTime = availability.StartTime,
            EndTime = availability.EndTime
        };

        return CreatedAtAction(
            nameof(GetAvailabilityForBarber),
            new { barberId = availability.BarberId },
            responseDto
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBarberAvailability(int id, UpdateBarberAvailabilityDto updateDto)
    {
        var availability = await _context.BarberAvailabilities.FindAsync(id);

        if (availability == null)
        {
            return NotFound($"Availability with ID {id} was not found.");
        }

        if (updateDto.StartTime >= updateDto.EndTime)
        {
            return BadRequest("Start time must be before end time.");
        }

        availability.DayOfWeek = updateDto.DayOfWeek;
        availability.StartTime = updateDto.StartTime;
        availability.EndTime = updateDto.EndTime;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBarberAvailability(int id)
    {
        var availability = await _context.BarberAvailabilities.FindAsync(id);

        if (availability == null)
        {
            return NotFound($"Availability with ID {id} was not found.");
        }

        _context.BarberAvailabilities.Remove(availability);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}