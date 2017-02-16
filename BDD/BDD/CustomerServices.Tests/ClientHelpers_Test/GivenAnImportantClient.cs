using App;
using NUnit.Framework;
using Rhino.Mocks;

namespace CustomerServices.Tests.ClientHelpers_Test
{
    [Category("ClientHelpersTests")]
    internal class GivenAnImportantClient : AbstractClientHelpersTests
    {
        [Test]
        public void Then_Return_True_If_Customer_Is_ImportantClient()
        {
            var mockCompany = new Company()
            {
                Name = "ImportantClient"
            };

            GetMockConfigurationHelpers().Stub(x => x.GetValue(Arg<string>.Is.Anything)).Return("ImportantClient");
            var result = GetMockClientHelpers().IsImportantClient(mockCompany);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Then_Return_False_If_Customer_Is_Not_ImportantClient()
        {
            var mockCompany = new Company()
            {
                Name = "NormalClient"
            };

            GetMockConfigurationHelpers().Stub(x => x.GetValue(Arg<string>.Is.Anything)).Return("ImportantClient");
            var result = GetMockClientHelpers().IsImportantClient(mockCompany);
            Assert.AreEqual(false, result);
        }
    }
}
