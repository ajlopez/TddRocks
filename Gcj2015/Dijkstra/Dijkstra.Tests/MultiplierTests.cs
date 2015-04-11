namespace Dijkstra.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MultiplierTests
    {
        private static Multiplier multiplier = new Multiplier();

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual((int)Quaternions.one, multiplier.Multiply(Quaternions.one, Quaternions.one));
            Assert.AreEqual((int)Quaternions.i, multiplier.Multiply(Quaternions.one, Quaternions.i));
            Assert.AreEqual((int)Quaternions.j, multiplier.Multiply(Quaternions.one, Quaternions.j));
            Assert.AreEqual((int)Quaternions.k, multiplier.Multiply(Quaternions.one, Quaternions.k));

            Assert.AreEqual((int)Quaternions.i, multiplier.Multiply(Quaternions.i, Quaternions.one));
            Assert.AreEqual(-(int)Quaternions.one, multiplier.Multiply(Quaternions.i, Quaternions.i));
            Assert.AreEqual((int)Quaternions.k, multiplier.Multiply(Quaternions.i, Quaternions.j));
            Assert.AreEqual(-(int)Quaternions.j, multiplier.Multiply(Quaternions.i, Quaternions.k));

            Assert.AreEqual((int)Quaternions.j, multiplier.Multiply(Quaternions.j, Quaternions.one));
            Assert.AreEqual(-(int)Quaternions.k, multiplier.Multiply(Quaternions.j, Quaternions.i));
            Assert.AreEqual(-(int)Quaternions.one, multiplier.Multiply(Quaternions.j, Quaternions.j));
            Assert.AreEqual((int)Quaternions.i, multiplier.Multiply(Quaternions.j, Quaternions.k));

            Assert.AreEqual((int)Quaternions.k, multiplier.Multiply(Quaternions.k, Quaternions.one));
            Assert.AreEqual((int)Quaternions.j, multiplier.Multiply(Quaternions.k, Quaternions.i));
            Assert.AreEqual(-(int)Quaternions.i, multiplier.Multiply(Quaternions.k, Quaternions.j));
            Assert.AreEqual(-(int)Quaternions.one, multiplier.Multiply(Quaternions.k, Quaternions.k));
        }
    }
}
