using DoctorAppoinmentModelLibery.Model;

namespace DoctorAppoinmentDALLibery
{
    public class AppointmentRepository:BaseRepository<int, Appointment>, IAppoinmentRepository
    {
        public AppointmentRepository(DBDoctorAppoinmentContext context) : base(context)
        {
        }

        public override Appointment Add(Appointment item)
        {
            return base.Add(item);
        }
        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _context.Appointments
                .Where(appointment => appointment.AppointmentDateTime.HasValue &&
                                      appointment.AppointmentDateTime.Value.Date == date.Date)
                .ToList();
        }

        public List<Appointment> GetAppointmentsByStatus(string status)
        {
            return _context.Appointments.Where(appointment => appointment.Status == status).ToList();
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            return _context.Appointments.Where(appointment => appointment.DoctorId == doctorId).ToList();
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            return _context.Appointments.Where(appointment => appointment.PatientId == patientId).ToList();
        }

        public List<Appointment> GetUpcomingAppointmentsForDoctor(int doctorId, int daysAhead)
        {
            var currentDate = DateTime.Now.Date;
            var targetDate = currentDate.AddDays(daysAhead);
            return _context.Appointments
                           .Where(appointment => appointment.DoctorId == doctorId &&
                                                 appointment.AppointmentDateTime >= currentDate &&
                                                 appointment.AppointmentDateTime <= targetDate)
                           .ToList();
        }

        public List<Appointment> GetUpcomingAppointmentsForPatient(int patientId, int daysAhead)
        {
            var currentDate = DateTime.Now.Date;
            var targetDate = currentDate.AddDays(daysAhead);
            return _context.Appointments
                           .Where(appointment => appointment.PatientId == patientId &&
                                                 appointment.AppointmentDateTime >= currentDate &&
                                                 appointment.AppointmentDateTime <= targetDate)
                           .ToList();
        }

        protected override int GetKey(Appointment item)
        {
            return item.Id;
        }
    }
}
