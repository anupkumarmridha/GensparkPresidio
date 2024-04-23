using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentDALLibery
{
    public class AppointmentRepository:BaseRepository<int, Appointment>, IAppoinmentRepository
    {
        public override int GenerateId()
        {
            if (_data.Count == 0)
            {
                return 1;
            }
            else
            {
                return _data.Keys.Max() + 1;
            }
        }
        public override Appointment Add(Appointment item)
        {
            item.Id = GenerateId(); // Set the Id before adding
            return base.Add(item);
        }
        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _data.Values.Where(appointment => appointment.AppointmentDateTime.Date == date.Date).ToList();
        }

        public List<Appointment> GetAppointmentsByStatus(string status)
        {
            return _data.Values.Where(appointment => appointment.Status == status).ToList();
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            return _data.Values.Where(appointment => appointment.Doctor.Id == doctorId).ToList();
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            return _data.Values.Where(appointment => appointment.Patient.Id == patientId).ToList();
        }

        public List<Appointment> GetUpcomingAppointmentsForDoctor(int doctorId, int daysAhead)
        {
            var currentDate = DateTime.Now.Date;
            var targetDate = currentDate.AddDays(daysAhead);
            return _data.Values
                .Where(appointment => appointment.Doctor.Id == doctorId &&
                    appointment.AppointmentDateTime.Date >= currentDate &&
                    appointment.AppointmentDateTime.Date <= targetDate)
                .ToList();
        }

        public List<Appointment> GetUpcomingAppointmentsForPatient(int patientId, int daysAhead)
        {
            var currentDate = DateTime.Now.Date;
            var targetDate = currentDate.AddDays(daysAhead);
            return _data.Values
                .Where(appointment => appointment.Patient.Id == patientId &&
                    appointment.AppointmentDateTime.Date >= currentDate &&
                    appointment.AppointmentDateTime.Date <= targetDate)
                .ToList();
        }

        protected override int GetKey(Appointment item)
        {
            return item.Id;
        }
    }
}
