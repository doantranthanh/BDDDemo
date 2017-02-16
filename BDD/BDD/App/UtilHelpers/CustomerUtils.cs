using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.UtilHelpers
{
    public static class CustomerUtils
    {
        public static bool IsLimtedCredit(Customer customer)
        {
            var isLimted = (customer.HasCreditLimit && customer.CreditLimit < 500);
            return isLimted;
        }
    }
}
