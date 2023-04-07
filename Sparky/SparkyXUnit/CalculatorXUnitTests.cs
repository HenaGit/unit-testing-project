using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnit
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();

            //Act
            int result = calc.AddNumbers(10, 20);


            //Assert
            Assert.Equal(30, result);
        }
        [Fact]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(10);
            Assert.False(isOdd);
        }
        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(a);
            Assert.True(isOdd);
        }
        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            Calculator calc = new();
            var result = calc.IsOddNumber(a);
            Assert.Equal(expectedResult, result);
        }
    }
}
