using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Diamonds.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void OddCoordinates()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(0, calculator.Calculate(1, 0));
            Assert.AreEqual(0, calculator.Calculate(2, 1));
            Assert.AreEqual(0, calculator.Calculate(2, 3));
        }
    }
}
