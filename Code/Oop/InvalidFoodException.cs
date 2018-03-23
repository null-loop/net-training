using System;
using System.Runtime.Serialization;

namespace Oop
{
    [Serializable]
    public class InvalidFoodException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidFoodException()
        {
        }

        public InvalidFoodException(string message) : base(message)
        {
        }

        public InvalidFoodException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidFoodException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}