using App;
using App.UtilHelpers;
using NUnit.Framework;

namespace CustomerServices.Tests.ValidationUtils_Tests
{
    [Category("ValidationTest")]
    internal class GivenACustomerWithCredit
    {
        private Customer _mockCustomer;
        private Company _mockCompany;

        [SetUp]
        public void SetUp()
        {

            _mockCompany = new Company()
            {
                Id = 1,
                Name = "ASOS",
                Classification = Classification.Gold
            };

            _mockCustomer = new Customer()
            {
                Company = _mockCompany,
                Id = 1,
            };
        }

        [Test]
        public void When_He_Has_Credit_Limit_Then_Return_True()
        {
            _mockCustomer.HasCreditLimit = true;
            var result = CustomerUtils.IsLimtedCredit(_mockCustomer);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void When_He_Has_Credit_Limit_Less_Than_500_Then_Return_True()
        {
            _mockCustomer.HasCreditLimit = true;
            _mockCustomer.CreditLimit = 499;
            var result = CustomerUtils.IsLimtedCredit(_mockCustomer);
            Assert.AreEqual(true, result);
        }
    }
}
