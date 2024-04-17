namespace DoctorAppoinmentModelLibery
{
    public class Doctor :User, IEntity<int>
    {
        public string Specialization { get; set; }
    }
}
