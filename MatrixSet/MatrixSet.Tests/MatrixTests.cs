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
    }
}
