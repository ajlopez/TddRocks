namespace GameTreeSearchTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TreeSearchTests
    {
        [TestMethod]
        public void DepthZeroReturnRootNode()
        {
            Tree tree = new Tree(3);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(3, search.FindMaxValue(tree));
        }
    }
}
