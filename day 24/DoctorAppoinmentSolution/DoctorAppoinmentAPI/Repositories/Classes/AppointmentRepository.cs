using DoctorAppoinmentAPI.Contexts;
using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;

namespace DoctorAppoinmentAPI.Repositories.Classes
{
    public class AppointmentRepository:BaseRepository<int, Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DoctorAppoinmentDbContext context) : base(context)
        {
        }
    }
}
