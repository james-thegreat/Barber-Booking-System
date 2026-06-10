using BarberBooking.Application.DTOs.Barbers;
using BarberBooking.Domain.Entities;
using BarberBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarbersController : ControllerBase
{
    private readonly BarberDbContext _context;

    public BarbersController(BarberDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<BarberDto>>> GetBarbers()
    {
        var barbers = await _context.Barbers
            .Select(b => new BarberDto
            {
                Id = b.Id,
                DisplayName = b.DisplayName,
                Bio = b.Bio,
                IsActive = b.IsActive
            })
            .ToListAsync();

        return Ok(barbers);
    }

    [HttpPost]
    public async Task<ActionResult<BarberDto>> CreateBarber(CreateBarberDto dto)
    {
        var barber = new Barber
        {
            DisplayName = dto.DisplayName,
            Bio = dto.Bio,
            IsActive = true
        };

        _context.Barbers.Add(barber);
        await _context.SaveChangesAsync();

        var barberDto = new BarberDto
        {
            Id = barber.Id,
            DisplayName = barber.DisplayName,
            Bio = barber.Bio,
            IsActive = barber.IsActive
        };

        return CreatedAtAction(nameof(GetBarberById), new { id = barber.Id }, barberDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BarberDto>> GetBarberById(int id)
    {
        var barber = await _context.Barbers
            .Where(b => b.Id == id)
            .Select(b => new BarberDto
            {
                Id = b.Id,
                DisplayName = b.DisplayName,
                Bio = b.Bio,
                IsActive = b.IsActive
            })
            .FirstOrDefaultAsync();

        if (barber == null)
        {
            return NotFound();
        }

        return Ok(barber);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBarber(int id, UpdateBarberDto dto)
    {
        var barber = await _context.Barbers.FindAsync(id);

        if (barber == null)
        {
            return NotFound();
        }

        barber.DisplayName = dto.DisplayName;
        barber.Bio = dto.Bio;
        barber.IsActive = dto.IsActive;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBarber(int id)
    {
        var barber = await _context.Barbers.FindAsync(id);

        if (barber == null)
        {
            return NotFound();
        }

        _context.Barbers.Remove(barber);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}