using BarberBooking.Application.DTOs.Appointments;
using BarberBooking.Domain.Entities;
using BarberBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly BarberDbContext _context;

    public AppointmentsController(BarberDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<List<AppointmentDto>>> GetAppointments()
    {
        var appointments = await _context.Appointments
            .Include(a => a.Barber)
            .Include(a => a.Service)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                CustomerName = a.CustomerName,
                CustomerPhone = a.CustomerPhone,
                AppointmentTime = a.AppointmentTime,
                Status = a.Status,
                BarberId = a.BarberId,
                BarberName = a.Barber != null ? a.Barber.DisplayName : null,
                ServiceId = a.ServiceId,
                ServiceName = a.Service != null ? a.Service.Name : null
            })
            .ToListAsync();

        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
    {
        var appointment = await _context.Appointments
            .Include(a => a.Barber)
            .Include(a => a.Service)
            .Where(a => a.Id == id)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                CustomerName = a.CustomerName,
                CustomerPhone = a.CustomerPhone,
                AppointmentTime = a.AppointmentTime,
                Status = a.Status,
                BarberId = a.BarberId,
                BarberName = a.Barber != null ? a.Barber.DisplayName : null,
                ServiceId = a.ServiceId,
                ServiceName = a.Service != null ? a.Service.Name : null
            })
            .FirstOrDefaultAsync();

        if (appointment is null)
        {
            return NotFound();
        }

        return Ok(appointment);
    }

    [HttpPost]
    public async Task<ActionResult<Appointment>> CreateAppointment(CreateAppointmentDto dto)
    {
        var barberExists = await _context.Barbers.AnyAsync(b => b.Id == dto.BarberId);

        if (!barberExists)
        {
            return BadRequest("Invalid BarberId. Barber does not exist.");
        }

        var serviceExists = await _context.Services.AnyAsync(s => s.Id == dto.ServiceId);

        if (!serviceExists)
        {
            return BadRequest("Invalid ServiceId. Service does not exist.");
        }

        var appointment = new Appointment
        {
            CustomerName = dto.CustomerName,
            CustomerPhone = dto.CustomerPhone,
            AppointmentTime = dto.AppointmentTime,
            BarberId = dto.BarberId,
            ServiceId = dto.ServiceId,
            Status = "Pending"
        };

        _context.Appointments.Add(appointment);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetAppointment),
            new { id = appointment.Id },
            appointment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(
        int id,
        UpdateAppointmentDto dto)
    {
        var barberExists = await _context.Barbers.AnyAsync(b => b.Id == dto.BarberId);

        if (!barberExists)
        {
            return BadRequest("Invalid BarberId. Barber does not exist.");
        }

        var serviceExists = await _context.Services.AnyAsync(s => s.Id == dto.ServiceId);

        if (!serviceExists)
        {
            return BadRequest("Invalid ServiceId. Service does not exist.");
        }

        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        appointment.CustomerName = dto.CustomerName;
        appointment.CustomerPhone = dto.CustomerPhone;
        appointment.AppointmentTime = dto.AppointmentTime;
        appointment.Status = dto.Status;
        appointment.BarberId = dto.BarberId;
        appointment.ServiceId = dto.ServiceId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        _context.Appointments.Remove(appointment);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}