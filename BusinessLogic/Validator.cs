using System;
using BusinessLogic.Enums;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Validator<T>
    {
        public void IsValidName(string name)
        {
            if (CorrectString(name))
            {
                throw new NameException(
                    StatusCode.IncorrectData,
                    $"The {typeof(T).Name} have not empty or null name."
                    );
            }
        }

        public void IsValidEmail(string email)
        {
            if (CorrectString(email))
            {
                throw new IdentityException(
                    StatusCode.IncorrectData,
                    "Check the correctness of what you entered email."
                );
            }
        }

        public void IsValidPhone(string phone)
        {
            if (CorrectString(phone))
            {
                throw new IdentityException(
                    StatusCode.IncorrectData,
                    "Check the correctness of what you entered phone."
                );
            }
        }

        private bool CorrectString(string value) =>
            string.IsNullOrWhiteSpace(value) && string.IsNullOrEmpty(value);
    }
}
