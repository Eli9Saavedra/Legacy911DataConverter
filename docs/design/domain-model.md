# Domain Model

![Status](https://img.shields.io/badge/status-complete-brightgreen)

> Core domain entities for Legacy911DataConverter v1.

---

## Entities

### Incident

Represents a successfully converted legacy incident.

| Field | Type | Notes |
| --- | --- | --- |
| Id | int | Surrogate key |
| IncidentNumber | string | Unique business identifier |
| CallType | string | Normalized call classification |
| OccurredAtUtc | datetime | Normalized UTC timestamp |
| Status | string | OPEN, CLOSED, PENDING |
| Location | string | Optional source field with default |
| Priority | string | Optional source field with default |

### RespondingUnit

Represents a unit imported from XML reference data.

| Field | Type | Notes |
| --- | --- | --- |
| Id | int | Surrogate key |
| UnitCode | string | Unique unit identifier |
| UnitType | string | Unit category (e.g., Patrol, Fire, EMS) |
| Agency | string | Owning organization |
| IsActive | bool | Whether unit is active |

### ConversionBatch

Represents one import execution.

| Field | Type | Notes |
| --- | --- | --- |
| Id | guid | Batch identifier |
| ImportedAtUtc | datetime | Batch timestamp |
| SourceType | string | CSV or XML |
| TotalRecords | int | Processed rows |
| SuccessfulRecords | int | Valid converted rows |
| FailedRecords | int | Rejected rows |

### ConversionError

Represents one validation/mapping error.

| Field | Type | Notes |
| --- | --- | --- |
| Id | int | Surrogate key |
| BatchId | guid | FK to ConversionBatch |
| RowNumber | int | Source row position |
| IncidentNumber | string | Source identifier when available |
| Field | string | Field that failed |
| Message | string | Human-readable reason |

---

## Relationships

1. One `ConversionBatch` has many `ConversionError`.
2. One `ConversionBatch` can produce many `Incident`.
3. `RespondingUnit` is imported reference data and may relate to incidents in future versions.

---

## Aggregate and Boundary Notes

1. Conversion processing aggregate boundary is **ConversionBatch**.
2. `Incident` and `ConversionError` are outcomes of batch processing.
3. Validation rules live in Core to keep behavior framework-independent.
