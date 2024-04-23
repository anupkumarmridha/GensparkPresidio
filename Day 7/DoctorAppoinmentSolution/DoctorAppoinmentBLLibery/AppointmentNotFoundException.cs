using System.Runtime.Serialization;

namespace DoctorAppoinmentBLLibery
{
    public class AppointmentNotFoundException : Exception
    {
        public AppointmentNotFoundException(string message) : base(message)
        {
        }
    }
}