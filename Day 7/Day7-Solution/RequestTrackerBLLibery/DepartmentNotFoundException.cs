using System.Runtime.Serialization;

namespace RequestTrackerBLLibery
{
    public class DepartmentNotFoundException : Exception
    {
        string message;
        public DepartmentNotFoundException()
        {
            message = "No Department with such name";
        }
        public DepartmentNotFoundException(string name)
        {
            message = "No Department with name {name}";
        }
        public override string Message => message;
    }
}