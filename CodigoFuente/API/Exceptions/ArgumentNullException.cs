using System;

namespace rsFoodtrucks.Exceptions
{
    public class ArgumentNullException : Exception
    {
        public ArgumentNullException (string message) : base(message)
        { }
    }
}
