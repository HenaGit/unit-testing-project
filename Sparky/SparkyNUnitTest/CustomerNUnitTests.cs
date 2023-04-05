using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    internal class CustomerNUnitTests
    {
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            var customer = new Customer();

            //Act
            string fullName = customer.GreetAndCombineNames("Henok", "Gebrehiwot");

            //Assert
            Assert.That(fullName, Is.EqualTo("Hello, Henok Gebrehiwot"));
        }
    }
}
