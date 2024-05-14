namespace DoctorAppoinmentAPI.Models
{
    public partial class Doctor
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Specialization { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<TimeSlot> AvailableTimeSlots { get; set; }
    }
}
