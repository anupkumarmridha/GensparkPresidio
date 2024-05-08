namespace DoctorAppoinmentBLLibery
{
    public class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException(string message) : base(message)
        {
        }
    }
}