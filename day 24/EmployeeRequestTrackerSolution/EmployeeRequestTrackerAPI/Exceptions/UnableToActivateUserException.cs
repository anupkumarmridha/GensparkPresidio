using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class UnableToActivateUserException : Exception
    {
        private string v;
        private string message;

        public UnableToActivateUserException()
        {
        }

        public UnableToActivateUserException(string? message) : base(message)
        {
        }

        public UnableToActivateUserException(string v, string message)
        {
            this.v = v;
            this.message = message;
        }

        public UnableToActivateUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToActivateUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}