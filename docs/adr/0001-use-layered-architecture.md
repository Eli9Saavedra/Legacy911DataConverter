# ADR 0001: Use Layered Architecture

* **Status:** Accepted
* **Date:** 2026-07-15

## Context

The project needs clear separation between web/API concerns, business rules, and persistence details.

## Decision

Use layered architecture:

* API project for HTTP concerns
* Core project for domain and contracts
* Infrastructure project for persistence/parsing implementations

## Consequences

* Better maintainability and testability.
* Easier future swap of persistence or hosting details.
