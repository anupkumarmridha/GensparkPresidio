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
        Patient AddPatient(Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        bool UpdatePatient(Patient patient);
        bool DeletePatient(int id);
        List<Patient> SearchPatients(string keyword);
    }
}
