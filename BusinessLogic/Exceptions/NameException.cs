using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NameException : Exception, IExceptionService
    {
        public StatusCode Code;

        public NameException()
        {

        }
        public NameException(string message) : base(message)
        {
        }

        public NameException(StatusCode code, string message) :
            base(message)
        {
            Code = code;
        }
    }
}
