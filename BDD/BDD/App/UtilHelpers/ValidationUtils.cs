using System;
using System.Globalization;

namespace App.UtilHelpers
{
    public static class ValidationUtils
    {
        public static void ArgumentNotNull(object value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }

        public static void ArgumentNotNullOrEmpty(string value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
            if (value.Length == 0)
                throw new ArgumentException(StringUtils.FormatWith("'{0}' cannot be empty.", CultureInfo.InvariantCulture, (object)parameterName), parameterName);
        }

        public static bool ValidateCustName(Customer customerInfo)
        {
            var isValid = !(string.IsNullOrEmpty(customerInfo.Firstname) || string.IsNullOrEmpty(customerInfo.Surname));
            return isValid;
        }

        public static bool ValidateCustAge(Customer customerInfo)
        {
            var age = customerInfo.DateOfBirth.GetAge();
            if (age < 21)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateEmailAddress(Customer customerInfo)
        {
            var isValid = !(!customerInfo.EmailAddress.Contains("@") && !customerInfo.EmailAddress.Contains("."));
            return isValid;
        }

    }
}
