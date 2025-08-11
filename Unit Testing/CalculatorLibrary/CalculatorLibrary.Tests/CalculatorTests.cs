using NUnit.Framework;
using CalculatorLibrary;
using System;

namespace CalculatorLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            Assert.That(calculator.Add(5, 3), Is.EqualTo(8));
        }

        [Test]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            Assert.That(calculator.Subtract(5, 3), Is.EqualTo(2));
        }

        [Test]
        public void Multiply_ShouldReturnCorrectProduct()
        {
            Assert.That(calculator.Multiply(5, 3), Is.EqualTo(15));
        }

        [Test]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            Assert.That(calculator.Divide(6, 3), Is.EqualTo(2));
        }

        [Test]
        public void Divide_ByZero_ShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(5, 0));
        }

        [Test]
        public void Add_WithZero_ShouldReturnSameNumber()
        {
            Assert.That(calculator.Add(5, 0), Is.EqualTo(5));
        }

        [Test]
        public void Subtract_SameNumbers_ShouldReturnZero()
        {
            Assert.That(calculator.Subtract(5, 5), Is.EqualTo(0));
        }
    }
}
