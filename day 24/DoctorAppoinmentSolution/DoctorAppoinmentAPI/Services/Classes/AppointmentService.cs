using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;
using DoctorAppoinmentAPI.Services.Interfaces;

namespace DoctorAppoinmentAPI.Services.Classes
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAll();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _appointmentRepository.GetById(id);
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            return await _appointmentRepository.Add(appointment);
        }

        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            return await _appointmentRepository.Update(appointment);
        }

        public async Task<Appointment> DeleteAppointment(int id)
        {
            return await _appointmentRepository.Delete(id);
        }
    }
}
