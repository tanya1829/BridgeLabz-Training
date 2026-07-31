CREATE DATABASE HealthClinic;
GO
USE HealthClinic;
GO
CREATE TABLE Doctor (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Specialization NVARCHAR(100),
    Phone NVARCHAR(15),
    Email NVARCHAR(100)
);
CREATE TABLE Patient (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    DOB DATE,
    Gender NVARCHAR(10),
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(255)
);
CREATE TABLE Appointment (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Scheduled',
    Reason NVARCHAR(255),
    FOREIGN KEY (PatientId) REFERENCES Patient(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctor(DoctorId)
);