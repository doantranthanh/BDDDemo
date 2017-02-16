using System;
using App;
using App.Client;
using App.ConfigHelpers;
using App.CreditHelpers;
using entityCustomer = App.Customer;

namespace Harness
{
    public class Customer
    {
        public static void ProveAddCustomer(string[] args)
        {
            var companyRepository = new CompanyRepository();
            var customerDataAccess = new CustomerDataAccess();
            var configurationHelper = new ConfigurationHelpers();
            var creditHelper = new CreditHelpers();
            var clientHelper = new ClientHelpers(configurationHelper);
            var customerService = new CustomerService(companyRepository, customerDataAccess, clientHelper, creditHelper);

            var custInfo = new entityCustomer
            {
                Firstname = "Joe",
                Surname = "Bloggs",
                EmailAddress = "joe.bloogs@adomain.com",
                DateOfBirth = new DateTime(1980, 3, 27),
                CompanyId = 4
            };
            var addResult = customerService.AddCustomer(custInfo);
            Console.WriteLine("Adding Joe Bloggs was " + (addResult ? "successful" : "unsuccessful"));
        }
    }
}
