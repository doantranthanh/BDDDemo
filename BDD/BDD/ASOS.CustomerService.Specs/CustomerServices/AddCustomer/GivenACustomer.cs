using System;
using App;
using App.Client;
using App.CreditHelpers;
using App.ExtractedInterfaces;
using Machine.Specifications;
using Moq;
using MoqIt = Moq.It;

namespace ASOS.CustomerService.Specs.CustomerServices.AddCustomer
{
    public class GivenACustomer 
    {
        protected static App.CustomerService _mockCustomerService;
        protected static Mock<ICompanyRepository> _companyRepository;
        protected static Mock<ICustomerDataAccess> _customerDataAccess;
        protected static Mock<IClientHelpers> _clientHelpers;
        protected static Mock<ICreditHelpers> _creditHelpers;
        protected static DateTime _dateOfBirth;
        protected static Customer _customerInfo;
        protected static Company _mockCompany;

        Establish _context = () =>
        {
            _companyRepository = new Mock<ICompanyRepository>();
            _customerDataAccess = new Mock<ICustomerDataAccess>();
            _clientHelpers = new Mock<IClientHelpers>();
            _creditHelpers = new Mock<ICreditHelpers>();
            _mockCustomerService = new App.CustomerService(_companyRepository.Object, _customerDataAccess.Object,
                _clientHelpers.Object, _creditHelpers.Object);
            _dateOfBirth = new DateTime(1984, 7, 25);

            _customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _dateOfBirth,
                CompanyId = 1
            };

            _mockCompany = new Company()
            {
                Id = 1,
                Classification = Classification.Gold,
                Name = "VeryImportantClient"
            };

            _companyRepository.Setup(x => x.GetById(MoqIt.IsAny<int>())).Returns(_mockCompany);

            _clientHelpers.Setup(x => x.IsVipClient(MoqIt.IsAny<Company>())).Returns(true);

            _customerDataAccess.Setup(x => x.AddCustomer(MoqIt.IsAny<Customer>()));
        };

    }
}
