# Architecture

![Status](https://img.shields.io/badge/status-complete-brightgreen)

> v1 architecture for Legacy911DataConverter.

---

## Architecture Style

Layered architecture with clear responsibility boundaries:

```text
API Layer (Legacy911DataConverter.Api)
    -> Core Layer (Legacy911DataConverter.Core)
    -> Infrastructure Layer (Legacy911DataConverter.Infrastructure)
    -> SQL Server LocalDB
```

---

## Layer Responsibilities

### API

* Hosts ASP.NET Core Web API
* Exposes endpoints for imports and retrieval
* Maps HTTP models to core contracts
* Returns conversion summaries and errors

### Core

* Holds domain models and interfaces
* Defines validation and conversion business rules
* Remains independent of ASP.NET and EF implementation details

### Infrastructure

* Implements repositories/services
* Handles file parsing and persistence
* Contains EF Core DbContext and configurations

### Tests

* Validates core conversion and error scenarios
* Verifies import pipeline behavior and edge cases

---

## Runtime Flow

```text
Client submits import request
    -> API validates request shape
    -> Core conversion service validates records
    -> Infrastructure persists incidents/errors/batch
    -> API returns conversion summary
```

---

## Design Principles

1. Keep business rules in Core.
2. Isolate framework concerns in API/Infrastructure.
3. Treat conversion as batch-oriented, record-tolerant processing.
4. Preserve traceability from source row to persisted error.
