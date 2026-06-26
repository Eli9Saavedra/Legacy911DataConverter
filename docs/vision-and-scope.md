# 🚓 Vision and Scope

![Status](https://img.shields.io/badge/status-in%20progress-blue)
![Version](https://img.shields.io/badge/version-0.1-blue)
![Release](https://img.shields.io/badge/release-v1%20MVP-purple)

> This document defines the vision, scope, goals, and boundaries for Legacy911DataConverter v1.

---

## 📌 Project Vision

Legacy911DataConverter is a backend-focused .NET application that simulates converting legacy public safety records into a clean, normalized SQL Server database.

The goal is to practice data conversion, SQL database design, validation, error handling, API development, testing, reporting, and technical documentation in a realistic public safety scenario.

---

## ❗ Problem Statement

Organizations often need to migrate data from older legacy systems into modern software platforms.

Legacy data may contain inconsistent field names, missing values, invalid dates, duplicate records, unsupported formats, or incomplete relationships.

This project simulates that problem by importing messy legacy incident records, validating each record, converting valid records into clean application models, and storing both successful and failed conversion results.

---

## 🎯 Project Goals

The primary goals of Legacy911DataConverter v1 are to:

* Build a .NET backend API for importing and reviewing converted data
* Read legacy incident records from CSV files
* Read responding unit data from XML files
* Validate required fields and business rules
* Detect duplicate incident numbers
* Map legacy data fields into normalized application entities
* Store valid records in SQL Server
* Store invalid records with clear error details
* Track each import as a conversion batch
* Generate conversion summaries that describe import results
* Document the system using professional software engineering artifacts

---

## ✅ In Scope

Legacy911DataConverter v1 includes:

* CSV incident record import
* XML responding unit import
* SQL Server LocalDB persistence
* Entity Framework Core data access
* Conversion batch tracking
* Conversion error logging
* Required field validation
* Date format validation
* Duplicate incident detection
* Status value validation
* Field mapping from legacy inputs to application entities
* API endpoints for conversion results
* API endpoints for converted incident records
* Unit tests for validation and conversion logic
* Markdown documentation for requirements, design, testing, and architecture decisions

---

## 🚫 Out of Scope

Legacy911DataConverter v1 does not include:

* Real public safety data
* Real 911, police, fire, or EMS system integration
* Authentication and user accounts
* Role-based authorization
* CJIS compliance implementation
* Frontend dashboard
* Cloud deployment
* Real-time dispatch workflows
* Production data migration
* Payment or monetization features
* Native mobile application

---

## 👤 Target Users

The target users for this project are:

| User Type              | Description                                                               |
| ---------------------- | ------------------------------------------------------------------------- |
| **Developer**          | Practices data conversion, SQL design, API development, and testing       |
| **Technical Reviewer** | Reviews backend architecture, documentation, and implementation decisions |
| **Hiring Team**        | Evaluates practical experience with data-driven software engineering      |

---

## 🧱 High-Level Workflow

The v1 workflow is:

```text
Import legacy file
     ↓
Parse source records
     ↓
Validate required fields and business rules
     ↓
Map legacy data to clean application entities
     ↓
Save valid records to SQL Server
     ↓
Log invalid records as conversion errors
     ↓
Return conversion summary
```

---

## 📦 Expected Inputs

Legacy911DataConverter v1 will use sample files stored in the `sample-data/` folder.

Planned sample files:

| File                   | Format | Purpose                                 |
| ---------------------- | ------ | --------------------------------------- |
| `legacy-incidents.csv` | CSV    | Contains messy legacy incident records  |
| `legacy-units.xml`     | XML    | Contains responding unit reference data |

---

## 📤 Expected Outputs

The application should produce:

* Converted incident records
* Stored responding unit records
* Conversion batch records
* Conversion error records
* Conversion summary results
* API responses for reviewing converted data and failed records

---

## ✅ Success Criteria

The project is successful when it can:

* Import a sample CSV file containing legacy incident records
* Validate each row against required business rules
* Insert valid records into SQL Server
* Reject invalid records without crashing the import process
* Store rejected records with clear error messages
* Track the import as a conversion batch
* Return a conversion summary through an API endpoint
* Import XML responding unit data
* Include unit tests for key validation rules
* Provide clear documentation explaining the system design and conversion process

---

## 🧭 v1 MVP Summary

Legacy911DataConverter v1 focuses on proving the core data conversion workflow.

```text
CSV/XML source data → validation → mapping → SQL Server storage → conversion reporting
```

The project should remain backend-focused and avoid extra features until the core conversion workflow is complete.
