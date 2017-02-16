using System;
using App.UtilHelpers;
using NUnit.Framework;

namespace CustomerServices.Tests.ValidationUtils_Tests
{
    [Category("ValidationTest")]
    internal class GivenACustomerInfoAndItNull
    {
        [Test]
        public void Then_Throw_ArgumentNullException_If_CustInfo_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ValidationUtils.ArgumentNotNull(null, "customerInfo"));
            Assert.That(ex.Message, Does.Contain("Value cannot be null"));
            Assert.AreEqual(ex.ParamName, "customerInfo");
        }
    }
}
