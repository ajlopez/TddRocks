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
    }
}
