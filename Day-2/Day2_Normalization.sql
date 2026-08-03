-- CREATING DATABASE --

Create Database HealthClinic;

-- USING THE DATABASE--
Use HealthClinic;

-- CREATING PATIENT TABLE --
create table Patient(
PatientId int Identity(1,1) primary key,
FirstName varchar(50) not null,
LastName varchar(50),
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
-- Rooms table
create table rooms (
    room_id int identity(1,1) primary key,
    room_number varchar(10) not null unique,
    floor int not null,
    room_type varchar(30)
);
-- which doctor is assigned to which room, and when
create table doctor_room(
    doctor_room_id int identity(1,1) primary key,
    doctor_id int not null,
    room_id int not null,
    assigned_date date not null,
    foreign key(doctor_id) references Doctor(DoctorId),
    foreign key(room_id) references rooms(room_id)
);

--Question 2
-- (a) No index - full table scan
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