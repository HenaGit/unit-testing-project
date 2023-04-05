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
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            

            //Act
            customer.GreetAndCombineNames("Henok", "Gebrehiwot");

            //Assert
            //Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Henok Gebrehiwot"));
            Assert.AreEqual(customer.GreetMessage, "Hello, Henok Gebrehiwot");
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Henok Gebrehiwot"));
            Assert.That(customer.GreetMessage, Does.Contain("Henok Gebrehiwot").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
            Assert.That(customer.GreetMessage, Does.EndWith("Gebrehiwot"));
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //arrange
            

            //act

            //assert
            Assert.IsNull(customer.GreetMessage);
        }
        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }
    }
}
