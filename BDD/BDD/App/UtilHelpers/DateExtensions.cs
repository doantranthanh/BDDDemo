using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.UtilHelpers
{
    internal static class DateExtensions
    {
        public static int GetAge(this DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month ||
                (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }
    }
}
