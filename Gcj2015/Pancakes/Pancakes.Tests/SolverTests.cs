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
    }
}
