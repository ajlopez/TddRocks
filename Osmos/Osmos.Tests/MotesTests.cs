namespace Osmos.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MotesTests
    {
        [TestMethod]
        public void OneSmallerMoteCanBeSolved()
        {
            Motes motes = new Motes();

            Assert.IsTrue(motes.CanBeSolved(10, new int[] { 9 }));
        }

        [TestMethod]
        public void OneEqualMoteCannotBeSolved()
        {
            Motes motes = new Motes();

            Assert.IsFalse(motes.CanBeSolved(10, new int[] { 10 }));
        }

        [TestMethod]
        public void OneEqualGreaterCannotBeSolved()
        {
            Motes motes = new Motes();

            Assert.IsFalse(motes.CanBeSolved(10, new int[] { 11 }));
        }

        [TestMethod]
        public void TwoMotesThanCanBeSolved()
        {
            Motes motes = new Motes();

            Assert.IsTrue(motes.CanBeSolved(10, new int[] { 9, 18 }));
        }

        [TestMethod]
        public void TwoMotesThanCannotBeSolved()
        {
            Motes motes = new Motes();

            Assert.IsFalse(motes.CanBeSolved(10, new int[] { 9, 19 }));
        }

        [TestMethod]
        public void ThreeMotesThanCanBeSolved()
        {
            Motes motes = new Motes();

            Assert.IsTrue(motes.CanBeSolved(10, new int[] { 9, 18, 36 }));
        }

        [TestMethod]
        public void ThreeMotesThanCannotBeSolved()
        {
            Motes motes = new Motes();

            Assert.IsFalse(motes.CanBeSolved(10, new int[] { 9, 18, 37 }));
        }

        [TestMethod]
        public void NumberToRemove()
        {
            Motes motes = new Motes();

            Assert.AreEqual(0, motes.NumbersToRemove(new int[] { -1, -2 }));
            Assert.AreEqual(1, motes.NumbersToRemove(new int[] { -1, 0 }));
            Assert.AreEqual(1, motes.NumbersToRemove(new int[] { -1, 1, -1 }));
            Assert.AreEqual(2, motes.NumbersToRemove(new int[] { 0, 1, -1 }));
        }

        [TestMethod]
        public void NumberToAdd()
        {
            Motes motes = new Motes();

            Assert.AreEqual(0, motes.NumberToAdd(10, new int[] { 9, 18 }));
            Assert.AreEqual(18, motes.NumberToAdd(10, new int[] { 9, 20 }));
            Assert.AreEqual(36, motes.NumberToAdd(10, new int[] { 9, 18, 37 }));
        }
    }
}
