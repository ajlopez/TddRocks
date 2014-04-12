namespace MagicTrick.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MagicianTests
    {
        [TestMethod]
        public void SolveSampleCaseOne()
        {
            Grid grid1 = new Grid(new string[] {
                "1 2 3 4",
                "5 6 7 8",
                "9 10 11 12",
                "13 14 15 16"
            });

            Grid grid2 = new Grid(new string[] {
                "1 2 5 4",
                "3 11 6 15",
                "9 10 7 12",
                "13 14 8 16"
            });

            Magician magician = new Magician();

            var result = magician.Resolve(2, grid1, 3, grid2);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void SolveSampleCaseTwo()
        {
            Grid grid1 = new Grid(new string[] {
                "1 2 3 4",
                "5 6 7 8",
                "9 10 11 12",
                "13 14 15 16"
            });

            Magician magician = new Magician();

            var result = magician.Resolve(2, grid1, 2, grid1);

            Assert.AreEqual("Bad magician!", result);
        }

        [TestMethod]
        public void SolveSampleCaseThree()
        {
            Grid grid1 = new Grid(new string[] {
                "1 2 3 4",
                "5 6 7 8",
                "9 10 11 12",
                "13 14 15 16"
            });

            Magician magician = new Magician();

            var result = magician.Resolve(2, grid1, 3, grid1);

            Assert.AreEqual("Volunteer cheated!", result);
        }
    }
}
