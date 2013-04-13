namespace TreasureTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Treasure;

    [TestClass]
    public class TroveTests
    {
        [TestMethod]
        public void CannotOpenChestWithoutKeys()
        {
            Trove trove = new Trove();
            trove.AddChest(new Chest(1, new int[] { 2, 3 }));

            var result = trove.GetSolution();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void CanOpenChestWithKey()
        {
            Trove trove = new Trove();
            trove.AddKey(1);
            trove.AddChest(new Chest(1, new int[] { 2, 3 }));

            var result = trove.GetSolution();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0, result[0]);
        }

        [TestMethod]
        public void CanOpenTwoChestsWithKey()
        {
            Trove trove = new Trove();
            trove.AddKey(1);
            trove.AddChest(new Chest(2, new int[] {  }));
            trove.AddChest(new Chest(1, new int[] { 2 }));

            var result = trove.GetSolution();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(0, result[1]);
        }

        [TestMethod]
        public void CanOpenFourChestsWithOneKey()
        {
            Trove trove = new Trove();
            trove.AddKey(1);
            trove.AddChest(new Chest(1, new int[] { }));
            trove.AddChest(new Chest(1, new int[] { 1, 3 }));
            trove.AddChest(new Chest(2, new int[] { }));
            trove.AddChest(new Chest(3, new int[] { 2 }));

            var result = trove.GetSolution();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(0, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(2, result[3]);
        }

        [TestMethod]
        public void CanOpenThreeChestsWithThreeKeys()
        {
            Trove trove = new Trove();
            trove.AddKey(1);
            trove.AddKey(1);
            trove.AddKey(1);
            trove.AddChest(new Chest(1, new int[] { }));
            trove.AddChest(new Chest(1, new int[] { }));
            trove.AddChest(new Chest(1, new int[] { }));

            var result = trove.GetSolution();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);
            Assert.AreEqual(2, result[2]);
        }

        [TestMethod]
        public void CannotOpenOneChestWithoutKey()
        {
            Trove trove = new Trove();
            trove.AddKey(2);
            trove.AddChest(new Chest(1, new int[] { 1 }));

            var result = trove.GetSolution();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GoogleSmallCaseOne()
        {
            Trove trove = new Trove();
            trove.AddKeys("1 1 1");
            trove.AddChest(new Chest("2 2 2 2"));
            trove.AddChest(new Chest("1 0"));
            trove.AddChest(new Chest("1 3 1 1 1"));
            trove.AddChest(new Chest("1 1 1"));
            trove.AddChest(new Chest("1 1 2"));
            trove.AddChest(new Chest("2 0"));
            trove.AddChest(new Chest("1 1 1"));
            trove.AddChest(new Chest("2 2 1 1"));
            trove.AddChest(new Chest("2 3 1 2 2"));
            trove.AddChest(new Chest("2 1 2"));

            var result = trove.GetSolution();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GoogleSmallCaseTwo()
        {
            Trove trove = new Trove();
            trove.AddKeys("5 2 2 2 2 4 2 3 3 1 4 2 1 4 3 3 1 2 2 2");
            trove.AddChest(new Chest("1 2 2 2"));
            trove.AddChest(new Chest("2 2 5 2"));
            trove.AddChest(new Chest("1 1 5"));
            trove.AddChest(new Chest("3 1 4"));
            trove.AddChest(new Chest("4 3 2 5 3"));
            trove.AddChest(new Chest("3 1 2"));
            trove.AddChest(new Chest("4 3 3 5 1"));
            trove.AddChest(new Chest("3 1 2"));
            trove.AddChest(new Chest("4 2 4 5"));
            trove.AddChest(new Chest("3 0"));
            trove.AddChest(new Chest("5 1 2"));
            trove.AddChest(new Chest("5 2 3 4"));
            trove.AddChest(new Chest("1 0"));
            trove.AddChest(new Chest("3 1 5"));
            trove.AddChest(new Chest("1 0"));

            var result = trove.GetSolution();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GoogleSmallCaseNine()
        {
            Trove trove = new Trove();
            trove.AddKeys("3 4 3");
            trove.AddChest(new Chest("4 0"));
            trove.AddChest(new Chest("4 3 2 3 3"));
            trove.AddChest(new Chest("4 0"));
            trove.AddChest(new Chest("2 0"));
            trove.AddChest(new Chest("1 2 1 4"));
            trove.AddChest(new Chest("3 0"));
            trove.AddChest(new Chest("3 2 3 2"));
            trove.AddChest(new Chest("2 2 3 4"));
            trove.AddChest(new Chest("4 0"));
            trove.AddChest(new Chest("3 1 4"));
            trove.AddChest(new Chest("3 2 1 1"));
            trove.AddChest(new Chest("4 0"));
            trove.AddChest(new Chest("4 3 4 2 4"));
            trove.AddChest(new Chest("3 2 3 4"));
            trove.AddChest(new Chest("3 0"));
            trove.AddChest(new Chest("1 3 2 4 4"));
            trove.AddChest(new Chest("3 1 4"));
            trove.AddChest(new Chest("3 2 1 4"));
            trove.AddChest(new Chest("3 1 3"));
            trove.AddChest(new Chest("4 1 4"));

            var result = trove.GetSolution();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GoogleSmallCaseSubNine()
        {
            Trove trove = new Trove();
            trove.AddKeys("1 4");
            trove.AddChest(new Chest("3 2 1 1"));
            trove.AddChest(new Chest("3 2 1 4"));
            trove.AddChest(new Chest("1 2 1 4"));
            trove.AddChest(new Chest("3 1 3"));
            trove.AddChest(new Chest("4 1 4"));

            var result = trove.GetSolution();

            Assert.IsNull(result);
        }
    }
}
