using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorLibrary.UnitTestProject
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValieResult() // Test Case
        {
            // do not write
            // conditional stmts
            // looping
            // try..catch

            // write simple palin statements

            // AAA
            // A - Arrange
            int a = 2;
            int b = 2;
            //Calculator target = new Calculator();
            int expected = 4;
            // A - Act
            int actual = Calculator.Sum(a, b);
            // A - Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithZeroInput_ThrowsExp()
        {
            Calculator.Sum(0, 0);
            //Assert.
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithNegativeInput_ThrowsExp()
        {
            Calculator.Sum(-2, -2);
            //Assert.
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithOddInput_ThrowsExp()
        {
            Calculator.Sum(3, 7);
            //Assert.
        }


    }
}
