namespace DoctorAppoinmentAPI.Models
{
    public class Patient
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
