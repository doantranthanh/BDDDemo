using System.Configuration;
using NUnit.Framework;

namespace ASOS.CustomerService.Specs
{
    public class ContextSpecification
    {
        [SetUp]
        public void MainSetup()
        {
            SetContext();
            Because();
        }

        [TearDown]
        protected void MainTeardown()
        {
            CleanUp();
        }

        protected virtual void CleanUp() { }
        protected virtual void Because() { }
        protected virtual void SetContext() { }
    }
}
