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
    public async Task<ActionResult<List<Appointment>>> GetAppointments()
    {
        return await _context.Appointments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> GetAppointment(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        return appointment;
    }

    [HttpPost]
    public async Task<ActionResult<Appointment>> CreateAppointment(CreateAppointmentDto dto)
    {
        var appointment = new Appointment
        {
            CustomerName = dto.CustomerName,
            CustomerPhone = dto.CustomerPhone,
            ServiceName = dto.ServiceName,
            AppointmentTime = dto.AppointmentTime,
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
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        appointment.CustomerName = dto.CustomerName;
        appointment.CustomerPhone = dto.CustomerPhone;
        appointment.ServiceName = dto.ServiceName;
        appointment.AppointmentTime = dto.AppointmentTime;
        appointment.Status = dto.Status;

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