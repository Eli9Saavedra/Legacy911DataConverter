# Software Requirements Specification (SRS)

![Status](https://img.shields.io/badge/status-complete-brightgreen)
![Version](https://img.shields.io/badge/version-1.0-blue)

> This SRS defines functional and non-functional requirements for Legacy911DataConverter v1.

---

## 1. Purpose

Legacy911DataConverter v1 is a backend API that imports legacy public safety data, validates it, converts valid records to normalized entities, persists conversion outcomes, and reports conversion results.

---

## 2. Scope

The system supports:

* CSV incident import
* XML responding unit import
* Record-level validation and normalization
* Conversion batch tracking
* Conversion error logging
* API-based retrieval of converted data and summaries

Out of scope includes authentication, frontend UI, cloud deployment, and live emergency-service integration.

---

## 3. Stakeholders

| Stakeholder | Need |
| --- | --- |
| Developer | Build and practice end-to-end data conversion workflows |
| Reviewer | Evaluate system quality, design decisions, and testing approach |
| Hiring Team | Evaluate practical backend and data-engineering capability |

---

## 4. System Context

The API receives legacy source files (CSV/XML), performs validation and mapping, writes results to SQL Server, and exposes REST endpoints for review and reporting.

---

## 5. Functional Requirements

### 5.1 File Import

1. The system shall accept incident import payloads derived from CSV data.
2. The system shall accept responding unit import payloads derived from XML data.
3. The system shall process each import as a single conversion batch.

### 5.2 Validation

4. The system shall validate required incident fields: incident number, call type, occurred date/time, and status.
5. The system shall validate that occurred date/time is parseable into a valid UTC timestamp.
6. The system shall validate status values against an allowed set.
7. The system shall detect duplicate incident numbers.
8. The system shall continue processing remaining records when one or more records fail validation.

### 5.3 Mapping and Persistence

9. The system shall map valid legacy records into normalized incident entities.
10. The system shall persist valid records to SQL Server.
11. The system shall persist invalid records as conversion errors with field-level context.
12. The system shall track each import with batch metadata (timestamp, total, success count, failed count).

### 5.4 Reporting and Retrieval

13. The system shall expose API endpoints to retrieve converted incidents.
14. The system shall expose API endpoints to retrieve conversion errors.
15. The system shall expose API endpoints to retrieve conversion batch summaries.
16. The system shall return summary results immediately after each import.

---

## 6. Non-Functional Requirements

1. **Reliability:** Record-level failures shall not terminate the entire batch.
2. **Traceability:** Every conversion error shall include batch identifier and row context.
3. **Maintainability:** Solution shall follow layered architecture (API, Core, Infrastructure, Tests).
4. **Testability:** Validation and conversion behavior shall be covered by unit tests.
5. **Usability (Developer):** API shall be discoverable and testable via Swagger/OpenAPI.
6. **Security (v1 baseline):** No real public safety data shall be used.

---

## 7. Data Requirements

Incident source fields include:

* IncidentNumber (required, unique)
* CallType (required)
* OccurredAt (required, valid datetime)
* Status (required, allowed values)
* Optional: Location, Priority

System output data includes:

* Converted incidents
* Conversion errors
* Conversion batches
* Responding units

---

## 8. Constraints

1. Runtime: .NET 8
2. Database: SQL Server LocalDB for v1 development
3. ORM: Entity Framework Core
4. Testing Framework: xUnit

---

## 9. Acceptance Criteria

v1 documentation and implementation baseline are acceptable when:

1. All required design artifacts exist in `docs/`.
2. Import requirements and validation rules are unambiguous.
3. API contract expectations are documented.
4. Test plan defines core positive and negative coverage for conversion workflow.
