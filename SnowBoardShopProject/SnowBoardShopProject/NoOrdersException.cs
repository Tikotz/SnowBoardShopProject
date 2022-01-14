using System;
using System.Runtime.Serialization;

namespace SnowBoardShopProject
{
    [Serializable]
    internal class NoOrdersException : Exception
    {
        public NoOrdersException()
        {
            
        }

        public NoOrdersException(string? message) : base(message)
        {
            
        }

        public NoOrdersException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoOrdersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}