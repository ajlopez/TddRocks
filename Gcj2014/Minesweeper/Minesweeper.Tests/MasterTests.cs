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

            Assert.AreEqual("Impossible", master.Solve(2, 1, 1));
            Assert.AreEqual("Impossible", master.Solve(5, 5, 23));
            Assert.AreEqual("Impossible", master.Solve(2, 2, 1));
            Assert.AreEqual("Impossible", master.Solve(2, 10, 1));
            Assert.AreEqual("Impossible", master.Solve(10, 2, 1));

            Assert.AreNotEqual("Impossible", master.Solve(4, 7, 3));
            Assert.AreNotEqual("Impossible", master.Solve(3, 1, 1));
            Assert.AreNotEqual("Impossible", master.Solve(5, 3, 2));
        }

        [TestMethod]
        public void SolveSampleCaseOne()
        {
            Master master = new Master();

            var result = master.Solve(3, 1, 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IList<string>));

            var lines = (IList<string>)result;

            Assert.AreEqual(3, lines.Count);
            Assert.AreEqual("c", lines[0]);
            Assert.AreEqual(".", lines[1]);
            Assert.AreEqual("*", lines[2]);
        }

        [TestMethod]
        public void SolveSimpleCase()
        {
            Master master = new Master();

            var result = master.Solve(4, 4, 16 - 9);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IList<string>));

            var lines = (IList<string>)result;

            Assert.AreEqual(4, lines.Count);
            Assert.AreEqual("c..*", lines[0]);
            Assert.AreEqual("...*", lines[1]);
            Assert.AreEqual("...*", lines[2]);
            Assert.AreEqual("****", lines[3]);
        }

        [TestMethod]
        public void SolveSampleCaseTwo()
        {
            Master master = new Master();

            var result = master.Solve(4, 7, 3);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IList<string>));

            var lines = (IList<string>)result;

            Assert.AreEqual(4, lines.Count);
            Assert.AreEqual("c......", lines[0]);
            Assert.AreEqual(".......", lines[1]);
            Assert.AreEqual("......*", lines[2]);
            Assert.AreEqual(".....**", lines[3]);
        }

        [TestMethod]
        public void SolveSampleCaseTwoRotated()
        {
            Master master = new Master();

            var result = master.Solve(7, 4, 3);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IList<string>));

            var lines = (IList<string>)result;

            Assert.AreEqual(7, lines.Count);
            Assert.AreEqual("c...", lines[0]);
            Assert.AreEqual("....", lines[1]);
            Assert.AreEqual("....", lines[2]);
            Assert.AreEqual("....", lines[3]);
            Assert.AreEqual("...*", lines[4]);
            Assert.AreEqual("...*", lines[5]);
            Assert.AreEqual("...*", lines[6]);
        }

        [TestMethod]
        public void SolveSampleCaseThree()
        {
            Master master = new Master();

            var result = master.Solve(10, 10, 82);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IList<string>));

            var lines = (IList<string>)result;

            Assert.AreEqual(10, lines.Count);
            Assert.AreEqual("c.********", lines[0]);
            Assert.AreEqual("..********", lines[1]);
            Assert.AreEqual("..********", lines[2]);
            Assert.AreEqual("..********", lines[3]);
            Assert.AreEqual("..********", lines[4]);
            Assert.AreEqual("..********", lines[5]);
            Assert.AreEqual("..********", lines[6]);
            Assert.AreEqual("..********", lines[7]);
            Assert.AreEqual("..********", lines[8]);
            Assert.AreEqual("**********", lines[9]);
        }
    }
}
