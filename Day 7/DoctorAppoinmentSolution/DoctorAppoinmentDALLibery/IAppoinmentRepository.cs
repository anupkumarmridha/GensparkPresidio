using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentDALLibery
{
    public interface IAppoinmentRepository:IRepository<int, Appointment>
    {
        List<Appointment> GetAppointmentsByStatus(string status);
        List<Appointment> GetAppointmentsByDate(DateTime date);
        List<Appointment> GetAppointmentsForDoctor(int doctorId);
        List<Appointment> GetAppointmentsForPatient(int patientId);
        List<Appointment> GetUpcomingAppointmentsForPatient(int patientId, int daysAhead);
        List<Appointment> GetUpcomingAppointmentsForDoctor(int doctorId, int daysAhead);

    }
}
