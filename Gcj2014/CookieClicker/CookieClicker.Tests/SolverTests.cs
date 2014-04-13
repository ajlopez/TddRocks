namespace CookieClicker.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void SolveCaseOne()
        {
            Solver solver = new Solver();

            Assert.AreEqual(1.0, solver.Solve(30.0, 2.0, 1.0, 2.0));
        }

        [TestMethod]
        public void SolveCaseTwo()
        {
            Solver solver = new Solver();

            Assert.AreEqual(39.1666667, solver.Solve(30.0, 2.0, 2.0, 100.0), 0.0000001);
        }

        [TestMethod]
        public void SolveCaseThree()
        {
            Solver solver = new Solver();

            Assert.AreEqual(63.9680013, solver.Solve(30.50000, 2.0, 3.14159, 1999.19990), 0.0000001);
        }

        [TestMethod]
        public void SolveCaseFour()
        {
            Solver solver = new Solver();

            Assert.AreEqual(526.1904762, solver.Solve(500.0, 2.0, 4.0, 2000.0), 0.0000001);
        }

        [TestMethod]
        public void SolveCaseLarge()
        {
            Solver solver = new Solver();

            solver.Solve(1091.73252, 0.2, 15.44421, 656.09352);
            solver.Solve(1.03291, 0.2, 99.49224, 99999.91210);
        }
    }
}
