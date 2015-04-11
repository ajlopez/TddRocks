namespace StandingOvation.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void SolveCase1()
        {
            Assert.AreEqual(0, Solver.Resolve(new int[] { 1, 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void SolveCase1String()
        {
            Assert.AreEqual(0, Solver.Resolve("11111"));
        }

        [TestMethod]
        public void SolveCase2()
        {
            Assert.AreEqual(1, Solver.Resolve(new int[] { 0, 9 }));
        }

        [TestMethod]
        public void SolveCase2String()
        {
            Assert.AreEqual(1, Solver.Resolve("09"));
        }

        [TestMethod]
        public void SolveCase3()
        {
            Assert.AreEqual(2, Solver.Resolve(new int[] { 1, 1, 0, 0, 1, 1 }));
        }

        [TestMethod]
        public void SolveCase3String()
        {
            Assert.AreEqual(2, Solver.Resolve("110011"));
        }

        [TestMethod]
        public void SolveCase4()
        {
            Assert.AreEqual(0, Solver.Resolve(new int[] { 1 }));
        }

        [TestMethod]
        public void SolveCase4String()
        {
            Assert.AreEqual(0, Solver.Resolve("1"));
        }

        [TestMethod]
        public void SolveEdgeCasesWithZero()
        {
            Assert.AreEqual(0, Solver.Resolve(new int[] { 2, 0, 1 }));
            Assert.AreEqual(0, Solver.Resolve(new int[] { 3, 0, 0, 1 }));
            Assert.AreEqual(0, Solver.Resolve(new int[] { 4, 0, 0, 0, 1 }));
        }

        [TestMethod]
        public void SolveEdgeCasesWithZeroString()
        {
            Assert.AreEqual(0, Solver.Resolve("201"));
            Assert.AreEqual(0, Solver.Resolve("3001"));
            Assert.AreEqual(0, Solver.Resolve("40001"));
        }

        [TestMethod]
        public void SolveEdgeCasesWithOne()
        {
            Assert.AreEqual(1, Solver.Resolve(new int[] { 1, 0, 1 }));
            Assert.AreEqual(1, Solver.Resolve(new int[] { 2, 0, 0, 1 }));
            Assert.AreEqual(1, Solver.Resolve(new int[] { 3, 0, 0, 0, 1 }));
        }

        [TestMethod]
        public void SolveEdgeCasesWithOneString()
        {
            Assert.AreEqual(1, Solver.Resolve("101"));
            Assert.AreEqual(1, Solver.Resolve("2001"));
            Assert.AreEqual(1, Solver.Resolve("30001"));
        }
    }
}
