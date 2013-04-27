namespace Bulleyes.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PaintTests
    {
        [TestMethod]
        public void PaintForRingRadiusOne()
        {
            Paint paint = new Paint();

            Assert.AreEqual(3, paint.PaintFor(1));
        }

        [TestMethod]
        public void PaintForRingRadiusTwo()
        {
            Paint paint = new Paint();

            Assert.AreEqual(5, paint.PaintFor(2));
        }

        [TestMethod]
        public void CountForRadiusOnePaintNine()
        {
            Paint paint = new Paint();

            Assert.AreEqual(1, paint.CountFor(1, 9));
        }

        [TestMethod]
        public void CountForRadiusOnePaintTen()
        {
            Paint paint = new Paint();

            Assert.AreEqual(2, paint.CountFor(1, 10));
        }

        [TestMethod]
        public void CountForRadiusThreePaintForty()
        {
            Paint paint = new Paint();

            Assert.AreEqual(3, paint.CountFor(3, 40));
        }

        [TestMethod]
        public void CountForRadiusOnePaint1000000000000000000()
        {
            Paint paint = new Paint();

            Assert.AreEqual(707106780, paint.CountFor(1, 1000000000000000000));
        }

        [TestMethod]
        public void CountForRadius10000000000000000Paint1000000000000000000()
        {
            Paint paint = new Paint();

            Assert.AreEqual(49, paint.CountFor(10000000000000000, 1000000000000000000));
        }
    }
}
