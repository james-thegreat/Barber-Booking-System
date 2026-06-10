using BarberBooking.Application.DTOs.Services;
using BarberBooking.Domain.Entities;
using BarberBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly BarberDbContext _context;

    public ServicesController(BarberDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ServiceDto>>> GetServices()
    {
        var services = await _context.Services
            .Select(s => new ServiceDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                DurationMinutes = s.DurationMinutes,
                Price = s.Price,
                IsActive = s.IsActive
            })
            .ToListAsync();

        return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceDto>> GetServiceById(int id)
    {
        var service = await _context.Services
            .Where(s => s.Id == id)
            .Select(s => new ServiceDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                DurationMinutes = s.DurationMinutes,
                Price = s.Price,
                IsActive = s.IsActive
            })
            .FirstOrDefaultAsync();

        if (service == null)
        {
            return NotFound();
        }

        return Ok(service);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateService(int id, UpdateServiceDto dto)
    {
        var service = await _context.Services.FindAsync(id);

        if (service == null)
        {
            return NotFound();
        }

        service.Name = dto.Name;
        service.Description = dto.Description;
        service.DurationMinutes = dto.DurationMinutes;
        service.Price = dto.Price;
        service.IsActive = dto.IsActive;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ServiceDto>> CreateService(CreateServiceDto dto)
    {
        var service = new Service
        {
            Name = dto.Name,
            Description = dto.Description,
            DurationMinutes = dto.DurationMinutes,
            Price = dto.Price,
            IsActive = true
        };

        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        var serviceDto = new ServiceDto
        {
            Id = service.Id,
            Name = service.Name,
            Description = service.Description,
            DurationMinutes = service.DurationMinutes,
            Price = service.Price,
            IsActive = service.IsActive
        };

        return CreatedAtAction(nameof(GetServices), new { id = service.Id }, serviceDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        var service = await _context.Services.FindAsync(id);

        if (service == null)
        {
            return NotFound();
        }

        _context.Services.Remove(service);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}