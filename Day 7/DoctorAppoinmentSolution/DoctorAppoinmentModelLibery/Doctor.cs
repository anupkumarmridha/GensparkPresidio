namespace DoctorAppoinmentModelLibery
{
    public class Doctor :User
    {
        public string Specialization { get; set; }=string.Empty;
        public override string ToString()
        {
            return $"Doctor ID: {Id}, Name: {Name}, Email: {Email}, Gender: {Gender}, Date of Birth: {DateOfBirth}, Specialization: {Specialization}";
        }
    }
}
