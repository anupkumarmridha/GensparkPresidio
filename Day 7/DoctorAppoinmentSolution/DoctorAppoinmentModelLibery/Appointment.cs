using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentModelLibery
{
    public class Appointment
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public string Status { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public override string ToString()
        {
            return $"Appointment ID: {Id}, Doctor: {Doctor}, Patient: {Patient}, Status: {Status}, Appointment Date and Time: {AppointmentDateTime}";
        }
    }

}
