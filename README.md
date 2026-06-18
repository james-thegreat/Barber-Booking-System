# Barber Booking System

## Project Overview

The Barber Booking System is a full-stack web application designed to help barber shops manage appointments, barbers, services, and booking availability.

This project is being built as a learning project to improve my skills in full-stack development using **ASP.NET Core Web API**, **Entity Framework Core**, **SQLite**, **Clean Architecture**, and eventually a **React + Vite frontend**.

The main goal of the system is to allow customers to book valid appointment times while preventing common booking issues such as double bookings or appointments outside a barber’s working hours.

---

## Purpose of the Project

Many small barber shops still manage bookings manually through phone calls, messages, or walk-ins. This can make it harder to track appointments, avoid double bookings, and manage barber availability.

This project aims to solve that problem by creating a simple booking system where:

- Customers can book appointments
- Barbers can have working availability
- Services can be added, updated, and removed
- Appointments are linked to both a barber and a service
- The system prevents invalid bookings
- Appointment data is stored in a relational database

---

## Tech Stack

### Backend

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Clean Architecture
- Swagger / OpenAPI

### Frontend

- React
- Vite
- JavaScript / TypeScript  
  *(planned for later milestones)*

### Tools

- Git
- GitHub
- GitHub Projects
- .NET CLI
- Visual Studio Code
- Swagger UI

---

## Current Project Status

The backend has completed the first three major milestones:

### Milestone 1 — Appointment CRUD API

Completed:

- Appointment entity
- SQLite database setup
- Entity Framework Core DbContext
- EF Core migrations
- Appointment DTOs
- AppointmentsController
- Create appointments
- Read appointments
- Update appointments
- Delete appointments
- Swagger testing

### Milestone 2 — Services, Barbers, and Relationships

Completed:

- Service entity
- Barber entity
- Service DTOs
- Barber DTOs
- ServicesController with full CRUD
- BarbersController with full CRUD
- Appointment linked to Barber
- Appointment linked to Service
- Barber has many Appointments
- Service has many Appointments
- EF Core relationship configuration
- Seed data for barbers and services
- Appointment responses include BarberName and ServiceName
- Appointment create/update validates BarberId and ServiceId

### Milestone 3 — Availability Scheduling and Double-Booking Prevention

Completed:

- BarberAvailability entity
- Barber has many availability records
- Availability DTOs
- BarberAvailabilitiesController with full CRUD
- EF Core migration for availability table
- Seed/default availability support
- Appointment updated from `AppointmentTime` to:
  - `StartTime`
  - `EndTime`
- Appointment creation validates:
  - Barber exists
  - Service exists
  - Start time is before end time
  - Appointment is inside barber availability
  - Appointment does not overlap existing bookings
- Appointment update validates:
  - Barber exists
  - Service exists
  - Start time is before end time
  - Appointment is inside barber availability
  - Appointment does not overlap existing bookings
  - Current appointment is ignored during overlap checks
- Refactored booking validation into helper methods
- Swagger tested valid and invalid booking scenarios

---

## Current Features

The project currently includes:

- Appointment CRUD API
- Service CRUD API
- Barber CRUD API
- Barber availability CRUD API
- SQLite database storage
- EF Core migrations
- Seed data
- DTO-based API requests and responses
- Relationship mapping between appointments, barbers, and services
- Booking validation rules
- Double-booking prevention
- Swagger UI for testing API endpoints

CRUD means the system can:

- Create records
- Read records
- Update records
- Delete records

---

## Booking Rules Implemented

The system now includes basic real-world booking rules.

### Availability Rule

A barber can only be booked during their working hours.

Example:

```text
Barber availability: Monday 09:00-17:00
Appointment: Monday 10:00-10:30
Result: Allowed
