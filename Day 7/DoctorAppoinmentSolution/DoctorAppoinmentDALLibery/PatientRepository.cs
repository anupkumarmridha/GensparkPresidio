using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentDALLibery
{
    internal class PatientRepository 
    {
        private readonly Repository<int, Patient> _repository;

        public PatientRepository()
        {
            _repository = new Repository<int, Patient>();
        }

        public Patient AddPatient(Patient patient)
        {
            return _repository.Add(patient);
        }

        public Patient DeletePatient(int id)
        {
            return _repository.Delete(id);
        }

        public Patient GetPatient(int id)
        {
            return _repository.Get(id);
        }

        public List<Patient> GetAllPatients()
        {
            return _repository.GetAll();
        }

        public Patient UpdatePatient(Patient patient)
        {
            return _repository.Update(patient);
        }
    }
}
