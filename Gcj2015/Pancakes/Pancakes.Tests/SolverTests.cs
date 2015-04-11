namespace Pancakes.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ResolveCase1()
        {
            Assert.AreEqual(3, Solver.Resolve(new int[] { 3 }));
        }

        [TestMethod]
        public void ResolveCase1String()
        {
            Assert.AreEqual(3, Solver.Resolve("3"));
        }

        [TestMethod]
        public void ResolveCase2()
        {
            Assert.AreEqual(2, Solver.Resolve(new int[] { 1, 2, 1, 2 }));
        }

        [TestMethod]
        public void ResolveCase2String()
        {
            Assert.AreEqual(2, Solver.Resolve("1 2 1 2"));
        }

        [TestMethod]
        public void ResolveCase3()
        {
            Assert.AreEqual(3, Solver.Resolve(new int[] { 4 }));
        }

        [TestMethod]
        public void ResolveCase3String()
        {
            Assert.AreEqual(3, Solver.Resolve("4"));
        }

        [TestMethod]
        public void ResolveEdgeCase()
        {
            Assert.AreEqual(4, Solver.Resolve(new int[] { 4, 4 }));
        }

        [TestMethod]
        public void ResolveEdgeCaseString()
        {
            Assert.AreEqual(4, Solver.Resolve("4 4"));
        }

        [TestMethod]
        public void ResolveLowGain()
        {
            Assert.AreEqual(5, Solver.Resolve(new int[] { 5, 5, 4 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 5, 5, 3 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 5, 5, 2 }));
            Assert.AreEqual(4, Solver.Resolve(new int[] { 4, 4, 2 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 1, 3, 5, 5, 5 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 5, 5, 1 }));
        }

        [TestMethod]
        public void ResolveSplit()
        {
            Assert.AreEqual(5, Solver.Resolve(new int[] { 5, 5, 5, 5, 5, 5, 4, 4 }));
            Assert.AreEqual(7, Solver.Resolve(new int[] { 5, 5, 5, 5, 9, 9 }));
            Assert.AreEqual(6, Solver.Resolve(new int[] { 9, 3, 5, 1 }));
            Assert.AreEqual(6, Solver.Resolve(new int[] { 3, 7, 8 }));
            Assert.AreEqual(6, Solver.Resolve(new int[] { 4, 6, 3, 7 }));
            Assert.AreEqual(7, Solver.Resolve(new int[] { 9, 6 }));
            Assert.AreEqual(8, Solver.Resolve(new int[] { 3, 5, 8, 8, 6 }));
            Assert.AreEqual(4, Solver.Resolve(new int[] { 4, 3, 2, 1 }));
            Assert.AreEqual(6, Solver.Resolve(new int[] { 6, 8, 2, 2 }));
            Assert.AreEqual(8, Solver.Resolve(new int[] { 5, 6, 9, 6, 9, 6 }));
            Assert.AreEqual(8, Solver.Resolve(new int[] { 6, 6, 6, 6, 9, 9 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 4, 5, 2, 1, 5 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 4, 4, 5, 2, 5 }));
            Assert.AreEqual(8, Solver.Resolve(new int[] { 5, 5, 5, 9, 9, 9 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 8, 4, 2 }));
            Assert.AreEqual(8, Solver.Resolve(new int[] { 3, 6, 6, 6, 9, 9 }));
            Assert.AreEqual(4, Solver.Resolve(new int[] { 3, 3, 3, 2, 5 }));
            Assert.AreEqual(6, Solver.Resolve(new int[] { 1, 7, 7 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 1, 4, 5, 2, 3 }));
            Assert.AreEqual(6, Solver.Resolve(new int[] { 3, 3, 8, 5 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 8, 4, 4 }));
            Assert.AreEqual(5, Solver.Resolve(new int[] { 8, 4 }));
            Assert.AreEqual(7, Solver.Resolve(new int[] { 6, 6, 8, 3 }));
        }

        [TestMethod]
        public void ResolveRepeated()
        {
            Assert.AreEqual(9, Solver.Resolve(new int[] { 9, 9, 9, 9, 9, 9 }));
            Assert.AreEqual(8, Solver.Resolve(new int[] { 8, 8, 8, 8, 8 }));
            Assert.AreEqual(8, Solver.Resolve(new int[] { 8, 8, 8, 8 }));
            Assert.AreEqual(7, Solver.Resolve(new int[] { 8, 8, 8 }));
            Assert.AreEqual(9, Solver.Resolve(new int[] { 9, 9, 9, 9 }));
            Assert.AreEqual(8, Solver.Resolve(new int[] { 9, 9, 9 }));
        }
    }
}
