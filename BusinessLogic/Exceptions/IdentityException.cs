using BusinessLogic.Enums;
using System;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Exceptions
{
    public class IdentityException : Exception, IExceptionService
    {
        public StatusCode Code;

        public IdentityException()
        {

        }
        public IdentityException(string message) : base(message)
        {
        }

        public IdentityException(StatusCode code, string message) :
            base(message)
        {
            Code = code;
        }
    }
}
