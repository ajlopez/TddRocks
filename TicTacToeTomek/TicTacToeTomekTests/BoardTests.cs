namespace TicTacToeTomekTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeTomek;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void EvaluateEmptyBoard()
        {
            Board board = new Board();

            Assert.AreEqual(Status.Draw, board.Evaluate());
        }

        [TestMethod]
        public void EvaluateFirstRowWithXs()
        {
            Board board = new Board("XXXX");

            Assert.AreEqual(Status.XWon, board.Evaluate());
        }

        [TestMethod]
        public void EvaluateSecondRowWithXs()
        {
            Board board = new Board("....XXXX");

            Assert.AreEqual(Status.XWon, board.Evaluate());
        }

        [TestMethod]
        public void EvaluateFirstRowWithOs()
        {
            Board board = new Board("OOOO");

            Assert.AreEqual(Status.OWon, board.Evaluate());
        }

        [TestMethod]
        public void EvaluateSecondRowWithOs()
        {
            Board board = new Board("....OOOO");

            Assert.AreEqual(Status.OWon, board.Evaluate());
        }

        [TestMethod]
        public void EvaluateFirstRowWithXsAndT()
        {
            Board board = new Board("XTXX");

            Assert.AreEqual(Status.XWon, board.Evaluate());
        }

        [TestMethod]
        public void EvaluateSecondRowWithOsAndT()
        {
            Board board = new Board("....OTOO");

            Assert.AreEqual(Status.OWon, board.Evaluate());
        }
    }
}
