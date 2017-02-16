using NUnit.Framework;

namespace ASOS.CustomerService.Specs
{
    public class AAA
    {
        [SetUp]
        public void MainSetup()
        {
            Arrange();
            Act();
        }

        [TearDown]
        protected void MainTearDown()
        {
            CleanUp();
        }

        protected virtual void Act() { }
        protected virtual void Arrange() { }
        protected virtual void CleanUp() { }
    }
}
