using System;
using System.Collections.Generic;

namespace DoctorAppoinmentModelLibery.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Specialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
