using System;
using App;
using App.UtilHelpers;
using NUnit.Framework;

namespace CustomerServices.Tests.ValidationUtils_Tests
{
    [Category("ValidationTest")]
    internal class GivenACustomerInfoWithAge : AbstractCustomerServiceTests
    {
        [Test]
        public void When_Customer_Age_Older_Than_21_Then_Return_True()
        {
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = MockDateOfBirth
            };
            var result = ValidationUtils.ValidateCustAge(customerInfo);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void When_Customer_Age_Under_Than_21_Then_Return_False()
        {
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = new DateTime(1999, 7, 25),
            };
            var result = ValidationUtils.ValidateCustAge(customerInfo);
            Assert.AreEqual(false, result);
        }
    }
}
