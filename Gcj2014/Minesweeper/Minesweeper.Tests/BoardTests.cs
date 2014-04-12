namespace Minesweeper.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void FullOneByOne()
        {
            Board board = new Board(1, 1);

            var result = board.ToLines();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("*", result[0]);
        }

        [TestMethod]
        public void FullTwoByThree()
        {
            Board board = new Board(2, 3);

            var result = board.ToLines();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("***", result[0]);
            Assert.AreEqual("***", result[1]);
        }

        [TestMethod]
        public void FourByFourWithThreeByTwoEmpty()
        {
            Board board = new Board(4, 4);

            board.SetEmpty(3, 2);

            var result = board.ToLines();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("..**", result[0]);
            Assert.AreEqual("..**", result[1]);
            Assert.AreEqual("..**", result[2]);
            Assert.AreEqual("****", result[3]);
        }

        [TestMethod]
        public void FourByFourWithThreeByTwoEmptyAndClick()
        {
            Board board = new Board(4, 4);

            board.SetEmpty(3, 2);
            board.SetClick(0, 0);

            var result = board.ToLines();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("c.**", result[0]);
            Assert.AreEqual("..**", result[1]);
            Assert.AreEqual("..**", result[2]);
            Assert.AreEqual("****", result[3]);
        }
    }
}
