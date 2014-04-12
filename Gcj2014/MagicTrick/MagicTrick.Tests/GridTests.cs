namespace MagicTrick.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void CreateGridAndGetRows()
        {
            Grid grid = new Grid(new string[] { "1 2 3", "4 5 6", "7 8 9" });

            var row1 = grid.GetRow(1);

            Assert.IsNotNull(row1);
            Assert.AreEqual(3, row1.Count);
            Assert.IsTrue(row1.Contains(1));
            Assert.IsTrue(row1.Contains(2));
            Assert.IsTrue(row1.Contains(3));

            var row2 = grid.GetRow(2);

            Assert.IsNotNull(row2);
            Assert.AreEqual(3, row2.Count);
            Assert.IsTrue(row2.Contains(4));
            Assert.IsTrue(row2.Contains(5));
            Assert.IsTrue(row2.Contains(6));

            var row3 = grid.GetRow(3);

            Assert.IsNotNull(row3);
            Assert.AreEqual(3, row3.Count);
            Assert.IsTrue(row3.Contains(7));
            Assert.IsTrue(row3.Contains(8));
            Assert.IsTrue(row3.Contains(9));
        }
    }
}
