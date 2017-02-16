using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CustomerServices.Tests
{
    internal class AbstractCustomerServiceTests
    {
        public DateTime MockDateOfBirth;

        [SetUp]
        public void Setup()
        {
            MockDateOfBirth = new DateTime(1984, 7, 25);
        }

    }
}
