using System.Runtime.Serialization;

namespace ApparelShoppingAppAPI.Exceptions
{
    [Serializable]
    internal class NotAbelToLoginException : Exception
    {
        public NotAbelToLoginException()
        {
        }

        public NotAbelToLoginException(string? message) : base(message)
        {
        }

        public NotAbelToLoginException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotAbelToLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}