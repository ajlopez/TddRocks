namespace Dijkstra.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void TooShort()
        {
            Assert.IsFalse(Solver.CanBeSolved(new Quaternions[] { Quaternions.i }, 1));
            Assert.IsFalse(Solver.CanBeSolved(new Quaternions[] { Quaternions.i, Quaternions.j }, 1));
        }

        [TestMethod]
        public void TooShortString()
        {
            Assert.IsFalse(Solver.CanBeSolved("i", 1));
            Assert.IsFalse(Solver.CanBeSolved("ij", 1));
        }

        [TestMethod]
        public void ExactSolution()
        {
            Assert.IsTrue(Solver.CanBeSolved(new Quaternions[] { Quaternions.i, Quaternions.j, Quaternions.k }, 1));
        }

        [TestMethod]
        public void ExactSolutionString()
        {
            Assert.IsTrue(Solver.CanBeSolved("ijk", 1));
        }

        [TestMethod]
        public void FalseThree()
        {
            Assert.IsFalse(Solver.CanBeSolved(new Quaternions[] { Quaternions.i, Quaternions.j, Quaternions.j }, 1));
            Assert.IsFalse(Solver.CanBeSolved(new Quaternions[] { Quaternions.k, Quaternions.j, Quaternions.i }, 1));
        }

        [TestMethod]
        public void FalseThreeString()
        {
            Assert.IsFalse(Solver.CanBeSolved("ijj", 1));
            Assert.IsFalse(Solver.CanBeSolved("kji", 1));
        }

        [TestMethod]
        public void TrueWithRepeat()
        {
            Assert.IsTrue(Solver.CanBeSolved(new Quaternions[] { Quaternions.j, Quaternions.i }, 6));
        }

        [TestMethod]
        public void TrueWithRepeatString()
        {
            Assert.IsTrue(Solver.CanBeSolved("ji", 6));
        }

        [TestMethod]
        public void FalseWithRepeat()
        {
            Assert.IsFalse(Solver.CanBeSolved(new Quaternions[] { Quaternions.i }, 10000));
        }

        [TestMethod]
        public void FalseWithRepeatString()
        {
            Assert.IsFalse(Solver.CanBeSolved("i", 10000));
        }

        [TestMethod]
        public void LongLine()
        {
            Assert.IsFalse(Solver.CanBeSolved("jikikkjijjjkjkkiijjjiijkjjjjiijikkkkikijkkkjkikjjjjiikikkikiiiiiiikkjijjkkiiiikikjkiijijkkjkiijjiikjkjiikikjjijjjjiijkkiikikjkijjjjkjkjkikkikjkjkijikkiijjikkjiiijijijijkkkkiikijjikkijijiikjkikijijkkjjikijjijjjkkkikjijjkjjjiikiiijkijiijjkkkkjjjjjjjjijikkkjkikijkijijjikijikjkiikjkkkkkijjkjjijjjikikjijkkkjjkiiikkkjijkkkkiikiiikjjiiiiikjikiijjkkkikkkjikkkkjjjijikkikjkkjkkiijikkkjkkjikikijijiijijkjkijjjjjkikijjijiiikijjikikkijkjkjjkikkijkjkjkjkijkjjjkjjkkkiijjjjiiikijjjijjkjkjjkkkjkkjikjjkijikkiijijijjkkjjiijkjiikkikkjijjiikkkjkikkijiikjjikjjkjjiiikjiijjjkikjjkjiikkkjkjkiikkijjkjkjjijikiijkjkjikiiijkiikikkjjikkikkjjikkikikjikkkjikjjijkijkiikikjjjkkjjikkijkkikijjjkjiijkikjkkijkkikjjikjjkkijjkkkijkiikjiiiikjjjjjjijjkkkjkjjiiijiikijjikiiijkjkijjkkkikkijijikjkijkjkkikjikjkkkkijijjjjijjikkiiikjiiijjiijkjjkkkjikijiijjijjijikjikjjkikiikiijiiiikijkkiikkiikjjjijijikkkiikkkkkikiijkkkjkjjikjjjj", 3));
        }
    }
}
