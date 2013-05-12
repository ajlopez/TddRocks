namespace GreatWall.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void AttackInitialWall()
        {
            Wall wall = new Wall();
            wall.NewDay();
            Assert.IsTrue(wall.Attack(10, 12, 6));
        }

        [TestMethod]
        public void AttackInitialWallTwice()
        {
            Wall wall = new Wall();
            wall.NewDay();
            Assert.IsTrue(wall.Attack(10, 12, 6));
            Assert.IsTrue(wall.Attack(10, 12, 6));
        }

        [TestMethod]
        public void AttackInitialWallTwoDays()
        {
            Wall wall = new Wall();
            wall.NewDay();
            Assert.IsTrue(wall.Attack(10, 12, 6));
            wall.NewDay();
            Assert.IsFalse(wall.Attack(10, 12, 6));
        }

        [TestMethod]
        public void AttackInitialThousandDays()
        {
            Wall wall = new Wall();

            for (int k = 0; k < 1000; k++)
            {
                wall.NewDay();
                Assert.IsTrue(wall.Attack(k, k + 100, 6));
            }
        }

        [TestMethod]
        public void AttackInitialThousandDaysTwice()
        {
            Wall wall = new Wall();

            for (int k = 0; k < 1000; k++)
            {
                wall.NewDay();
                Assert.IsTrue(wall.Attack(k, k + 100, 6));
            }

            for (int k = 0; k < 1000; k++)
            {
                wall.NewDay();
                Assert.IsFalse(wall.Attack(k, k + 100, 6));
            }
        }
    }
}
