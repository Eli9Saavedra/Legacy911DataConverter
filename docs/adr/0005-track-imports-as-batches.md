# ADR 0005: Track Imports as Batches

* **Status:** Accepted
* **Date:** 2026-07-15

## Context

Imports need auditability and operational visibility across multiple runs.

## Decision

Represent every import run as a `ConversionBatch` with counts and timestamp metadata.

## Consequences

* Enables summary reporting and historical analysis.
* Simplifies linking incidents and errors to a specific import execution.
