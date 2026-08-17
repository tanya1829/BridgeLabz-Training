# Refresher Training

 Building up a `HealthCare` database schema and exploring core RDBMS concepts.

## Day 1 — Core Schema Design

Designed the foundational `HealthCare` database with three related tables:

- **Patient** — stores patient details (name, date of birth, contact info, gender)
- **Doctor** — stores doctor details (name, specialization, contact info)
- **Appointment** — links a patient to a doctor for a scheduled visit, with a status field (`Scheduled`, `Completed`, `Cancelled`)

**Key concepts covered:**
- Primary keys and auto-incrementing IDs (`IDENTITY`)
- Foreign key relationships between tables
- Basic constraints (`NOT NULL`, `UNIQUE`, `CHECK`)
- Entity-Relationship (ER) diagram of the schema 



## Day 2 — Extending the Schema & Query Optimization

Built on the Day 1 schema with additional tables and deeper database concepts:

- **Rooms** — consultation/procedure rooms in the clinic
- **DoctorRoom** —  linking doctors to rooms with assignment dates
- **PatientPhones** — normalized table supporting multiple phone numbers per patient

**Key concepts covered:**

- Er diagram
- Attributes and its types
- Many-to-many relationships 
- Single-column vs. composite indexes
- Covering indexes 
- Normalization — verifying 1NF, 2NF, and 3NF compliance


# Day 3 – Stored Procedures & Triggers

## Topics Covered
- SQL Joins: `INNER`, `LEFT`, `RIGHT`, `FULL OUTER`
- Stored Procedures
- SQL Triggers
- INSERT Trigger
- UPDATE Trigger
- DELETE Trigger
- Audit Tables


## 🛠️ Practical Implementation
Enhanced the Health Clinic Database by implementing stored procedures and trigger-based automation for querying,  and auditing.

### Tasks Completed
-  Created `DoctorAudit`, `PatientAudit`, `AppointmentAudit` tables
-  Implemented `INSERT`, `UPDATE`, `DELETE` triggers for `Doctor`
-  Implemented `INSERT`, `UPDATE`, `DELETE` triggers for `Patient`
-  Implemented `INSERT`, `UPDATE`, `DELETE` triggers for `Appointment`
-  Created parameterized Stored Procedures for `Doctor` (Insert, Update, Delete)
-  Verified automatic audit logging through SQL Server triggers


##  Database Enhancements

### Audit Tables Created
- `DoctorAudit`
- `PatientAudit`
- `AppointmentAudit`

### Triggers Implemented

**Doctor**
- `trg_Doctor_Insert`
- `trg_Doctor_Update`
- `trg_Doctor_Delete`

**Patient**
- `trg_Patient_Insert`
- `trg_Patient_Update`
- `trg_Patient_Delete`

**Appointment**
- `trg_Appointment_Insert`
- `trg_Appointment_Update`
- `trg_Appointment_Delete`


# Day 4 – ADO.NET: Health Clinic Console App

##  Topics Covered
- ADO.NET (Microsoft.Data.SqlClient)
- Connected Architecture (SqlConnection, SqlCommand, SqlDataReader)
- Layered Console App Structure (Entity / Service / Menu / Program)
- CRUD Operations via C#
- Parameterized Queries 

##  Practical Implementation
Built a console-based Health Clinic App on top of the `HealthCare` SQL Server database, using a clean layered structure.

### Project Structure
- **Entities** – `Doctor`, `Patient`, `Appointment` 
- **Service** – `DatabaseConnection`, `DoctorService`, `PatientService`, `AppointmentService` (all database logic lives here)
- **Menu** – `HealthMenu` 
- **Program.cs** – entry point, starts the menu

### Tasks Completed
-  Installed `Microsoft.Data.SqlClient` package
-  Built `DatabaseConnection` helper holding the connection string
-  Implemented Doctor CRUD using Day 3's stored procedures (`sp_InsertDoctor`, `sp_UpdateDoctor`, `sp_DeleteDoctor`)
-  Implemented Patient CRUD using parameterized SQL
-  Implemented Appointment CRUD (book, view, update status, delete)
-  Added existence checks before Update/Delete, so operations fail gracefully instead of silently doing nothing
-  Update operations only change the specific field selected — not the entire record



# Day 5 – ASP.NET Core Web API with Layered Architecture

##  Topics Covered
- ASP.NET Core Web API (Controllers)
- Layered Architecture (Entity / Repository / Service / API)
- Project References between .NET Class Libraries
- Solution (.sln) structure for multi-project apps
- ADO.NET inside a Web API (Microsoft.Data.SqlClient)

##  Practical Implementation
Scaffolded a basic ASP.NET Core Web API project and restructured it into separate layers.


### Layer Dependency Flow

API → Service → Repository → Entities


# Day 6 – ASP.NET Core MVC: Greetings App

##  Topics Covered
- ASP.NET Core MVC (Model, View, Controller)
- Routing 
- Reading configuration values from `appsettings.json`
- Basic CSS styling (external stylesheet)
- Button click / form submission (HTTP POST)

##  Practical Implementation
Built a simple MVC web app where clicking a button displays a welcome message — with the message pulled from configuration instead of being hardcoded.

###  Project Structure
- **Models** – `GreetingModel` (holds the message text)
- **Controllers** – `GreetingsController` (handles button click, reads message from config)
- **Views** – `Greetings/Index.cshtml` (button + conditional message display)
- **wwwroot/css/site.css** – page styling

# Day 7 – Contacts App Backend (Minimal APIs)

##  Topics Covered
- ASP.NET Core Minimal APIs
- Layered structure without Controllers (Model / Repository / Program)
- CRUD operations via HTTP endpoints (GET, POST, PUT, DELETE)
- ADO.NET (Microsoft.Data.SqlClient) with SQL Server
- Testing APIs using Thunder Client / Postman

##  Practical Implementation
Built a Contacts App backend using ASP.NET Core Minimal APIs — no Controllers, endpoints defined directly in `Program.cs`, backed by a real SQL Server database (no in-memory storage).

### Project Structure
- **Models** – `Contact.cs` (plain data class)
- **Repository** – `ContactRepository.cs` (all database access via ADO.NET)
- **Program.cs** – Minimal API endpoints, calling the repository directly

### Database
Created a  `ContactsDB` database  with a single `Contact` table (`ContactId`, `Name`, `Phone`, `Email`).

### Tasks Completed
-  Scaffolded a Minimal API project (`dotnet new web`)
-  Created `ContactsDB` database and `Contact` table in SSMS
-  Built `ContactRepository` with `GetAll`, `Add`, `Update`, `Delete` methods
-  Implemented Minimal API endpoints:
  - `GET /contacts` – view all contacts
  - `POST /contacts` – add a new contact
  - `PUT /contacts/{id}` – update an existing contact
  - `DELETE /contacts/{id}` – delete a contact
-  Organized code into `Models` and `Repository` folders with matching namespaces


# Day 8 – H2Sharp Investigation & Contacts App CRUD

## Topics Covered
- H2 Database and the H2Sharp ADO.NET wrapper
- Distributed Architectures — overview and motivation
- Minimal APIs (continued from Day 7)
- ADO.NET with SQL Server 
- API testing with Postman

##  Practical Implementation

### Contacts App CRUD (Minimal API + SQL Server)
- **Models** – `Contact.cs`
- **Repository** – `DatabaseConnection.cs`, `ContactRepository.cs`
- **Program.cs** – Minimal API endpoints

### Tasks Completed
-  Created `ContactsDB` database and `Contact` table
-  Implemented full CRUD via Minimal API endpoints:
  - `GET /contacts` – view all contacts
  - `POST /contacts` – add a new contact
  - `PUT /contacts/{id}` – update a contact
  - `DELETE /contacts/{id}` – delete a contact
-  Verified all 4 endpoints using Postman
-  Saved requests into a reusable "ContactsApp" Postman collection


##  Distributed Architectures — Overview
A distributed architecture splits an application across multiple independent services (potentially on different machines), instead of one single app handling everything (a monolith).


# Day 9 – Bootstrapping Entity Framework Core

##  Topics Covered
- Entity Framework Core (EF Core)
- DbContext and DbSet
- Code-First approach (C# classes → database table)
- EF Migrations
- Connection strings via `appsettings.json`

##  Practical Implementation
Set up a new ASP.NET Core Web API project and bootstrapped Entity Framework Core to manage the database .

### Project Structure
- **Models** – `Contact.cs` (plain data class, becomes the `Contact` table)
- **Data** – `AppDbContext.cs` (EF's bridge to the database)
- **Migrations** – auto-generated by EF, tracks database schema changes

### Tasks Completed
-  Installed EF Core packages: `Microsoft.EntityFrameworkCore.SqlServer`, `.Design`, `.Tools`
-  Created `Contact` model and `AppDbContext`
-  Registered `AppDbContext` in `Program.cs` using `AddDbContext`
-  Added connection string in `appsettings.json`
-  Generated first migration (`dotnet ef migrations add InitialCreate`)
-  Applied migration to create `ContactsEFDB` database and `Contact` table (`dotnet ef database update`)



# Day 10 – Address Book with Layered Architecture (EF Core CRUD)

##  Topics Covered
- Layered architecture: Model, Repository, Business, API layers
- Entity Framework Core 
- DTOs vs Entities
- Dependency Injection across layers
- Full CRUD via Web API Controllers
- Swagger for API testing

##  Practical Implementation
Built an Address Book application using a proper layered structure, separating concerns across Model, Repository, and Business layers, exposed via a Web API with Controllers.

### Project Structure
- **ModelLayer** – `Entities/Contact.cs` (db entity), `Dtos/ContactDto.cs` 
- **RepositoryLayer** – `Context/AppDbContext.cs`, `Interface/IContactRepository.cs`, `Service/ContactRepository.cs` 
- **BusinessLayer** – `Interface/IContactService.cs`, `Service/ContactService.cs` (business logic, converts Dto to Entity)
- **AddressBook** – `Controllers/ContactController.cs` (API endpoints), `Program.cs` (DI setup, Swagger)

### Tasks Completed
-  Created 4-project solution: AddressBook (Web API), ModelLayer, RepositoryLayer, BusinessLayer
-  Set up project references across layers
-  Installed EF Core packages and Swashbuckle for Swagger
-  Created `Contact` entity and `ContactDto`
-  Implemented Repository layer with direct `AppDbContext` operations
-  Implemented Business layer that maps Dto → Entity and calls Repository
-  Built `ContactController` with full CRUD: Add, GetAll, GetById, Update, Delete
-  Registered DbContext, Repository, and Service in `Program.cs` using Dependency Injection
-  Generated migration and created `AddressBookDB` database with `Contacts` table
-  Tested all endpoints via Swagger UI



# Day 11 – Address Book with Layered Architecture (EF Core CRUD)

##  Topics Covered
- Layered architecture: Model, Repository, Business, API layers
- Entity Framework Core 
- DTOs vs Entities
- Dependency Injection across layers
- Full CRUD via Web API Controllers
- Swagger for API testing

##  Practical Implementation
Built an Address Book application using a proper layered structure, separating concerns across Model, Repository, and Business layers, exposed via a Web API with Controllers.

### Project Structure
- **ModelLayer** – `Entities/Contact.cs` (db entity), `Dtos/ContactDto.cs` 
- **RepositoryLayer** – `Context/AppDbContext.cs`, `Interface/IContactRepository.cs`, `Service/ContactRepository.cs` 
- **BusinessLayer** – `Interface/IContactService.cs`, `Service/ContactService.cs` (business logic, converts Dto to Entity)
- **AddressBook** – `Controllers/ContactController.cs` (API endpoints), `Program.cs` (DI setup, Swagger)

### Tasks Completed
-  Created 4-project solution: AddressBook (Web API), ModelLayer, RepositoryLayer, BusinessLayer
-  Set up project references across layers
-  Installed EF Core packages and Swashbuckle for Swagger
-  Created `Contact` entity and `ContactDto`
-  Implemented Repository layer with direct `AppDbContext` operations
-  Implemented Business layer that maps Dto → Entity and calls Repository
-  Built `ContactController` with full CRUD: Add, GetAll, GetById, Update, Delete
-  Registered DbContext, Repository, and Service in `Program.cs` using Dependency Injection
-  Generated migration and created `AddressBookDB` database with `Contacts` table
-  Tested all endpoints via Swagger UI








