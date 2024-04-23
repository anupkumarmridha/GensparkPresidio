using DoctorAppoinmentDALLibery;
using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentBLLibery
{
    public class AppointmentBL : IAppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;


        public AppointmentBL(AppointmentRepository appointmentRepository, IDoctorService doctorService, IPatientService patientService)
        {
            _appointmentRepository = appointmentRepository;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        public Appointment ScheduleAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            ValidateAppointment(appointment);

            return _appointmentRepository.Add(appointment);
        }

        public Appointment GetAppointmentById(int id)
        {
            var appointment = _appointmentRepository.Get(id);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException($"Appointment with ID {id} not found.");
            }
            return appointment;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {doctorId} not found.");
            }
            return _appointmentRepository.GetAppointmentsForDoctor(doctorId);
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            var patient = _patientService.GetPatientById(patientId);
            if (patient == null)
            {
                throw new PatientNotFoundException($"Patient with ID {patientId} not found.");
            }
            return _appointmentRepository.GetAppointmentsForPatient(patientId);
        }

        public bool CancelAppointment(int id)
        {
            var appointment = _appointmentRepository.Get(id);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException($"Appointment with ID {id} not found.");
            }
            return _appointmentRepository.Delete(id) != null;
        }

        public bool RescheduleAppointment(int id, DateTime newDateTime)
        {
            var appointment = _appointmentRepository.Get(id);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException($"Appointment with ID {id} not found.");
            }

            ValidateDoctorAndPatient(appointment.Doctor.Id, appointment.Patient.Id);

            appointment.AppointmentDateTime = newDateTime;
            return _appointmentRepository.Update(appointment) != null;
        }
        private void ValidateDoctorAndPatient(int doctorId, int patientId)
        {
            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {doctorId} not found.");
            }

            var patient = _patientService.GetPatientById(patientId);
            if (patient == null)
            {
                throw new PatientNotFoundException($"Patient with ID {patientId} not found.");
            }
        }
        

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _appointmentRepository.GetAppointmentsByDate(date);
        }

        public List<Appointment> GetUpcomingAppointmentsForPatient(int patientId, int daysAhead)
        {
            var patient = _patientService.GetPatientById(patientId);
            if (patient == null)
            {
                throw new PatientNotFoundException($"Patient with ID {patientId} not found.");
            }
            return _appointmentRepository.GetUpcomingAppointmentsForPatient(patientId, daysAhead);

        }

        public List<Appointment> GetUpcomingAppointmentsForDoctor(int doctorId, int daysAhead)
        {
            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {doctorId} not found.");
            }
            return _appointmentRepository.GetUpcomingAppointmentsForDoctor(doctorId, daysAhead);
        }

        private void ValidateAppointment(Appointment appointment)
        {
            if (appointment.Doctor == null)
            {
                throw new ArgumentNullException(nameof(appointment.Doctor));
            }

            if (appointment.Patient == null)
            {
                throw new ArgumentNullException(nameof(appointment.Patient));
            }

            if (_doctorService.GetDoctorById(appointment.Doctor.Id) == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {appointment.Doctor.Id} not found.");
            }

            if (_patientService.GetPatientById(appointment.Patient.Id) == null)
            {
                throw new PatientNotFoundException($"Patient with ID {appointment.Patient.Id} not found.");
            }
        }

        public List<Appointment> GetAppointmentsByStatus(string status)
        {
            return _appointmentRepository.GetAppointmentsByStatus(status);
        }
    }
}
