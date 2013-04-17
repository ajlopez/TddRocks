namespace GameTreeSearchTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GameTreeSearch;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TreeSearchTests
    {
        [TestMethod]
        public void DepthZeroReturnRootNode()
        {
            Tree tree = new Tree(3);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(3, search.FindMaxValue(tree, 0));
        }

        [TestMethod]
        public void DepthOneReturnRootNodeOnTreeWithoutChildren()
        {
            Tree tree = new Tree(5);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(5, search.FindMaxValue(tree, 1));
        }

        [TestMethod]
        public void DepthOneOnTreeWithOnlyOneChild()
        {
            Tree tree = new Tree(5, new Tree[] { new Tree(3) });
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(3, search.FindMaxValue(tree, 1));
        }

        [TestMethod]
        public void DepthOneOnTreeWithOnlyTwoChildren()
        {
            Tree tree = new Tree(5, new Tree[] { new Tree(3), new Tree(7) });
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(7, search.FindMaxValue(tree, 1));
        }

        [TestMethod]
        public void DepthZeroOnTreeWithChildren()
        {
            Tree tree = new Tree(5, new Tree[] { new Tree(3), new Tree(7) });
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(5, search.FindMaxValue(tree, 0));
        }

        [TestMethod]
        public void DepthTwoOnTreeWithChildren()
        {
            Tree tree = new Tree(5, new Tree[] { new Tree(3), new Tree(7) });
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(7, search.FindMaxValue(tree, 2));
        }

        [TestMethod]
        public void DepthTwoOnTreeWithTwoLevelsOfChildren()
        {
            Tree tree = new Tree(5, new Tree[] { new Tree(3, new Tree[] { new Tree(5), new Tree(7) }), new Tree(7, new Tree[] { new Tree(9), new Tree(11) }) });
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(11, search.FindMaxValue(tree, 2));
        }

        [TestMethod]
        public void DepthTwoOnTreeWithOneAndTwoLevelsOfChildren()
        {
            Tree tree = new Tree(5, new Tree[] { new Tree(3, new Tree[] { new Tree(5), new Tree(9) }), new Tree(7) });
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(9, search.FindMaxValue(tree, 2));
        }
    }
}
