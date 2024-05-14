using DoctorAppoinmentAPI.Models;

namespace DoctorAppoinmentAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<Appointment> AddAppointment(Appointment appointment);
        Task<Appointment> UpdateAppointment(Appointment appointment);
        Task<Appointment> DeleteAppointment(int id);
    }
}
