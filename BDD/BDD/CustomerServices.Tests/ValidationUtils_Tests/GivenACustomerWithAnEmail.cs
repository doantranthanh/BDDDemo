using App;
using App.UtilHelpers;
using NUnit.Framework;

namespace CustomerServices.Tests.ValidationUtils_Tests
{
    [Category("ValidationTest")]
    internal class GivenACustomerWithAnEmail : AbstractCustomerServiceTests
    {
        [TestCase("tthanhdoan")]
        [TestCase("thanhdoan")]
        public void Then_Return_False_If_EmailAddress_Is_Not_Valid(string emailAddress)
        {
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = emailAddress,
                DateOfBirth = MockDateOfBirth
            };
            var result = ValidationUtils.ValidateEmailAddress(customerInfo);
            Assert.AreEqual(false, result);
        }

        [TestCase("tthanh.doan@gmail.com")]
        [TestCase("thanhdoan@gmail.com")]
        public void Then_Return_True_If_EmailAddress_Is_Valid(string emailAddress)
        {
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = emailAddress,
                DateOfBirth = MockDateOfBirth
            };
            var result = ValidationUtils.ValidateEmailAddress(customerInfo);
            Assert.AreEqual(true, result);
        }
    }
}
