using System;
using System.Runtime.Serialization;

namespace Interview
{
    [Serializable]
    internal class InvalidTriangleException : Exception
    {
        public InvalidTriangleException()
        {
            Console.WriteLine("Invalid Triangle");
        }

        public InvalidTriangleException(string message) : base(message)
        {
            Console.WriteLine("Invalid Triangle Exception - " + message);
        }

        public InvalidTriangleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTriangleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}