# API Design

![Status](https://img.shields.io/badge/status-complete-brightgreen)

> REST API contract plan for Legacy911DataConverter v1.

---

## Base URL

```text
https://localhost:{port}/api
```

---

## Endpoints

### 1) Import Legacy Incidents

**POST** `/imports/incidents`

Purpose: Process incident records from CSV-derived payload.

Request body (example):

```json
{
  "records": [
    {
      "incidentNumber": "INC-2026-0001",
      "callType": "Medical",
      "occurredAt": "2026-07-15T10:30:00Z",
      "status": "OPEN",
      "location": "123 Main St",
      "priority": "High"
    }
  ]
}
```

Response `200 OK` (example):

```json
{
  "batchId": "guid",
  "importedAtUtc": "2026-07-15T16:00:00Z",
  "totalRecords": 1,
  "successfulRecords": 1,
  "failedRecords": 0,
  "errors": []
}
```

### 2) Import Responding Units

**POST** `/imports/units`

Purpose: Process unit records from XML-derived payload.

### 3) Get Converted Incidents

**GET** `/imports/incidents`

Purpose: Retrieve stored converted incidents.

### 4) Get Conversion Errors

**GET** `/imports/errors`

Purpose: Retrieve conversion errors.

### 5) Get Conversion Batches

**GET** `/imports/batches`

Purpose: Retrieve conversion batch summaries.

---

## Error Contract

For request-level validation failures:

* `400 Bad Request` with descriptive message

For unexpected server failures:

* `500 Internal Server Error` with generic error payload

---

## API Conventions

1. Use UTC timestamps in all responses.
2. Use clear and stable DTO names.
3. Keep import endpoints idempotent only when duplicate detection rules permit.
4. Return summary data immediately after import.
