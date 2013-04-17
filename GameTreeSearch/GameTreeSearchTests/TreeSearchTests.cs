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
            Tree tree = CreateTree(3);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(3, search.FindMaxValue(tree, 0));
        }

        [TestMethod]
        public void DepthOneReturnRootNodeOnTreeWithoutChildren()
        {
            Tree tree = CreateTree(5);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(5, search.FindMaxValue(tree, 1));
        }

        [TestMethod]
        public void DepthOneOnTreeWithOnlyOneChild()
        {
            Tree tree = CreateTree(5, 3);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(3, search.FindMaxValue(tree, 1));
        }

        [TestMethod]
        public void DepthOneOnTreeWithOnlyTwoChildren()
        {
            Tree tree = CreateTree(5, 3, 7);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(7, search.FindMaxValue(tree, 1));
        }

        [TestMethod]
        public void DepthZeroOnTreeWithChildren()
        {
            Tree tree = CreateTree(5, 3, 7);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(5, search.FindMaxValue(tree, 0));
        }

        [TestMethod]
        public void DepthTwoOnTreeWithChildren()
        {
            Tree tree = CreateTree(5, 3, 7);
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(7, search.FindMaxValue(tree, 2));
        }

        [TestMethod]
        public void DepthTwoOnTreeWithTwoLevelsOfChildren()
        {
            Tree tree = CreateTreeNodes(5, CreateTree(3, 5, 7), CreateTree(7, 9, 11));
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(11, search.FindMaxValue(tree, 2));
        }

        [TestMethod]
        public void DepthTwoOnTreeWithOneAndTwoLevelsOfChildren()
        {
            Tree tree = CreateTreeNodes(5, CreateTree(3, 5, 9), CreateTree(7));
            TreeSearch search = new TreeSearch();

            Assert.AreEqual(9, search.FindMaxValue(tree, 2));
        }

        private static Tree CreateTree(int value, params int[] values)
        {
            IList<Tree> children = new List<Tree>();

            foreach (int val in values)
                children.Add(new Tree(val));

            return new Tree(value, children);
        }

        private static Tree CreateTreeNodes(int value, params Tree[] nodes)
        {
            return new Tree(value, nodes);
        }
    }
}
