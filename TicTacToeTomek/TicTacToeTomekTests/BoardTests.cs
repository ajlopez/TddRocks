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

            Assert.AreEqual(Status.Tie, board.Evaluate());
        }
    }
}
