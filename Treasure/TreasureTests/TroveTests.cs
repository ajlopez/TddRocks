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

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
