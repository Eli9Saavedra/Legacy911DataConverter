# 🚓 Legacy911DataConverter

![Status](https://img.shields.io/badge/status-planning%20started-blue)
![Version](https://img.shields.io/badge/version-0.1-blue)
![Release](https://img.shields.io/badge/release-v1%20MVP-purple)
![Stack](https://img.shields.io/badge/stack-ASP.NET%20Core%20%2B%20SQL%20Server%20%2B%20EF%20Core-green)

> Legacy911DataConverter is a .NET data conversion tool that simulates migrating legacy public safety incident records into a normalized SQL Server database.

---

## 📌 Project Overview

Legacy911DataConverter is being developed as a backend-focused data conversion application.

The v1 MVP focuses on importing messy legacy public safety records, validating required fields, mapping legacy data into clean application models, saving valid records into SQL Server, and logging invalid records with clear conversion errors.

The project is designed to practice real-world software engineering skills used in data conversion, systems integration, SQL database design, API development, testing, reporting, and technical documentation.

---

## 🎯 v1 MVP Scope

The first version of Legacy911DataConverter focuses on backend data conversion and reporting.

### In Scope

* Import legacy incident records from CSV files
* Import responding unit data from XML files
* Validate required fields and data formats
* Detect duplicate incident numbers
* Map legacy fields into clean application entities
* Store valid records in SQL Server
* Log invalid records in a conversion error table
* Track each import as a conversion batch
* Generate conversion summary results
* Expose API endpoints for conversion results and converted records
* Use ASP.NET Core Web API as the backend
* Use Entity Framework Core for database access
* Use xUnit for validation and conversion tests

### Out of Scope for v1

* Real public safety data
* Authentication and user accounts
* Frontend dashboard
* Cloud deployment
* CJIS compliance implementation
* Real-time dispatch features
* Live 911 system integration
* Production customer data migration
* Payment or monetization features

---

## 🧱 Technology Stack

| Layer               | Technology            |
| ------------------- | --------------------- |
| **Backend**         | ASP.NET Core Web API  |
| **Language**        | C#                    |
| **Database**        | SQL Server LocalDB    |
| **ORM**             | Entity Framework Core |
| **Testing**         | xUnit                 |
| **API Testing**     | Swagger / OpenAPI     |
| **Version Control** | Git / GitHub          |

---

## 🛠️ Local Development Setup

This section explains how to run Legacy911DataConverter locally during development.

### Prerequisites

Before running the project, make sure these are installed:

| Tool                         | Purpose                           |
| ---------------------------- | --------------------------------- |
| **.NET SDK**                 | Runs the ASP.NET Core backend API |
| **SQL Server LocalDB**       | Local development database        |
| **Visual Studio or VS Code** | Development environment           |
| **Git**                      | Version control                   |

---

### Project Structure

```text
Legacy911DataConverter
├── docs
├── sample-data
├── Legacy911DataConverter.Api
├── Legacy911DataConverter.Core
├── Legacy911DataConverter.Infrastructure
├── Legacy911DataConverter.Tests
├── Legacy911DataConverter.sln
└── README.md
```

---

### Run the Backend API

From the repository root, run:

```powershell
dotnet run --project Legacy911DataConverter.Api
```

The API should start on a local port such as:

```text
https://localhost:7069
```

To confirm the backend is running, open Swagger:

```text
https://localhost:7069/swagger
```

---

### Stopping the Application

To stop the backend while it is running in the terminal, press:

```powershell
Ctrl + C
```

---

### Current Local URLs

| Application | Local URL                        |
| ----------- | -------------------------------- |
| Backend API | `https://localhost:7069`         |
| Swagger UI  | `https://localhost:7069/swagger` |

---

## 🏗️ Architecture Summary

Legacy911DataConverter v1 uses a layered architecture.

```text
ASP.NET Core Web API
     ↓
Conversion Services
     ↓
Validation and Mapping Logic
     ↓
Entity Framework Core
     ↓
SQL Server LocalDB
```

The API layer handles HTTP requests, file import endpoints, and conversion result responses.

The core layer contains domain models, validation rules, interfaces, and conversion-related business logic.

The infrastructure layer handles database access, Entity Framework Core configuration, file parsing, and persistence.

SQL Server LocalDB stores converted incidents, responding units, conversion batches, and conversion errors.

---

## 📂 Project Structure

```text
Legacy911DataConverter
├── docs
│   ├── adr
│   ├── design
│   │   ├── domain-model.md
│   │   ├── database-design.md
│   │   ├── api-design.md
│   │   └── architecture.md
│   │
│   ├── requirements
│   │   └── srs.md
│   │
│   ├── testing
│   │   └── test-plan.md
│   │
│   └── vision-and-scope.md
│
├── sample-data
│   ├── legacy-incidents.csv
│   └── legacy-units.xml
│
├── Legacy911DataConverter.Api
├── Legacy911DataConverter.Core
├── Legacy911DataConverter.Infrastructure
├── Legacy911DataConverter.Tests
├── Legacy911DataConverter.sln
└── README.md
```

---

## 📚 Documentation

Project documentation is stored in the `docs/` folder.

| Document                            | Status      | Link                                            |
| ----------------------------------- | ----------- | ----------------------------------------------- |
| Vision and Scope                    | Complete | [View Document](docs/vision-and-scope.md)       |
| Software Requirements Specification | Complete | [View Document](docs/requirements/srs.md)       |
| Domain Model                        | Complete | [View Document](docs/design/domain-model.md)    |
| Database Design / ERD               | Complete | [View Document](docs/design/database-design.md) |
| API Design                          | Complete | [View Document](docs/design/api-design.md)      |
| Architecture Document               | Complete | [View Document](docs/design/architecture.md)    |
| ADRs                                | Complete | [View Folder](docs/adr)                         |
| Test Plan                           | Complete | [View Document](docs/testing/test-plan.md)      |

---

## 🧠 Architecture Decision Records

Architecture Decision Records document the major technical decisions made for Legacy911DataConverter v1.

| ADR                                        | Status   | Link                                                  |
| ------------------------------------------ | -------- | ----------------------------------------------------- |
| ADR 0001: Use Layered Architecture         | Accepted | [View ADR](docs/adr/0001-use-layered-architecture.md) |
| ADR 0002: Use SQL Server LocalDB for v1    | Accepted | [View ADR](docs/adr/0002-use-sql-server-localdb.md)   |
| ADR 0003: Use CSV and XML for Legacy Input | Accepted | [View ADR](docs/adr/0003-use-csv-and-xml-inputs.md)   |
| ADR 0004: Store Conversion Errors          | Accepted | [View ADR](docs/adr/0004-store-conversion-errors.md)  |
| ADR 0005: Track Imports as Batches         | Accepted | [View ADR](docs/adr/0005-track-imports-as-batches.md) |

---

## ✅ Current Project Status

The project documentation phase is complete.

Completed setup tasks:

* GitHub repository created
* Blank solution created
* ASP.NET Core Web API project created
* Core class library created
* Infrastructure class library created
* xUnit test project created
* Project references configured
* Backend API confirmed running locally with Swagger

Current phase:

```text
Documentation complete; ready for implementation phase
```

---

## 🚀 Next Steps

Planned implementation order:

1. Create sample legacy CSV and XML files
2. Add Entity Framework Core models and DbContext
3. Create initial database migration
4. Build CSV incident parser
5. Build XML responding unit parser
6. Implement conversion validation rules
7. Implement conversion batch persistence
8. Add conversion summary and retrieval endpoints
9. Add unit tests for validation and conversion logic

Main v1 workflow:

```text
Import legacy file → Validate records → Convert valid records → Log failed records → Generate conversion summary
```

---

## 🔄 Data Conversion Focus

Legacy911DataConverter simulates a real-world data migration workflow.

The application will:

* Read legacy public safety records from CSV and XML files
* Validate missing, duplicate, and incorrectly formatted data
* Map legacy field names into clean application entities
* Store successful conversions in SQL Server
* Store failed records with row-level error details
* Track each import as a conversion batch
* Return clear conversion summaries through API endpoints

This project is not connected to any real 911, police, fire, EMS, or public safety system.

---

## 📝 License

License information has not been finalized yet.
