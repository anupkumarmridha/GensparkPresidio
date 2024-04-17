using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentModelLibery
{
    public class Appointment:IEntity<int>
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public string Status { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
