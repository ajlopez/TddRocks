namespace Minesweeper.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MasterTests
    {
        [TestMethod]
        public void SolveImpossibleCases()
        {
            Master master = new Master();

            Assert.AreEqual("Impossible", master.Solve(5, 5, 23));
            Assert.AreEqual("Impossible", master.Solve(2, 2, 1));
            Assert.AreNotEqual("Impossible", master.Solve(4, 7, 3));
            Assert.AreNotEqual("Impossible", master.Solve(3, 1, 1));
        }
    }
}
