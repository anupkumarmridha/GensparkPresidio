using DoctorAppoinmentAPI.Models;

namespace DoctorAppoinmentAPI.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> AddPatient(int userId);
        Task<Patient> UpdatePatient(Patient patient);
        Task<Patient> DeletePatient(int id);
    }
}
