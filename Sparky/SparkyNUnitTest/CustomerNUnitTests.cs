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
            //Assert.That(fullName, Is.EqualTo("Hello, Henok Gebrehiwot"));
            Assert.AreEqual(fullName, "Hello, Henok Gebrehiwot");
            Assert.That(fullName, Is.EqualTo("Hello, Henok Gebrehiwot"));
            Assert.That(fullName, Does.Contain("Henok Gebrehiwot").IgnoreCase);
            Assert.That(fullName, Does.StartWith("Hello,"));
            Assert.That(fullName, Does.EndWith("Gebrehiwot"));
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //arrange
            var customer = new Customer();

            //act

            //assert
            Assert.IsNull(customer.GreetMessage);
        }
    }
}
