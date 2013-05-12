namespace GreatWall.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AttacksTests
    {
        [TestMethod]
        public void NoTribes()
        {
            Attacks attacks = new Attacks();
            Assert.AreEqual(0, attacks.Count(new Tribe[] { }));
        }

        [TestMethod]
        public void OneTribe()
        {
            Attacks attacks = new Attacks();
            Assert.AreEqual(10, attacks.Count(new Tribe[] { new Tribe(10, 10, 0, 2, 6, 4, 3, 1) }));
        }

        [TestMethod]
        public void GoogleSampleTwoTribes()
        {
            Attacks attacks = new Attacks();
            Assert.AreEqual(5, attacks.Count(new Tribe[] { new Tribe(0, 3, 0, 2, 10, 2, 3, -2), new Tribe(10, 3, 2, 3, 8, 7, 2, 0) }));
        }
    }
}
