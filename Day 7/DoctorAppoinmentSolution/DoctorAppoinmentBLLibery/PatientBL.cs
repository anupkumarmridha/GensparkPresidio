using DoctorAppoinmentDALLibery;
using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentBLLibery
{
    public class PatientBL:IPatientService
    {
        private readonly PatientRepository _patientRepository;

        public PatientBL(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient AddPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            ValidatePatient(patient);

            return _patientRepository.Add(patient);
        }

        public Patient GetPatientById(int id)
        {
            var patient = _patientRepository.Get(id);
            if (patient == null)
            {
                throw new PatientNotFoundException($"Patient with ID {id} not found.");
            }
            return patient;
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public bool UpdatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            if (_patientRepository.Get(patient.Id) == null)
            {
                throw new PatientNotFoundException($"Patient with ID {patient.Id} not found.");
            }

            ValidatePatient(patient);

            return _patientRepository.Update(patient) != null;
        }

        public bool DeletePatient(int id)
        {
            var patient = _patientRepository.Get(id);
            if (patient == null)
            {
                throw new PatientNotFoundException($"Patient with ID {id} not found.");
            }
            return _patientRepository.Delete(id) != null;
        }

        public List<Patient> SearchPatients(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("Keyword cannot be null or empty.", nameof(keyword));
            }
            return _patientRepository.GetAll().Where(p => p.Name.Contains(keyword)).ToList();
        }

        private void ValidatePatient(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.Name))
            {
                throw new ArgumentException("Patient name cannot be null or empty.", nameof(patient));
            }

            if (!IsValidGender(patient.Gender))
            {
                throw new ArgumentException("Invalid gender.", nameof(patient));
            }

            if (patient.DateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Invalid date of birth (cannot be in the future).", nameof(patient));
            }
        }

        private bool IsValidGender(string gender)
        {
            return gender == "Male" || gender == "Female";
        }
    }
}
