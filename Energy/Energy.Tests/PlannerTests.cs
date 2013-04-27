namespace Energy.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlannerTests
    {
        [TestMethod]
        public void FirstPlannerFirstDay()
        {
            Planner planner = new Planner(5, 2);

            Assert.AreEqual(5, planner.Decide(5, 2, 2));
        }

        [TestMethod]
        public void SecondPlannerFirstDay()
        {
            Planner planner = new Planner(5, 2);

            Assert.AreEqual(2, planner.Decide(5, 1, 2));
        }

        [TestMethod]
        public void ThirdPlannerThreeDay()
        {
            Planner planner = new Planner(3, 3);

            Assert.AreEqual(3, planner.Decide(3, 4, 1));
            Assert.AreEqual(3, planner.Decide(3, 1, 3));
            Assert.AreEqual(3, planner.Decide(3, 3, 5));
        }
    }
}
