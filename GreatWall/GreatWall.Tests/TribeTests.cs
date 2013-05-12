namespace GreatWall.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TribeTests
    {
        [TestMethod]
        public void CreateTribe()
        {
            Tribe tribe = new Tribe(10, 10, 2, 10, 6, 1, 1, 1);

            Assert.IsTrue(tribe.CanAttack());
            Assert.AreEqual(10, tribe.Day);
            Assert.AreEqual(6, tribe.Strength);
            Assert.AreEqual(2, tribe.West);
            Assert.AreEqual(10, tribe.East);
        }

        [TestMethod]
        public void CreateTribeAndNewDay()
        {
            Tribe tribe = new Tribe(10, 10, 2, 10, 6, 1, 2, 3);

            tribe.NewDay();

            Assert.IsTrue(tribe.CanAttack());
            Assert.AreEqual(11, tribe.Day);
            Assert.AreEqual(9, tribe.Strength);
            Assert.AreEqual(4, tribe.West);
            Assert.AreEqual(12, tribe.East);
        }

        [TestMethod]
        public void CannotAttack()
        {
            Tribe tribe = new Tribe(10, 3, 2, 10, 6, 1, 2, 3);

            tribe.NewDay();
            tribe.NewDay();
            Assert.IsTrue(tribe.CanAttack());
            tribe.NewDay();
            Assert.IsFalse(tribe.CanAttack());
        }
    }
}
