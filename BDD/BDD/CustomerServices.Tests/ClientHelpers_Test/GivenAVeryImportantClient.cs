using App;
using NUnit.Framework;
using Rhino.Mocks;

namespace CustomerServices.Tests.ClientHelpers_Test
{
    [Category("ClientHelpersTests")]
    internal class GivenAVeryImportantClient : AbstractClientHelpersTests
    {       
        [Test]
        public void When_He_Is_Very_Important_Client_Then_Return_True()
        {
            var mockCompany = new Company()
            {
                Name = "VeryImportantClient"
            };

            GetMockConfigurationHelpers().Stub(x => x.GetValue(Arg<string>.Is.Anything)).Return("VeryImportantClient");
            var result = GetMockClientHelpers().IsVipClient(mockCompany);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void When_He_Is_Not_A_Very_Important_Client_Thenn_Return_False()
        {
            var mockCompany = new Company()
            {
                Name = "ImportantClient"
            };

            GetMockConfigurationHelpers().Stub(x => x.GetValue(Arg<string>.Is.Anything)).Return("VeryImportantClient");
            var result = GetMockClientHelpers().IsVipClient(mockCompany);
            Assert.AreEqual(false, result);
        }
    }
}
