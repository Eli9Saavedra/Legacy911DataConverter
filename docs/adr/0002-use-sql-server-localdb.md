# ADR 0002: Use SQL Server LocalDB for v1

* **Status:** Accepted
* **Date:** 2026-07-15

## Context

v1 needs simple local persistence with SQL Server compatibility and low setup friction.

## Decision

Use SQL Server LocalDB as the development database for v1.

## Consequences

* Easy onboarding on Windows developer environments.
* Good fit for EF Core and later migration to full SQL Server.
