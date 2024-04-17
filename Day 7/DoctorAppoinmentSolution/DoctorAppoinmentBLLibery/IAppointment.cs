using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentBLLibery
{
    public interface IAppointment
    {
        int ScheduleAppointment(Appointment appointment);
        Appointment GetAppointmentById(int id);
        List<Appointment> GetAllAppointments();
        List<Appointment> GetAppointmentsForDoctor(int doctorId);
        List<Appointment> GetAppointmentsForPatient(int patientId);
        bool CancelAppointment(int id);
        bool RescheduleAppointment(int id, DateTime newDateTime);
        // Retrive a list of appointments based on date
        List<Appointment> GetAppointmentsByDate(DateTime date);
        // Retrieves a list of appointments based on their status(e.g., pending, confirmed, cancelled).
        List<Appointment> GetAppointmentsByStatus(Appointment status);
        //Retrieves a list of upcoming appointments for a specific patient within a specified number of days.
        List<Appointment> GetUpcomingAppointmentsForPatient(int patientId, int daysAhead);
        //Retrieves a list of upcoming appointments for a specific doctor within a specified number of days.
        List<Appointment> GetUpcomingAppointmentsForDoctor(int doctorId, int daysAhead);
    }
}
