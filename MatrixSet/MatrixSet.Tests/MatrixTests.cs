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
    }
}
