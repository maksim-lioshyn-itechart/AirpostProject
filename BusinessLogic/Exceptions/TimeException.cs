using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;

namespace BusinessLogic.Exceptions
{
    public class TimeException : Exception, IExceptionService
    {
        public StatusCode Code;

        public TimeException()
        {

        }
        public TimeException(string message) : base(message)
        {
        }

        public TimeException(StatusCode code, string message) :
            base(message)
        {
            Code = code;
        }
    }
}
