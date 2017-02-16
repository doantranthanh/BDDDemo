using System;
using App;
using App.UtilHelpers;
using NUnit.Framework;

namespace CustomerServices.Tests.ValidationUtils_Tests
{
    [Category("ValidationUtils")]
    internal class GiveACustomerWithAName : AbstractCustomerServiceTests
    {
       
        [TestCase("")]
        [TestCase(null)]
        public void When_His_First_Name_Is_Null_Or_Empty_Then_Return_False(string fName)
        {
            var customerInfo = new Customer()
            {
                Firstname = fName,
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = MockDateOfBirth
            };
            var result = ValidationUtils.ValidateCustName(customerInfo);
            Assert.AreEqual(false, result);
        }

        [TestCase("")]
        [TestCase(null)]
        public void When_His_Sur_Name_Is_Null_Or_Empty_Then_Return_False(string sName)
        {
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = sName,
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = MockDateOfBirth
            };
            var result = ValidationUtils.ValidateCustName(customerInfo);
            Assert.AreEqual(false, result);
        }

        [TestCase()]
        public void When_His_Name_Is_Valid_Then_Return_True()
        {
            var customerInfo = new Customer()
            {
                Firstname = "Thanh",
                Surname = "Doan",
                EmailAddress = "tthanh.doan@gmail.com",
                DateOfBirth = MockDateOfBirth
            };
            var result = ValidationUtils.ValidateCustName(customerInfo);
            Assert.AreEqual(true, result);
        }
    }
}
