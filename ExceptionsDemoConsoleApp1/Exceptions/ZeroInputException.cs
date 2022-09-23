using System;

namespace ExceptionsDemoConsoleApp1.Exceptions
{
    internal class ZeroInputException : ApplicationException
    {
        public ZeroInputException(string message) : base(message)
        {
            //this.Message = message;
        }
    }
}
