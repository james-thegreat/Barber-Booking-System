# Barber Booking System

## Project Overview

The Barber Booking System is a full-stack web application designed to help barber shops manage appointments, services, and customers more efficiently.

This project is being built as a learning project to improve my skills in full-stack development using **ASP.NET Core Web API**, **Entity Framework Core**, **SQLite**, and eventually a **React frontend**.

The main goal of the system is to allow users to view available barber services and book appointments, while giving the barber shop a simple way to manage bookings.

---

## Purpose of the Project

Many small barber shops still manage bookings manually through phone calls, messages, or walk-ins. This can make it harder to track appointments, avoid double bookings, and manage services.

This project aims to solve that problem by creating a simple booking system where:

- Customers can book appointments
- Barbers can manage bookings
- Services can be added, updated, and removed
- Appointment data can be stored in a database

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
- Visual Studio Code
- .NET CLI

---

## Current Features

The project currently includes:

- Appointment entity
- Service entity
- SQLite database connection
- Entity Framework Core migrations
- Appointment CRUD API
- Service CRUD API
- Swagger UI for testing API endpoints

CRUD means the system can:

- Create records
- Read records
- Update records
- Delete records

---

## Project Structure

```text
BarberBooking.Api
BarberBooking.Application
BarberBooking.Domain
BarberBooking.Infrastructure
