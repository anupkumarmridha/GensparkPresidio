using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentBLLibery
{
    public interface IPatientService
    {
        int AddPatient(Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        bool UpdatePatient(Patient patient);
        bool DeletePatient(int id);
        List<Patient> SearchPatients(string keyword);
        List<Patient> GetPatientsByCondition(string condition);
        List<Patient> GetPatientsByAgeRange(int minAge, int maxAge);
        List<Patient> GetPatientsByGender(string gender);
    }
}
