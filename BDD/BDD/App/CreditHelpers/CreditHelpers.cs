namespace App.CreditHelpers
{
    public sealed class CreditHelpers : ICreditHelpers
    {
        public int GetCreditLimitWithImportantClient(Customer customer)
        {
            int creditLimit;
            using (var customerCreditService = new CustomerCreditServiceClient())
            {
                creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname,
                    customer.DateOfBirth);
                creditLimit = creditLimit * 2;
                customer.CreditLimit = creditLimit;
            }

            return creditLimit;
        }

        public int GetCreditLimitWithNormalClient(Customer customer)
        {
            int creditLimit;
            using (var customerCreditService = new CustomerCreditServiceClient())
            {
                creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname,
                    customer.DateOfBirth);
                customer.CreditLimit = creditLimit;
            }
            return creditLimit;

        }
    }
}
