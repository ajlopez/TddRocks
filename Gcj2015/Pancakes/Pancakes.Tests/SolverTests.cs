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
    }
}
