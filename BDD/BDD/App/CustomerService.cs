using App.Client;
using App.CreditHelpers;
using App.ExtractedInterfaces;
using App.UtilHelpers;

namespace App
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICustomerDataAccess _customerDataAccess;
        private readonly IClientHelpers _clientHelpers;
        private readonly ICreditHelpers _creditHelpers;


        public CustomerService(ICompanyRepository companyRepository, ICustomerDataAccess customerDataAccess, IClientHelpers clientHelpers, ICreditHelpers creditHelpers)
        {
            ValidationUtils.ArgumentNotNull(companyRepository, nameof(companyRepository));
            ValidationUtils.ArgumentNotNull(customerDataAccess, nameof(customerDataAccess));
            ValidationUtils.ArgumentNotNull(clientHelpers, nameof(clientHelpers));
            ValidationUtils.ArgumentNotNull(creditHelpers, nameof(creditHelpers));
            _companyRepository = companyRepository;
            _customerDataAccess = customerDataAccess;
            _clientHelpers = clientHelpers;
            _creditHelpers = creditHelpers;

        }

        public bool AddCustomer(Customer customerInfo)
        {

            if (!ValidateCustomInfo(customerInfo))
                return false;

            var company = _companyRepository.GetById(customerInfo.CompanyId);

            var customer = InitCustomer(customerInfo, company);

            this.GetCustomerCredit(company, customer);

            if (CustomerUtils.IsLimtedCredit(customer))
                return false;

            _customerDataAccess.AddCustomer(customer);

            return true;
        }

        public void GetCustomerCredit(Company company, Customer customer)
        {
            if (_clientHelpers.IsVipClient(company))
            {
                // Skip credit check
                customer.HasCreditLimit = !_clientHelpers.IsVipClient(company);
            }
            else if (_clientHelpers.IsImportantClient(company))
            {
                // Do credit check and double credit limit
                customer.HasCreditLimit = true;

                customer.CreditLimit = _creditHelpers.GetCreditLimitWithImportantClient(customer);
            }
            else
            {
                // Do credit check
                customer.HasCreditLimit = true;
                customer.CreditLimit = _creditHelpers.GetCreditLimitWithNormalClient(customer);
            }
        }

        private static bool ValidateCustomInfo(Customer customerInfo)
        {
            ValidationUtils.ArgumentNotNull(customerInfo, nameof(customerInfo));

            if (!ValidationUtils.ValidateCustName(customerInfo))
                return false;

            return ValidationUtils.ValidateEmailAddress(customerInfo) && ValidationUtils.ValidateCustAge(customerInfo);
        }

        private static Customer InitCustomer(Customer customerInfo, Company company)
        {
            var customer = new Customer
            {
                Company = company,
                DateOfBirth = customerInfo.DateOfBirth,
                EmailAddress = customerInfo.EmailAddress,
                Firstname = customerInfo.Firstname,
                Surname = customerInfo.Surname
            };
            return customer;
        }
    }
}
