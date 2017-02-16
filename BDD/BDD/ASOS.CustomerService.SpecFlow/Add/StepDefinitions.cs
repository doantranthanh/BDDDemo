using System;
using App;
using App.Client;
using App.CreditHelpers;
using App.ExtractedInterfaces;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ASOS.CustomerService.SpecFlow.Add
{
    [Binding]
    public class StepDefinitions
    {
        private App.CustomerService _mockCustomerService;
        private Mock<ICompanyRepository> _companyRepository;
        private Mock<ICustomerDataAccess> _customerDataAccess;
        private Mock<IClientHelpers> _clientHelpers;
        private Mock<ICreditHelpers> _creditHelpers;
        private DateTime _dateOfBirth;
        private Customer _customerInfo;
        private Company _mockCompany;

        [BeforeScenario()]
        public void InitScenario()
        {
            _companyRepository = new Mock<ICompanyRepository>();
            _customerDataAccess = new Mock<ICustomerDataAccess>();
            _clientHelpers = new Mock<IClientHelpers>();
            _creditHelpers = new Mock<ICreditHelpers>();
            _mockCustomerService = new App.CustomerService(_companyRepository.Object, _customerDataAccess.Object, _clientHelpers.Object, _creditHelpers.Object);
            _dateOfBirth = new DateTime(1984, 7, 25);
            _customerInfo = new Customer();
        }

        [Given(@"I received a very important client information")]
        public void GivenIReceivedAVeryImportantClientInformation()
        {
            _mockCompany = new Company()
            {
                Id = 1,
                Classification = Classification.Gold,
                Name = "VeryImportantClient"
            };
        }

        [Given(@"I have a customer's valid first name")]
        public void GivenIHaveACustomerSValidFirstName()
        {
            _customerInfo.Firstname = "Thanh";
        }

        [Given(@"I have a customer's valid sure name")]
        public void GivenIHaveACustomerSValidSureName()
        {
            _customerInfo.Surname = "Doan";
        }

        [Given(@"I have a valid customer's email address")]
        public void GivenIHaveAValidCustomerSEmailAddress()
        {
            _customerInfo.EmailAddress = "tthanh.doan@gmail.com";
        }

        [Given(@"I have a customer's age older than twenty one")]
        public void GivenIHaveACustomerSAgeOlderThanTwentyOne()
        {
            _customerInfo.DateOfBirth = _dateOfBirth;
        }

        [Given(@"I retrieve the customer's company info")]
        public void GivenIRetrieveTheCustomerSCompanyInfo()
        {
            _companyRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(_mockCompany);
        }

        [Given(@"Client is very important client")]
        public void GivenClientIsVeryImportantClient()
        {
            _clientHelpers.Setup(x => x.IsVipClient(It.IsAny<Company>())).Returns(true);
        }

        [Given(@"Client has no limited credit")]
        public void GivenClientHasNoLimitedCredit()
        {
            _customerInfo.HasCreditLimit = false;
        }

        [Then(@"I add this customer to the database")]
        public void WhenIAddThisCustomerToTheDatabase()
        {
            _customerDataAccess.Setup(x => x.AddCustomer(_customerInfo));
        }

        [Then(@"Return true value")]
        public void ThenReturnTrueValue()
        {
            var result = _mockCustomerService.AddCustomer(_customerInfo);
            Assert.AreEqual(true, result);
        }
    }
}
