namespace LawnmoverTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Lawnmover;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PatternTests
    {
        [TestMethod]
        public void CreatePattern()
        {
            Pattern pattern = new Pattern(3, 2);

            Assert.AreEqual(3, pattern.Width);
            Assert.AreEqual(2, pattern.Height);
        }
    }
}
