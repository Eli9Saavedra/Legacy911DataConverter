# Database Design

![Status](https://img.shields.io/badge/status-complete-brightgreen)

> Initial SQL Server schema design for Legacy911DataConverter v1.

---

## Logical Tables

### Incidents

| Column | Type | Constraints |
| --- | --- | --- |
| Id | int | PK, identity |
| IncidentNumber | nvarchar(50) | Required, unique |
| CallType | nvarchar(100) | Required |
| OccurredAtUtc | datetime2 | Required |
| Status | nvarchar(20) | Required |
| Location | nvarchar(200) | Required (default "Unknown") |
| Priority | nvarchar(30) | Required (default "Unspecified") |
| BatchId | uniqueidentifier | FK to ConversionBatches(Id) |

### RespondingUnits

| Column | Type | Constraints |
| --- | --- | --- |
| Id | int | PK, identity |
| UnitCode | nvarchar(50) | Required, unique |
| UnitType | nvarchar(100) | Required |
| Agency | nvarchar(100) | Required |
| IsActive | bit | Required |
| BatchId | uniqueidentifier | FK to ConversionBatches(Id), nullable |

### ConversionBatches

| Column | Type | Constraints |
| --- | --- | --- |
| Id | uniqueidentifier | PK |
| ImportedAtUtc | datetime2 | Required |
| SourceType | nvarchar(20) | Required |
| TotalRecords | int | Required |
| SuccessfulRecords | int | Required |
| FailedRecords | int | Required |

### ConversionErrors

| Column | Type | Constraints |
| --- | --- | --- |
| Id | int | PK, identity |
| BatchId | uniqueidentifier | Required, FK to ConversionBatches(Id) |
| RowNumber | int | Required |
| IncidentNumber | nvarchar(50) | Nullable |
| Field | nvarchar(100) | Required |
| Message | nvarchar(500) | Required |

---

## Key Indexes

1. Unique index on `Incidents.IncidentNumber`
2. Unique index on `RespondingUnits.UnitCode`
3. Nonclustered index on `ConversionErrors.BatchId`
4. Nonclustered index on `Incidents.BatchId`

---

## Referential Rules

1. Deleting a `ConversionBatch` should cascade delete related `ConversionErrors`.
2. Deleting a `ConversionBatch` should be restricted for `Incidents` in v1 to preserve auditability.

---

## ERD (Text)

```text
ConversionBatches (1) ----< (many) ConversionErrors
ConversionBatches (1) ----< (many) Incidents
ConversionBatches (1) ----< (many) RespondingUnits [optional]
```

---

## Migration Notes

1. Implement schema in EF Core migrations after entities/configurations are added.
2. Seed only synthetic sample data; never seed real public safety records.
