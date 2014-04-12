namespace DeceitfulWar.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StrategyTests
    {
        [TestMethod]
        public void CalculateSimpleWarWin()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateWar(new double[] { 0.2 }, new double[] { 0.1 });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculateWarCaseOne()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateWar(new double[] { 0.5 }, new double[] { 0.6 });

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculateDeceitfulWarCaseOne()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateDeceitfulWar(new double[] { 0.5 }, new double[] { 0.6 });

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculateWarCaseTwo()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateWar(new double[] { 0.7, 0.2 }, new double[] { 0.8, 0.3 });

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculateDeceitfulWarCaseTwo()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateDeceitfulWar(new double[] { 0.7, 0.2 }, new double[] { 0.8, 0.3 });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculateWarCaseThree()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateWar(new double[] { 0.5, 0.1, 0.9 }, new double[] { 0.6, 0.4, 0.3 });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculateDeceitfulWarCaseThree()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateDeceitfulWar(new double[] { 0.5, 0.1, 0.9 }, new double[] { 0.6, 0.4, 0.3 });

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CalculateWarCaseFour()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateWar(new double[] { 0.186, 0.389, 0.907, 0.832, 0.959, 0.557, 0.300, 0.992, 0.899 }, new double[] { 0.916, 0.728, 0.271, 0.520, 0.700, 0.521, 0.215, 0.341, 0.458 });

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void CalculateDeceitfulWarCaseFour()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateDeceitfulWar(new double[] { 0.186, 0.389, 0.907, 0.832, 0.959, 0.557, 0.300, 0.992, 0.899 }, new double[] { 0.916, 0.728, 0.271, 0.520, 0.700, 0.521, 0.215, 0.341, 0.458 });

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void CalculateSimpleWarLost()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateWar(new double[] { 0.1 }, new double[] { 0.2 });

            Assert.AreEqual(0, result);
        }
    }
}
