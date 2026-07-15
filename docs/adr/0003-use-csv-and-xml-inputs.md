# ADR 0003: Use CSV and XML Legacy Inputs

* **Status:** Accepted
* **Date:** 2026-07-15

## Context

The project simulates migration from heterogeneous legacy systems.

## Decision

Use:

* CSV for incident records
* XML for responding unit reference data

## Consequences

* Realistic mixed-format conversion practice.
* Requires separate parser strategies and validation paths.
