﻿using NUnit.Framework;
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
            Assert.Multiple(() =>
            {
                Assert.AreEqual(customer.GreetMessage, "Hello, Henok Gebrehiwot");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Henok Gebrehiwot"));
                Assert.That(customer.GreetMessage, Does.Contain("Henok Gebrehiwot").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("Gebrehiwot"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
           
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
        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("Henok", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }
        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Gebrehiwot"));
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);

            Assert.That(() => customer.GreetAndCombineNames("", "Gebrehiwot"),
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Gebrehiwot"));

            Assert.That(() => customer.GreetAndCombineNames("", "Gebrehiwot"),
                Throws.ArgumentException);

        }
        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }
        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatiniumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
