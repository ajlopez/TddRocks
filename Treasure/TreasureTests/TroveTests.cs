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
    }
}
