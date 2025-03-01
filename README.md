Ticket Management System Backend

Overview

This project is a .NET Core API designed to manage tickets efficiently using modern software design patterns and best practices.

Technologies Used:

.NET Core - Backend framework

Entity Framework Core - ORM for database interaction

SQL Server - Relational database

CQRS - Command Query Responsibility Segregation pattern

DDD (Domain-Driven Design) - Architectural approach for managing domain complexity

MediatR - Implements CQRS with in-process messaging

Sentry - Logging and error monitoring

Project Structure:

The project follows DDD and CQRS principles, ensuring modularity and maintainability. Key layers include:

Application Layer - Contains use cases, commands, queries, and handlers

Domain Layer - Defines business logic and aggregates

Infrastructure Layer - Handles database interactions and external integrations

API Layer - Exposes endpoints for client applications
