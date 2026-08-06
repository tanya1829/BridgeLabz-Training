-- CREATING DATABASE --
Create Database HealthClinic;
-- USING THE DATABASE--
Use HealthClinic;
-- CREATING PATIENT TABLE --
create table Patient(
PatientId int Identity(1,1) primary key,
FirstName varchar(50) not null,
LastName varchar(50) not null,
DateOfBirth date not null,
Phone varchar(15) unique,
Address varchar(100),
Gender char(1) check(gender in ('M','F','O'))
);
-- CREATING DOCTOR TABLE --
create table Doctor(
DoctorId int Identity(1,1) primary key,
FirstName varchar(50) not null,
LastName varchar(50) not null,
Specialization varchar(100) not null,
phone varchar(15) unique
);
-- CREATING APPOINTMENT TABLE --
create table Appointment(
AppointmentId int identity(1,1) primary key,
PatientId int not null foreign key references Patient(PatientId),
DoctorId int not null foreign key references Doctor(DoctorId),
AppointmentDate date not null,
Status varchar(20) default 'Scheduled'
);
-- creating rooms table --
create table Rooms (
    RoomId int identity(1,1) primary key,
    RoomNumber varchar(10) not null unique,
    Floor int not null,
    RoomType varchar(30)
);
-- which doctor is assigned to which room, and when
create table DoctorRoom(
    DoctorRoomId int identity(1,1) primary key,
    DoctorId int not null,
    RoomId int not null,
    AssignedDate date not null,
    foreign key(DoctorId) references Doctor(DoctorId),
    foreign key(RoomId) references Rooms(RoomId)
);
-- INSERT 5 PATIENTS 
insert into Patient (FirstName, LastName, DateOfBirth, Phone, Address, Gender) values
('Simran', 'Chopra', '1996-09-18', '9812345670', 'Agra, UP', 'F'),
('Arjun', 'Bhatia', '1988-02-25', '9812345671', 'Lucknow', 'M'),
('Neha', 'Kulkarni', '1994-12-10', '9812345672', 'Pune', 'F'),
('Ishaan', 'Rathore', '1999-06-04', '9812345673', 'Indore', 'M'),
('Ananya', 'Joshi', '2001-04-17', '9812345674', 'Kanpur', 'F');
-- INSERT 5 DOCTORS --
insert into Doctor (FirstName, LastName, Specialization, Phone) values
('Rajesh', 'Khanna', 'Cardiology', '8712345600'),
('Sunita', 'Rao', 'Dermatology', '8712345601'),
('Manoj', 'Tiwari', 'Orthopedics', '8712345602'),
('Kavita', 'Desai', 'Pediatrics', '8712345603'),
('Amitabh', 'Saxena', 'Neurology', '8712345604');
-- INSERT 5 APPOINTMENTS --
insert into Appointment (PatientId, DoctorId, AppointmentDate, Status) values
(1, 1, '2026-08-05', 'Scheduled'),
(2, 3, '2026-08-06', 'Completed'),
(3, 2, '2026-08-07', 'Scheduled'),
(4, 5, '2026-08-08', 'Cancelled'),
(5, 4, '2026-08-10', 'Scheduled');
-- INSERT 5 ROOMS --
insert into Rooms (RoomNumber, Floor, RoomType) values
('103', 1, 'Consultation'),
('104', 1, 'Consultation'),
('203', 2, 'Procedure'),
('204', 2, 'Consultation'),
('302', 3, 'Procedure');
-- INSERT 5 DOCTOR_ROOM ASSIGNMENTS --
insert into DoctorRoom (DoctorId, RoomId, AssignedDate) values
(1, 1, '2026-08-01'),
(2, 2, '2026-08-01'),
(3, 3, '2026-08-01'),
(4, 4, '2026-08-01'),
(5, 5, '2026-08-01');
--Question 2
-- (a) No index 
 select * from Appointment where status = 'Scheduled';
 -- Add a single-column index
create index idx_doctor ON Appointment(DoctorId);
-- (b) Single-column index
select * from Appointment where DoctorId = 5;
-- Add a composite index
create index idx_doctor_date ON Appointment(DoctorId, AppointmentDate);
-- (c) Composite index
select * from Appointment where DoctorId = 5 and AppointmentDate = '2026-08-10';
--Question 3
create table patient_phones (
    patient_id int NOT NULL,
    phone_number varchar(15) NOT NULL,
    phone_type varchar(20), 
    primary key (patient_id, phone_number),
    foreign key (patient_id) references patient(PatientId)
);
--Question 4
-- Covering index
create index idx_covering on Appointment(DoctorId, AppointmentDate, Status);
select DoctorId, AppointmentDate, Status
from Appointment
where DoctorId = 5;

-- ============================================
-- 1. PATIENT AUDIT (INSERT ONLY)
-- ============================================
create table PatientAudit (
    AuditId int identity(1,1) primary key,
    PatientId int not null,
    FirstName varchar(50),
    LastName varchar(50),
    DateOfBirth date,
    Phone varchar(15),
    Address varchar(100),
    Gender char(1),
    OperationType varchar(10) default 'INSERT',
    ChangedBy varchar(100) default SUSER_SNAME(),
    ChangedDate datetime default GETDATE()
);
GO

create trigger trg_Patient_Insert
on Patient
after insert
as
begin
    insert into PatientAudit (PatientId, FirstName, LastName, DateOfBirth, Phone, Address, Gender)
    select PatientId, FirstName, LastName, DateOfBirth, Phone, Address, Gender
    from inserted;
end;
GO

-- ============================================
-- 2. DOCTOR AUDIT (INSERT ONLY)
-- ============================================
create table DoctorAudit (
    AuditId int identity(1,1) primary key,
    DoctorId int not null,
    FirstName varchar(50),
    LastName varchar(50),
    Specialization varchar(100),
    Phone varchar(15),
    OperationType varchar(10) default 'INSERT',
    ChangedBy varchar(100) default SUSER_SNAME(),
    ChangedDate datetime default GETDATE()
);
GO

create trigger trg_Doctor_Insert
on Doctor
after insert
as
begin
    insert into DoctorAudit (DoctorId, FirstName, LastName, Specialization, Phone)
    select DoctorId, FirstName, LastName, Specialization, Phone
    from inserted;
end;
GO

-- ============================================
-- 3. APPOINTMENT AUDIT (INSERT ONLY)
-- ============================================
create table AppointmentAudit (
    AuditId int identity(1,1) primary key,
    AppointmentId int not null,
    PatientId int,
    DoctorId int,
    AppointmentDate date,
    Status varchar(20),
    OperationType varchar(10) default 'INSERT',
    ChangedBy varchar(100) default SUSER_SNAME(),
    ChangedDate datetime default GETDATE()
);
GO

create trigger trg_Appointment_Insert
on Appointment
after insert
as
begin
    insert into AppointmentAudit (AppointmentId, PatientId, DoctorId, AppointmentDate, Status)
    select AppointmentId, PatientId, DoctorId, AppointmentDate, Status
    from inserted;
end;
GO
insert into Patient (FirstName, LastName, DateOfBirth, Phone, Address, Gender) values
('Rohan', 'Malhotra', '1992-03-14', '9812345675', 'Delhi', 'M'),
('Priya', 'Nair', '1997-07-22', '9812345676', 'Chennai', 'F'),
('Karan', 'Verma', '1985-11-30', '9812345677', 'Jaipur', 'M'),
('Divya', 'Iyer', '2000-01-09', '9812345678', 'Bangalore', 'F'),
('Aditya', 'Pillai', '1990-05-27', '9812345679', 'Hyderabad', 'M');
insert into Doctor (FirstName, LastName, Specialization, Phone) values
('Priya', 'Menon', 'ENT', '8712345605'),
('Vikram', 'Singh', 'General Medicine', '8712345606'),
('Anjali', 'Kapoor', 'Gynecology', '8712345607'),
('Rahul', 'Sharma', 'Psychiatry', '8712345608'),
('Meera', 'Pandey', 'Ophthalmology', '8712345609');

insert into Appointment (PatientId, DoctorId, AppointmentDate, Status) values
(6, 6, '2026-08-12', 'Scheduled'),
(7, 7, '2026-08-13', 'Scheduled'),
(8, 8, '2026-08-14', 'Completed'),
(9, 9, '2026-08-15', 'Cancelled'),
(10, 10, '2026-08-16', 'Scheduled'),
(1, 2, '2026-08-18', 'Scheduled'),
(2, 5, '2026-08-19', 'Scheduled');

select * from PatientAudit order by AuditId;
select * from DoctorAudit order by AuditId;
select * from AppointmentAudit order by AuditId;