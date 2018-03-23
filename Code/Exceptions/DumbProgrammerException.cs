using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public class DumbProgrammerException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DumbProgrammerException()
        {
        }

        public DumbProgrammerException(string message) : base(message)
        {
        }

        public DumbProgrammerException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DumbProgrammerException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}