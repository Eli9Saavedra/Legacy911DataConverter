# ADR 0004: Persist Conversion Errors

* **Status:** Accepted
* **Date:** 2026-07-15

## Context

Batch imports must remain resilient and auditable when individual rows fail validation.

## Decision

Store conversion errors in a dedicated table with:

* BatchId
* RowNumber
* IncidentNumber (if available)
* Field
* Message

## Consequences

* Better traceability and troubleshooting.
* Enables reporting of failure reasons without halting the entire batch.
