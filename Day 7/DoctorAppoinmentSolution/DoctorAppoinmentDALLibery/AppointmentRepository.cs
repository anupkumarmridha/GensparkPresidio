using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentDALLibery
{
    internal class AppointmentRepository
    {
        private readonly Repository<int, Appointment> _repository;

        public AppointmentRepository()
        {
            _repository = new Repository<int, Appointment>();
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            return _repository.Add(appointment);
        }

        public Appointment DeleteAppointment(int id)
        {
            return _repository.Delete(id);
        }

        public Appointment GetAppointment(int id)
        {
            return _repository.Get(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _repository.GetAll();
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            return _repository.Update(appointment);
        }
    }
}
