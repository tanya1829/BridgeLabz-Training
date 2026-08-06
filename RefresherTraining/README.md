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










