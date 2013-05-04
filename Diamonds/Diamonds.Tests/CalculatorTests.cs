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

            Assert.AreEqual(0, calculator.Calculate(1, 1, 0));
            Assert.AreEqual(0, calculator.Calculate(1, 2, 1));
            Assert.AreEqual(0, calculator.Calculate(1, 2, 3));
        }

        [TestMethod]
        public void InsufficientDiamonds()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(0, calculator.Calculate(0, 0, 0));
            Assert.AreEqual(0, calculator.Calculate(1, -2, 0));
            Assert.AreEqual(0, calculator.Calculate(1, 0, 2));
            Assert.AreEqual(0, calculator.Calculate(1, 2, 0));
        }

        [TestMethod]
        public void EnoughDiamonds()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(1, calculator.Calculate(1, 0, 0));
            Assert.AreEqual(1, calculator.Calculate(6, -2, 0));
            Assert.AreEqual(1, calculator.Calculate(6, 0, 2));
            Assert.AreEqual(1, calculator.Calculate(6, 2, 0));
        }

        [TestMethod]
        public void NotEnoughDiamonds()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(0, calculator.Calculate(0, 0, 0));
            Assert.AreEqual(0, calculator.Calculate(5, 0, 2));
            Assert.AreEqual(0, calculator.Calculate(14, 0, 4));
        }

        [TestMethod]
        public void NeededDiamonds()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(1, calculator.NeededDiamonds(0));
            Assert.AreEqual(1 + 5, calculator.NeededDiamonds(1));
            Assert.AreEqual(1 + 5 + 9, calculator.NeededDiamonds(2));
            Assert.AreEqual(1 + 5 + 9 + 13, calculator.NeededDiamonds(3));
        }
    }
}
