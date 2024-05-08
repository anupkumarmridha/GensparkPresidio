using DoctorAppoinmentModelLibery.Model;

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
