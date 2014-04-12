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
        public void CalculateSimpleWarLost()
        {
            Strategy strat = new Strategy();

            var result = strat.CalculateWar(new double[] { 0.1 }, new double[] { 0.2 });

            Assert.AreEqual(0, result);
        }
    }
}
