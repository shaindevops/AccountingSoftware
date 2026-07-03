# PROJECT CONSTITUTION
## AccountingSoftware

---

# Project Overview

AccountingSoftware is a long-term Windows Desktop Accounting System built with .NET Framework and Windows Forms.

This project is NOT a prototype.

It is intended to become a professional, enterprise-grade accounting system that can be maintained, extended and modernized over many years without breaking compatibility.

The objective is to continuously improve the software while preserving its business logic and existing customer databases.

---

# Project Goals

The primary goals of this project are:

- High Performance
- Clean Architecture
- Maintainability
- Scalability
- Security
- Reliability
- Data Integrity
- Long-term Evolution

Every modification should move the project closer to these goals.

---

# Technology Stack

Platform:
- Windows Desktop

Framework:
- .NET Framework 4.8

UI:
- Windows Forms

ORM:
- Entity Framework 6

Database:
- SQL Server

Architecture:
- Layered Architecture

---

# Architecture

The architecture MUST remain unchanged.

The project consists of four layers.

## BE (Business Entities)

Responsibilities:

- Entities
- DTOs
- Enums
- Shared Models

This layer must NOT contain:

- Business Logic
- Database Logic
- UI Logic

---

## BLL (Business Logic Layer)

Responsibilities:

- Business Rules
- Validation
- Transaction Coordination
- Business Services
- Security
- Workflow Coordination

BLL is the heart of the application.

Every business rule belongs here.

---

## DAL (Data Access Layer)

Responsibilities:

- Entity Framework
- DbContext
- Repositories
- ADO.NET
- Stored Procedures
- Database Access
- Migrations

DAL must never contain business rules.

---

## SSG (Presentation Layer)

Responsibilities:

- Windows Forms
- User Interaction
- Display
- Input Collection

Presentation must NOT:

- Coordinate business workflows
- Execute business rules
- Handle transactions
- Access database directly

Forms should call only BLL.

---

# Architecture Rules

Never change the layered architecture.

Never bypass BLL.

Never allow Forms to access DAL directly.

Never move business rules into the UI.

Keep dependencies flowing in one direction only.

---

# Business Rules

Business rules belong ONLY inside BLL.

Examples:

Invoice Creation

Stock Movement

Order Processing

Payments

Receipts

Document Settlement

Inventory Updates

Account Balance Updates

These must never be implemented inside Forms.

---

# Transaction Rules

Any business operation that performs multiple database writes MUST execute inside a single transaction.

Examples:

Invoice

Order

Inventory Transfer

Payment

Receipt

Document Settlement

Stock Movement

AccountBook Updates

Rollback must occur whenever one step fails.

Partial success is unacceptable.

Data integrity is more important than performance.

---

# Refactoring Principles

Refactor carefully.

Never change business behavior unless:

- It is clearly a bug.
- It causes data corruption.
- It creates concurrency issues.
- It creates security vulnerabilities.
- It breaks transactional consistency.

Otherwise preserve existing behavior.

---

# Modernization Goals

Modernize the codebase without changing:

- Platform
- UI Technology
- Database
- Architecture

Improve:

Performance

Readability

Maintainability

Security

Reliability

Scalability

Developer Experience

---

# Code Quality

Continuously search for:

- Duplicate Code
- Dead Code
- Unused Variables
- Long Methods
- Large Forms
- Inverted Boolean Logic
- Magic Numbers
- Magic Strings
- Hardcoded Paths
- Hardcoded Connection Strings
- Resource Leaks
- Long-lived DbContext
- SQL Injection Risks
- Password Weaknesses
- Concurrency Problems
- Transaction Issues
- Performance Bottlenecks

Fix them whenever safe.

---

# Database Rules

DbContext should have the shortest lifetime possible.

Dispose every DbContext properly.

Never keep DbContext as a long-lived field.

Use ConnectionHelper.

Avoid duplicated SQL.

Use parameterized SQL.

Never concatenate SQL strings.

---

# Logging

Use AppLogger for application logging.

Never silently swallow exceptions.

Every unexpected exception should be logged.

Logging must never crash the application.

---

# Helper Classes

Before creating any Helper or Utility class:

Verify whether an existing helper already solves the problem.

Avoid creating unnecessary abstractions.

Create new helpers only when they provide clear architectural value.

---

# Performance

Avoid:

Repeated database queries

Duplicate data loading

Unnecessary allocations

Repeated LINQ evaluation

Large object creation inside loops

Optimize only when measurable.

Readability is preferred over micro-optimizations.

---

# Security

Passwords must never be reversible.

Use secure password hashing.

Avoid SQL Injection.

Validate user input.

Never expose sensitive information.

---

# Development Workflow

Every module should follow this sequence:

1. Audit
2. Explain Findings
3. Refactor
4. Verify
5. Commit

Do not skip any step.

---

# Git Workflow

Keep commits small.

One module per commit.

One feature per commit.

Avoid mixing unrelated changes.

Use descriptive commit messages.

---

# Code Review Rules

Do not only refactor.

Act as a Senior Software Engineer.

Continuously inspect the codebase for:

Architecture violations

Security issues

Performance issues

Concurrency bugs

Maintainability improvements

Scalability opportunities

Hidden business bugs

Always explain significant findings before implementing changes.

---

# Compatibility

Maintain compatibility with:

Existing databases

Existing customers

Existing business workflows

Do not introduce breaking changes unless explicitly requested.

---

# Long-Term Vision

This project is a long-term modernization effort.

The goal is not only cleaner code.

The goal is to build a robust, maintainable, scalable accounting platform that can continue evolving for many years while preserving compatibility with existing installations.

Every change should move the project toward that vision.

---

# Software Engineering Principles

Every change made to this project must follow modern software engineering principles.

## SOLID

### Single Responsibility Principle (SRP)

Every class should have only one responsibility.

Avoid classes that manage UI, business logic, and data access simultaneously.

---

### Open / Closed Principle (OCP)

Classes should be open for extension but closed for modification.

Prefer extending existing behavior instead of rewriting stable code.

---

### Liskov Substitution Principle (LSP)

Derived implementations should behave correctly wherever the base abstraction is expected.

---

### Interface Segregation Principle (ISP)

Prefer small, focused interfaces.

Do not force implementations to depend on methods they do not use.

---

### Dependency Inversion Principle (DIP)

Depend on abstractions whenever practical.

Avoid tight coupling between modules.

---

# Clean Code Principles

Code should always be:

- Readable
- Predictable
- Self-documenting
- Consistent

Prefer expressive naming over comments.

If a comment explains confusing code, improve the code instead.

---

# DRY (Don't Repeat Yourself)

Avoid duplicate logic.

If identical business logic appears multiple times, centralize it.

Do not duplicate SQL.

Do not duplicate validation.

Do not duplicate business workflows.

---

# KISS (Keep It Simple)

Choose the simplest implementation that correctly solves the problem.

Avoid unnecessary abstractions.

Avoid over-engineering.

---

# YAGNI (You Aren't Gonna Need It)

Do not build features that are not currently required.

Avoid speculative development.

Implement only what provides real value today.

---

# Separation of Concerns

Each layer must focus only on its own responsibility.

BE:
Data Models only.

BLL:
Business Logic only.

DAL:
Database Access only.

SSG:
Presentation only.

Never mix responsibilities.

---

# High Cohesion

Related behavior should stay together.

Business rules should live together inside the Business Layer.

---

# Low Coupling

Modules should know as little as possible about one another.

Changes in one module should have minimal impact on others.

---

# Composition over Inheritance

Prefer composition whenever inheritance is unnecessary.

Avoid deep inheritance hierarchies.

---

# Defensive Programming

Validate all external input.

Fail early.

Fail clearly.

Never silently ignore errors.

Always preserve application stability.

---

# Fail Fast

When configuration or infrastructure is invalid, fail immediately with a clear error.

Avoid hiding serious configuration problems.

---

# Principle of Least Astonishment

Code should behave exactly as another experienced developer would expect.

Avoid surprising side effects.

Avoid misleading method names.

---

# Data Integrity First

Performance is important.

Maintainability is important.

But data integrity is the highest priority.

Never sacrifice correctness for speed.

Accounting data must always remain consistent.

---

# Concurrency Safety

Whenever multiple users may execute the same operation simultaneously:

- Prevent race conditions.
- Protect critical sections.
- Use transactions where necessary.
- Preserve consistency under concurrent execution.

---

# Repository Guidelines

Repositories should perform only data access.

Repositories must never contain business rules.

Repositories should not coordinate workflows.

---

# Service Guidelines

Complex business workflows belong inside Business Services.

Examples:

- Create Invoice
- Create Order
- Transfer Inventory
- Register Payment
- Register Receipt
- Pass Accounting Document

These workflows should execute as a single business operation.

---

# Database Guidelines

Prefer Entity Framework for standard CRUD operations.

Use ADO.NET only where performance or stored procedures justify it.

Parameterize every SQL query.

Never concatenate SQL strings.

Keep DbContext lifetime as short as possible.

---

# Error Handling

Never swallow exceptions silently.

Log unexpected exceptions.

Return meaningful information when possible.

Never expose sensitive implementation details to end users.

---

# Performance Guidelines

Optimize only after identifying real bottlenecks.

Avoid:

- Duplicate queries
- N+1 queries
- Unnecessary allocations
- Excessive object creation
- Repeated database access

Readability should not be sacrificed for micro-optimizations.

---

# Refactoring Guidelines

Refactor incrementally.

Small commits.

Small reviews.

Small changes.

Always preserve working software.

Do not perform large-scale rewrites.

Improve the code continuously.

---

# Legacy Code Policy

Respect existing business logic.

Assume legacy behavior exists for a reason until proven otherwise.

When discovering suspicious behavior:

1. Verify whether it is intentional.
2. Determine whether it is a real bug.
3. Explain the impact.
4. Implement the safest correction.

Never rewrite working business logic without justification.

---

# Architectural Decision Policy

Before introducing:

- a new Helper
- a new Utility
- a new Service
- a new Pattern
- a new Library
- a new Dependency

first verify whether the existing architecture already provides an appropriate solution.

Keep the architecture as simple as possible.

Every abstraction should have a clear long-term benefit.

---

# Continuous Code Review

Throughout the project continuously search for:

- Hidden bugs
- Race conditions
- Security vulnerabilities
- Memory leaks
- Resource leaks
- Business logic inside UI
- Transaction violations
- Dead code
- Duplicate code
- Long methods
- God classes
- Performance bottlenecks
- Maintainability improvements

Act as a Senior Software Architect during every refactoring phase.

Do not simply make the code cleaner.

Improve the overall architecture while preserving compatibility.
