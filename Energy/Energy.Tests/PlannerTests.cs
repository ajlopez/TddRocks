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

            Assert.AreEqual(5, planner.Decide(5, 2, 1));
        }

        [TestMethod]
        public void FirstPlannerRun()
        {
            Planner planner = new Planner(5, 2);

            Assert.AreEqual(12, planner.Run(new int[] { 2, 1 }));
        }

        [TestMethod]
        public void SecondPlannerFirstDay()
        {
            Planner planner = new Planner(5, 2);

            Assert.AreEqual(2, planner.Decide(5, 1, 2));
        }

        [TestMethod]
        public void SecondPlannerRun()
        {
            Planner planner = new Planner(5, 2);

            Assert.AreEqual(12, planner.Run(new int[] { 1, 2 }));
        }

        [TestMethod]
        public void ThirdPlannerThreeDay()
        {
            Planner planner = new Planner(3, 3);

            Assert.AreEqual(3, planner.Decide(3, 4, 1));
            Assert.AreEqual(3, planner.Decide(3, 1, 3));
            Assert.AreEqual(3, planner.Decide(3, 3, 5));
        }

        [TestMethod]
        public void ThirdPlannerRun()
        {
            Planner planner = new Planner(3, 3);

            Assert.AreEqual(39, planner.Run(new int[] { 4, 1, 3, 5 }));
        }

        [TestMethod]
        public void GooglePlannerFirstDay()
        {
            Planner planner = new Planner(5, 5);

            Assert.AreEqual(5, planner.Decide(5, 10, 10));
        }

        [TestMethod]
        public void GooglePlannerRun()
        {
            Planner planner = new Planner(5, 5);

            Assert.AreEqual(500, planner.Run(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));
        }

        [TestMethod]
        public void GooglePlanner2Run()
        {
            Planner planner = new Planner(3, 1);

            Assert.AreEqual(1, planner.Decide(3, 1, 2));
            Assert.AreEqual(1, planner.Decide(3, 2, 3));
            Assert.AreEqual(3, planner.Decide(3, 3, 2));
            Assert.AreEqual(1, planner.Decide(1, 2, 1));
            Assert.AreEqual(15, planner.Run(new int[] { 1, 2, 3, 2, 1 }));
        }

        [TestMethod]
        public void GooglePlanner3Run()
        {
            Planner planner = new Planner(5, 1);

            Assert.AreEqual(1, planner.Decide(5, 1, 10));
            Assert.AreEqual(5, planner.Decide(5, 10, 2));
            Assert.AreEqual(0, planner.Decide(1, 2, 9));
            Assert.AreEqual(2, planner.Decide(2, 9, 3));
            Assert.AreEqual(0, planner.Decide(1, 3, 8));
            Assert.AreEqual(2, planner.Decide(2, 8, 4));
            Assert.AreEqual(0, planner.Decide(1, 4, 7));
            Assert.AreEqual(2, planner.Decide(2, 7, 5));
            Assert.AreEqual(0, planner.Decide(1, 5, 6));
        }

        [TestMethod]
        public void GooglePlanner4Run()
        {
            Planner planner = new Planner(5, 1);

            Assert.AreEqual(1, planner.Decide(5, new int[] { 8, 9, 7, 1, 2, 9, 10, 8, 7, 10}));
            Assert.AreEqual(5, planner.Decide(5, new int[] { 9, 7, 1, 2, 9, 10, 8, 7, 10 }));
            Assert.AreEqual(0, planner.Decide(1, new int[] { 7, 1, 2, 9, 10, 8, 7, 10 }));
            Assert.AreEqual(0, planner.Decide(2, new int[] { 1, 2, 9, 10, 8, 7, 10 }));
            Assert.AreEqual(0, planner.Decide(3, new int[] { 2, 9, 10, 8, 7, 10 }));
            Assert.AreEqual(0, planner.Decide(4, new int[] { 9, 10, 8, 7, 10 }));
            Assert.AreEqual(5, planner.Decide(5, new int[] { 10, 8, 7, 10 }));
        }
    }
}
