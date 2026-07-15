# Test Plan

![Status](https://img.shields.io/badge/status-complete-brightgreen)

> Test strategy for Legacy911DataConverter v1 conversion workflow.

---

## 1. Objective

Verify that import, validation, conversion, and reporting behavior meet v1 requirements with deterministic and auditable outcomes.

---

## 2. Scope

In scope:

* Record validation behavior
* Duplicate detection
* Mapping behavior
* Batch summary correctness
* Error logging correctness

Out of scope (v1):

* Performance/load testing
* UI/end-to-end browser testing
* Security penetration testing

---

## 3. Test Levels

1. **Unit Tests:** Validation and conversion logic in Core/Infrastructure.
2. **API Tests:** Endpoint contract and status-code behavior.
3. **Integration Tests (phase 2):** DbContext persistence + API pipeline.

---

## 4. Core Test Scenarios

1. Valid record converts successfully.
2. Missing required incident number is rejected.
3. Invalid occurred date/time is rejected.
4. Invalid status value is rejected.
5. Duplicate incident number within same batch is rejected.
6. Duplicate incident number across existing persisted incidents is rejected.
7. Batch summary counts match row outcomes.
8. Error records include row number, field, and message.

---

## 5. Entry and Exit Criteria

Entry:

1. Core conversion interfaces and models are defined.
2. Test project references are configured.

Exit:

1. All critical validation scenarios have automated tests.
2. No failing tests in CI/local baseline for covered modules.
3. Documentation and API behavior are aligned.
