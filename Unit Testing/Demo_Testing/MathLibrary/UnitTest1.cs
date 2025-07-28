// Ensure that the Calculator class is defined and accessible to this test file.
// If Calculator is in another file or project, make sure to add a reference to that project
// and use the correct namespace. If Calculator is missing, define a minimal version here for the tests to compile.

using NUnit.Framework;
using Demo_Test;

namespace MathLibrary.Tests
{
    // If Calculator is not defined elsewhere, define it here for the test to compile.
    // Remove this definition if Calculator is already defined in your main project.
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int sub(int a, int b) => a - b;
    }

    public class claculatorTests
    {
        private Calculator calcualtor;
        [SetUp]
        public void Setup()
        {
            calcualtor = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = calcualtor.Add(2, 3);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Subtract_ShouldReturnCorrectDiffernce()
        {
            int result = calcualtor.sub(5, 3);
            Assert.That(result, Is.EqualTo(2));
        }
    }
}