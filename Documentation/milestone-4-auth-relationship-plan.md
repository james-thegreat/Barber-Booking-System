# Milestone 4 — User Relationship Plan

## Purpose

This document records how the new User authentication model will connect to future booking ownership, barber dashboards, and admin-only features.

## Current Milestone Decision

Milestone 4 creates the authentication foundation:

- User entity
- UserRole enum
- Register endpoint
- Login endpoint foundation
- Password hashing
- Auth DTOs

This milestone does not yet enforce appointment ownership because JWT authentication has not been added yet.

## Future Relationship: Customer User to Appointment

A customer user should eventually own appointments.

Recommended future Appointment fields:

```csharp
public Guid CustomerUserId { get; set; }
public User CustomerUser { get; set; } = null!;