using DoctorAppoinmentAPI.Models;

namespace DoctorAppoinmentAPI.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization);
        Task<Doctor> AddDoctor(int userId, string specialization);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<Doctor> DeleteDoctor(int id);
    }
}
