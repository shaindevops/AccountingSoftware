# Task

Open and read the following file first:

`E:\windows\نرم افزار حسابداری\Software\SSGSQLEnterprise\Guid & Description.md`

This file is the single source of truth for the project. It contains the software vision, architecture, coding standards, technology stack, backend/frontend requirements, development rules, scalability goals, and all implementation guidelines.

After reading it completely:

* Understand the existing Windows accounting software.
* Analyze the entire solution.
* Find bugs, design issues, architectural problems, performance bottlenecks, duplicated code, and security weaknesses.
* Modernize the project while preserving business logic.
* Refactor the code where appropriate.
* Improve performance, maintainability, readability, and scalability.
* Keep the project clean, modular, and extensible.
* Follow the architecture, conventions, and rules defined in `Guid & Description.md`.
* Do not change business behavior unless it is clearly a bug or explicitly approved.
* Before implementing major changes, explain the reason and expected impact.
* When multiple solutions exist, choose the one that best supports long-term maintainability and extensibility.
* Maintain backward compatibility whenever possible.

Always use `Guid & Description.md` as the primary reference throughout the entire development process. If any instruction conflicts with the current implementation, ask for clarification before proceeding.



# Architecture

## Project Type

This is a Windows Desktop Accounting System built on a classic layered architecture. The existing architecture must be preserved and improved, not replaced.

## Layer Structure

### BE (Business Entities)

Contains only:

* Entity classes
* DTOs (if already located here)
* Enums
* Shared Models

No business logic should exist in this layer.

---

### BLL (Business Logic Layer)

Contains:

* Business Rules
* Validation
* Services
* Managers
* Application Logic
* Transaction Coordination

This layer is responsible for enforcing all accounting rules and business workflows.

---

### DAL (Data Access Layer)

Contains:

* Entity Framework
* DbContext
* Migrations
* Repositories
* Database Access
* SQL Operations

No business rules should be implemented here.

---

### PL (Presentation Layer)

Folder Name:

`SSG`

Contains:

* Windows Forms
* User Controls
* Reports
* UI Components

This layer is responsible only for user interaction.

---

# Development Rules

* Preserve the existing layered architecture.
* Do NOT convert the project to Clean Architecture, Onion Architecture, Hexagonal Architecture, or Microservices.
* Do NOT replace Windows Forms with WPF, MAUI, Avalonia, or Blazor.
* Do NOT move classes between layers unless there is a strong architectural reason.
* Respect the current project structure.
* New features must follow the existing architecture.
* Refactor only when it improves readability, maintainability, performance, or stability.
* Remove duplicated code whenever possible.
* Improve performance without changing business behavior.
* Fix bugs without breaking existing functionality.
* Follow SOLID principles where applicable without forcing unnecessary abstractions.
* Keep the codebase clean, modular, maintainable, and easy to extend.

# Your Mission

Study the entire solution before making changes.

Then:

1. Find bugs.
2. Detect performance bottlenecks.
3. Improve the user experience where appropriate.
4. Modernize outdated code.
5. Refactor carefully.
6. Improve database access efficiency.
7. Optimize Entity Framework usage.
8. Reduce unnecessary memory allocations.
9. Improve code readability.
10. Suggest improvements before implementing major architectural changes.

Always explain the reason for significant modifications before applying them.
Preserve the existing layered architecture unless I explicitly approve an architectural migration.