namespace MatrixSet.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void CreateEmptyMatrix()
        {
            Matrix matrix = new Matrix(3, 4);

            Assert.AreEqual(3, matrix.Width);
            Assert.AreEqual(4, matrix.Height);

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 4; y++)
                    Assert.IsFalse(matrix.Get(x, y));
        }

        [TestMethod]
        public void SetCells()
        {
            Matrix matrix = new Matrix(3, 3);

            matrix.Set(0, 0, true);
            matrix.Set(1, 1, true);
            matrix.Set(2, 2, true);

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    if (x == y)
                        Assert.IsTrue(matrix.Get(x, y));
                    else
                        Assert.IsFalse(matrix.Get(x, y));
        }

        [TestMethod]
        public void CreateMatrixUsingStrings()
        {
            Matrix matrix = new Matrix("1000", "0100", "0010", "0001");

            Assert.AreEqual(4, matrix.Width);
            Assert.AreEqual(4, matrix.Height);

            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    if (x == y)
                        Assert.IsTrue(matrix.Get(x, y));
                    else
                        Assert.IsFalse(matrix.Get(x, y));
        }

        [TestMethod]
        public void GetGreatestSetsInEmptyMatrix()
        {
            Matrix matrix = new Matrix(3, 4);

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetGreatestSetsInMatrixWithOneTrue()
        {
            Matrix matrix = new Matrix(3, 4);
            matrix.Set(0, 0, true);

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Count);
            Assert.AreEqual(0, result[0][0].X);
            Assert.AreEqual(0, result[0][0].Y);
        }

        [TestMethod]
        public void GetGreatestSetsInDiagonalMatrix()
        {
            Matrix matrix = new Matrix("1000", "0100", "0010", "0001");

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.All(l => l.Count == 1));
            Assert.IsTrue(result.All(l => l[0].X == l[0].Y));
            Assert.IsTrue(result.All(l => l.All(c => c.Value)));
        }

        [TestMethod]
        public void GetGreatestSetInFirstRow()
        {
            Matrix matrix = new Matrix("1110", "0000", "0000");

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(3, result[0].Count);
            Assert.IsTrue(result[0].All(c => c.Y == 0));
            Assert.IsTrue(result[0][0].X == 0);
            Assert.IsTrue(result[0][1].X == 1);
            Assert.IsTrue(result[0][2].X == 2);
        }

        [TestMethod]
        public void GetGreatestSetInFirstColumn()
        {
            Matrix matrix = new Matrix("1000", "1000", "1000");

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(3, result[0].Count);
            Assert.IsTrue(result[0].All(c => c.X == 0));
            Assert.IsTrue(result[0][0].Y == 0);
            Assert.IsTrue(result[0][1].Y == 1);
            Assert.IsTrue(result[0][2].Y == 2);
        }

        [TestMethod]
        public void GetSquareSetSizeFour()
        {
            Matrix matrix = new Matrix("1100", "1100", "1000");

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(4, result[0].Count);
            Assert.IsTrue(result[0][0].X == 0);
            Assert.IsTrue(result[0][0].Y == 0);
            Assert.IsTrue(result[0][1].X == 1);
            Assert.IsTrue(result[0][1].Y == 0);
            Assert.IsTrue(result[0][2].X == 1);
            Assert.IsTrue(result[0][2].Y == 1);
            Assert.IsTrue(result[0][3].X == 0);
            Assert.IsTrue(result[0][3].Y == 1);
        }

        [TestMethod]
        public void GetRectangularSetSizeSix()
        {
            Matrix matrix = new Matrix("1100", "1100", "1100");

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(6, result[0].Count);
            Assert.IsTrue(result[0].All(c => c.X >= 0 && c.X <= 1));
            Assert.IsTrue(result[0].All(c => c.Y >= 0 && c.Y <= 2));
        }

        [TestMethod]
        public void GetHorizontalRectangularSetSizeSix()
        {
            Matrix matrix = new Matrix("1110", "1110", "1100");

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(6, result[0].Count);
            Assert.IsTrue(result[0].All(c => c.X >= 0 && c.X <= 2));
            Assert.IsTrue(result[0].All(c => c.Y >= 0 && c.Y <= 1));
        }

        [TestMethod]
        public void GetSpareSquareSetSizeFour()
        {
            Matrix matrix = new Matrix("0101", "0000", "0101");

            var result = matrix.GetGreatestSets();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(4, result[0].Count);
            Assert.IsTrue(result[0].All(c => c.X == 1 || c.X == 3));
            Assert.IsTrue(result[0].All(c => c.Y == 0 || c.Y == 2));
        }
    }
}
