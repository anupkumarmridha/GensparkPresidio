
create database DBDoctorAppoinment;
use DBDoctorAppoinment;

CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(255),
    Gender VARCHAR(10),
    DateOfBirth DATE,
    Specialization VARCHAR(100)
);

CREATE TABLE Patients (
     Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(255),
    Gender VARCHAR(10),
    DateOfBirth DATE
);


CREATE TABLE Appointments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DoctorId INT,
    PatientId INT,
    Status VARCHAR(50),
    AppointmentDateTime DATETIME,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (PatientId) REFERENCES Patients(Id)
);

select * from Doctors;
select * from Patients;