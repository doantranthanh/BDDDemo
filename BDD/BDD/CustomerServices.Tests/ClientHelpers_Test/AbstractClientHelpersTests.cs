using App.Client;
using App.ConfigHelpers;
using NUnit.Framework;
using Rhino.Mocks;

namespace CustomerServices.Tests.ClientHelpers_Test
{
    internal class AbstractClientHelpersTests
    {
        private IConfigurationHelpers _configurationManager;
        private ClientHelpers _clientHelpers;

        [SetUp]
        public void Setup()
        {
            _configurationManager = MockRepository.GenerateMock<IConfigurationHelpers>();
            _clientHelpers = new ClientHelpers(_configurationManager);
        }

        public IConfigurationHelpers GetMockConfigurationHelpers()
        {
            return _configurationManager;
        }

        public ClientHelpers GetMockClientHelpers()
        {
            return _clientHelpers;
        }
    }
}
