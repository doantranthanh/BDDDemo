using System;
using App;
using App.Client;
using App.CreditHelpers;
using App.ExtractedInterfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace CustomerServices.Tests.CustomerServices_Tests
{
    [Category("CustomerService")]
    internal class GivenACustomerForAddingToSystem
    {
        private CustomerService _mockCustomerService;
        private ICompanyRepository _companyRepository;
        private ICustomerDataAccess _customerDataAccess;
        private IClientHelpers _clientHelpers;
        private ICreditHelpers _creditHelpers;
        private DateTime _dateOfBirth;
        private DateTime _yougerDateOfBirth;

        [SetUp]
        public void Setup()
        {
            _companyRepository = MockRepository.GenerateMock<ICompanyRepository>();
            _customerDataAccess = MockRepository.GenerateMock<ICustomerDataAccess>();
            _clientHelpers = MockRepository.GenerateMock<IClientHelpers>();
            _creditHelpers = MockRepository.GenerateMock<ICreditHelpers>();
            _mockCustomerService = new CustomerService(_companyRepository, _customerDataAccess, _clientHelpers, _creditHelpers);
            _dateOfBirth = new DateTime(1984, 7, 25);
            _yougerDateOfBirth = new DateTime(1998, 7, 25);
        }

        [TearDown]
        public void TearDown()
        {
            _companyRepository.VerifyAllExpectations();
            _customerDataAccess.VerifyAllExpectations();
            _clientHelpers.VerifyAllExpectations();
            _creditHelpers.VerifyAllExpectations();

        }


        #region NORMAL FLOW
        [TestCase("")]
        [TestCase(null)]
        public void When_His_First_Name_Is_Null_Or_Empty_Then_Return_False(string firstName)
        {
            var customerInfo = new Customer()
            {
                Firstname = firstName,
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _dateOfBirth,
                CompanyId = 1
            };
            var result = _mockCustomerService.AddCustomer(customerInfo);
            Assert.AreEqual(false, result);
        }

        [TestCase("")]
        [TestCase(null)]
        public void When_His_Sure_Name_Is_Null_Or_Empty_Then_Return_False(string sureName)
        {
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = sureName,
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _dateOfBirth,
                CompanyId = 1
            };
            var result = _mockCustomerService.AddCustomer(customerInfo);
            Assert.AreEqual(false, result);
        }


        [Test]
        public void When_His_Age_Less_Than_21_Then_Return_False()
        {
            // Arrange
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _yougerDateOfBirth,
                CompanyId = 1
            };


            // Act
            var result = _mockCustomerService.AddCustomer(customerInfo);

            // Assert
            Assert.AreEqual(false, result);
        }

        #endregion


        #region INTERGRATION FLOW

        [Test]
        public void When_He_Is_A_Very_Important_Client_Then_Return_True()
        {

            // Arrange
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _dateOfBirth,
                CompanyId = 1
            };

            var mockCompany = new Company()
            {
                Id = 1,
                Classification = Classification.Gold,
                Name = "VeryImportantClient"
            };

            _companyRepository.Stub(x => x.GetById(Arg<int>.Is.Anything)).Return(mockCompany);

            _clientHelpers.Stub(x => x.IsVipClient(Arg<Company>.Is.Equal(mockCompany))).Return(true);

            _customerDataAccess.Expect(x => x.AddCustomer(Arg<Customer>.Is.Anything));

            // Act
            var result = _mockCustomerService.AddCustomer(customerInfo);

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void When_He_Is_An_Important_Client_And_Has_More_Than_500_Credit_Then_Return_True()
        {

            // Arrange
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _dateOfBirth,
                CompanyId = 1
            };

            var mockCompany = new Company()
            {
                Id = 1,
                Classification = Classification.Gold,
                Name = "ImportantClient"
            };

            _companyRepository.Stub(x => x.GetById(Arg<int>.Is.Anything)).Return(mockCompany);

            _clientHelpers.Stub(x => x.IsVipClient(Arg<Company>.Is.Equal(mockCompany))).Return(false);

            _clientHelpers.Stub(x => x.IsImportantClient(Arg<Company>.Is.Equal(mockCompany))).Return(true);

            _customerDataAccess.Expect(x => x.AddCustomer(Arg<Customer>.Is.Anything));

            _creditHelpers.Expect(x => x.GetCreditLimitWithImportantClient(Arg<Customer>.Is.Anything)).Repeat.Once().Return(500);

            // Act
            var result = _mockCustomerService.AddCustomer(customerInfo);

            // Assert
            Assert.AreEqual(true, result);

        }

        [Test]
        public void When_He_Is_An_Important_Client_And_Has_Less_Than_500_Credit_Then_Return_False()
        {

            // Arrange
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _dateOfBirth,
                CompanyId = 1
            };

            var mockCompany = new Company()
            {
                Id = 1,
                Classification = Classification.Gold,
                Name = "ImportantClient"
            };

            _companyRepository.Stub(x => x.GetById(Arg<int>.Is.Anything)).Return(mockCompany);

            _clientHelpers.Stub(x => x.IsVipClient(Arg<Company>.Is.Equal(mockCompany))).Return(false);

            _clientHelpers.Stub(x => x.IsImportantClient(Arg<Company>.Is.Equal(mockCompany))).Return(true);


            _creditHelpers.Expect(x => x.GetCreditLimitWithImportantClient(Arg<Customer>.Is.Anything)).Repeat.Once().Return(400);

            // Act
            var result = _mockCustomerService.AddCustomer(customerInfo);

            // Assert
            Assert.AreEqual(false, result);


        }

        [Test]
        public void When_He_Is_A_Normal_Client_And_Has_More_Than_500_Credit_Then_Return_True()
        {

            // Arrange
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _dateOfBirth,
                CompanyId = 1
            };

            var mockCompany = new Company()
            {
                Id = 1,
                Classification = Classification.Gold,
                Name = "NormalClient"
            };

            _companyRepository.Stub(x => x.GetById(Arg<int>.Is.Anything)).Return(mockCompany);

            _clientHelpers.Stub(x => x.IsVipClient(Arg<Company>.Is.Equal(mockCompany))).Return(false);

            _clientHelpers.Stub(x => x.IsImportantClient(Arg<Company>.Is.Equal(mockCompany))).Return(false);

            _customerDataAccess.Expect(x => x.AddCustomer(Arg<Customer>.Is.Anything)).Repeat.Once();

            _creditHelpers.Expect(x => x.GetCreditLimitWithNormalClient(Arg<Customer>.Is.Anything)).Repeat.Once().Return(500);

            // Act
            var result = _mockCustomerService.AddCustomer(customerInfo);

            // Assert
            Assert.AreEqual(true, result);

        }
    
        [Test]
        public void When_He_Is_A_Normal_Client_And_Has_Less_Than_500_Credit_Then_Return_False()
        {

            // Arrange
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = _dateOfBirth,
                CompanyId = 1
            };

            var mockCompany = new Company()
            {
                Id = 1,
                Classification = Classification.Gold,
                Name = "NormalClient"
            };

            _companyRepository.Stub(x => x.GetById(Arg<int>.Is.Anything)).Return(mockCompany);

            _clientHelpers.Stub(x => x.IsVipClient(Arg<Company>.Is.Equal(mockCompany))).Return(false);

            _clientHelpers.Stub(x => x.IsImportantClient(Arg<Company>.Is.Equal(mockCompany))).Return(false);


            _creditHelpers.Expect(x => x.GetCreditLimitWithNormalClient(Arg<Customer>.Is.Anything)).Repeat.Once().Return(400);

            // Act
            var result = _mockCustomerService.AddCustomer(customerInfo);

            // Assert
            Assert.AreEqual(false, result);

        }

        #endregion


        #region EXCEPTION FLOW
        [Test]
        public void Then_Throw_ArgumentNullException_If_CustInfo_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _mockCustomerService.AddCustomer(null));
            Assert.That(ex.Message, Does.Contain("Value cannot be null"));
            Assert.AreEqual(ex.ParamName, "customerInfo");
        }

        [Test]
        public void Then_Throw_ArgumentNullException_If_ICompanyRepository_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new CustomerService(null, _customerDataAccess, _clientHelpers, _creditHelpers));
            Assert.That(ex.Message, Does.Contain("Value cannot be null"));
            Assert.AreEqual(ex.ParamName, "companyRepository");
        }

        [Test]
        public void Then_Throw_ArgumentNullException_If_ICustomerDataAccess_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new CustomerService(_companyRepository, null, _clientHelpers, _creditHelpers));
            Assert.That(ex.Message, Does.Contain("Value cannot be null"));
            Assert.AreEqual(ex.ParamName, "customerDataAccess");
        }

        [Test]
        public void Then_Throw_ArgumentNullException_If_IClientHelpers_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new CustomerService(_companyRepository, _customerDataAccess, null, _creditHelpers));
            Assert.That(ex.Message, Does.Contain("Value cannot be null"));
            Assert.AreEqual(ex.ParamName, "clientHelpers");
        }

        [Test]
        public void Then_Throw_ArgumentNullException_If_ICreditHelpers_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new CustomerService(_companyRepository, _customerDataAccess, _clientHelpers, null));
            Assert.That(ex.Message, Does.Contain("Value cannot be null"));
            Assert.AreEqual(ex.ParamName, "creditHelpers");
        }

        #endregion
    }
}

